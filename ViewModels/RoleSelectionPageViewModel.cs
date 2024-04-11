namespace DemyAI.ViewModels;


public partial class RoleSelectionPageViewModel : BaseViewModel {

    ISecureStorage _secureStorage;
    private readonly IDataService<DemyUser> _dataService;

    [ObservableProperty]
    string? welcomeText;

    public ObservableCollection<UserRoles>? Roles { get; set; }

    string? selectedRole;

    string? CurrentUserEmail;

    DemyUser? demyUser;

    public RoleSelectionPageViewModel(IDataService<DemyUser> dataService, ISecureStorage secureStorage) {

        _dataService = dataService;
        _secureStorage = secureStorage;
        InitPopUp();
    }

    private async void InitPopUp() {

        Roles = GetRoles();
        CurrentUserEmail = await _secureStorage.GetAsync(Constants.LOGGED_USER);
        demyUser = await _dataService.GetByEmailAsync(Constants.USERS, CurrentUserEmail!);
        if (string.IsNullOrEmpty(demyUser?.CurrentRole)) {
            WelcomeText = $"Welcome {demyUser?.FullName}, please chose a role";
        } else {
            WelcomeText = $"Do you want to change you current role as {demyUser?.CurrentRole}";
        }
    }

    [RelayCommand]
    public void RoleSelected(UserRoles SelectedRole) {

        foreach (var role in Roles!) {

            role.IsSelected = role == SelectedRole; // Set IsSelected to true only for the selected rol

            if (role.IsSelected) {
                role.SelectedColor = Constants.SelectedColor;
            } else {
                role.SelectedColor = Constants.DefaultUnselectedColor;
            }
        }

        selectedRole = SelectedRole.Name.ToString();
    }

    [RelayCommand]
    public async Task UpdateUserCurrentRole() {

        var currentUser = await _dataService.GetByEmailAsync(Constants.USERS,
            demyUser!.Email!);

        if (currentUser is not null) {

            currentUser.Roles ??= [];

            currentUser.CurrentRole = selectedRole;

            if (!currentUser.Roles.Contains(selectedRole!)) {
                currentUser.Roles.Add(selectedRole!);
            }

            await _dataService.UpdateAsync(Constants.USERS, currentUser.Uid!, currentUser);
        }

        var updatedUser = await _dataService.GetByEmailAsync(Constants.USERS,
            demyUser!.Email!);

        FlyoutHelper.CreateFlyoutHeader(updatedUser);

        FlyoutHelper.CreateFlyoutMenu(updatedUser?.CurrentRole!);

        await NvigationHelper.NavigatoToDashboardRoleAsync(updatedUser!);
    }
    private ObservableCollection<UserRoles> GetRoles() {

        return Roles = [
            new() { Name = Helpers.Roles.Teacher },
            new() { Name = Helpers.Roles.Student },
            new() { Name = Helpers.Roles.Coordinator },
        ];
    }

}
