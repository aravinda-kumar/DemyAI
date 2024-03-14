namespace DemyAI.ViewModels;

public partial class RoleSelectionPageViewModel : BaseViewModel {

    private readonly IAppService _appService;
    private readonly IAuthenticationService _authService;
    private readonly IDataService<DemyUser> _dataService;

    [ObservableProperty]
    string? welcomeText;

    public ObservableCollection<UserRoles>? Roles { get; set; }

    string? selectedRole;

    User? fireUser;

    public RoleSelectionPageViewModel(IAuthenticationService authService,
        IDataService<DemyUser> dataService, IAppService appService) {

        _authService = authService;
        _dataService = dataService;
        _appService = appService;
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
                role.SelectedColor = UserRoles.RoleSelectedColor;
            } else {
                role.SelectedColor = UserRoles.DefaultUnselectedColor;
            }
        }

        selectedRole = SelectedRole.Name.ToString();
    }

    [RelayCommand]
    public async Task UpdateUserCurrentRole() {

        var currentUser = await _dataService.GetByEmailAsync<DemyUser>("Users", fireUser!.Info.Email);

        if(currentUser is not null) {

            currentUser.Roles ??= [];

            currentUser.CurrentRole = selectedRole;

            if(!currentUser.Roles.Contains(selectedRole!)) {
                currentUser.Roles.Add(selectedRole!);
            }

            await _dataService.UpdateAsync("Users", currentUser.Uid!, currentUser);
        }

        var updatedUser = await _dataService.GetByEmailAsync<DemyUser>("Users", fireUser!.Info.Email);

        FlyoutHelper.CreateFlyoutHeader(updatedUser);

        FlyoutHelper.CreateFlyoutMenu(updatedUser?.CurrentRole!);

        var cuurentUserAsJson = JsonSerializer.Serialize(updatedUser);

        await SecureStorage.SetAsync(Constants.LOGGED_USER, cuurentUserAsJson);

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
