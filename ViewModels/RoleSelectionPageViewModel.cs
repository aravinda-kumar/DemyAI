namespace DemyAI.ViewModels;

public partial class RoleSelectionPageViewModel : BaseViewModel {

    private readonly ISecureStorage _secureStorage;
    private readonly IAuthenticationService _authService;
    private readonly IDataService<DemyUser> _dataService;

    [ObservableProperty]
    string? welcomeText;

    public ObservableCollection<UserRoles>? Roles { get; set; }

    string? selectedRole;

    User? fireUser;

    public RoleSelectionPageViewModel(IAuthenticationService authService,
        IDataService<DemyUser> dataService, ISecureStorage secureStorage) {

        _authService = authService;
        _dataService = dataService;
        _secureStorage = secureStorage;
        InitPopUp();
    }

    private async void InitPopUp() {

        Roles = GetRoles();
        fireUser = await _authService.GetLoggedInUser();
        WelcomeText = $"Welcome {fireUser?.Info.DisplayName}, please chose a role";
    }

    [RelayCommand]
    public void RoleSelected(UserRoles SelectedRole) {

        foreach(var role in Roles!) {

            role.IsSelected = role == SelectedRole; // Set IsSelected to true only for the selected rol

            if(role.IsSelected) {
                role.SelectedColor = Constants.SelectedColor;
            } else {
                role.SelectedColor = Constants.DefaultUnselectedColor;
            }
        }

        selectedRole = SelectedRole.Name.ToString();
    }

    [RelayCommand]
    public async Task UpdateUserCurrentRole() {

        var currentUser = await _dataService.GetByEmailAsync<DemyUser>(Constants.USERS,
            fireUser!.Info.Email);

        if(currentUser is not null) {

            currentUser.Roles ??= [];

            currentUser.CurrentRole = selectedRole;

            if(!currentUser.Roles.Contains(selectedRole!)) {
                currentUser.Roles.Add(selectedRole!);
            }

            await _dataService.UpdateAsync(Constants.USERS, currentUser.Uid!, currentUser);
        }

        var updatedUser = await _dataService.GetByEmailAsync<DemyUser>(Constants.USERS,
            fireUser!.Info.Email);

        var cuurentUserAsJson = JsonSerializer.Serialize(updatedUser);

        await _secureStorage.SetAsync(Constants.LOGGED_USER, cuurentUserAsJson);

        FlyoutHelper.CreateFlyoutHeader(updatedUser);

        FlyoutHelper.CreateFlyoutMenu(updatedUser?.CurrentRole!);

        await NvigationHelper.NavigatoToDashboardRoleAsync(updatedUser?.CurrentRole!);
    }

    private ObservableCollection<UserRoles> GetRoles() {

        return Roles = [
            new() { Name = Role.Teacher },
            new() { Name = Role.Student },
            new() { Name = Role.Coordinator },
        ];
    }

}
