
namespace DemyAI.ViewModels;

public partial class LoginPageViewModel(IDataService<DemyUser> dataService, IAppService appService,
    IAuthenticationService authenticationService, ISecureStorage storage) : BaseViewModel {

    [ObservableProperty]
    bool isPopOpen;

    [ObservableProperty]
    DemyUser user = new();

    [RelayCommand]
    void OpenPopUp() {
        IsPopOpen = true;
    }

    [RelayCommand]
    async Task Login() {

        IsBusy = true;

        //var user = await authenticationService.LoginWithEmailAndPassword("s@s.com", "123456");
        var user = await authenticationService.LoginWithEmailAndPassword(User.Email!, User.Password!);
        if (user is not null) {

            var currentUser = await dataService.GetByEmailAsync(Constants.USERS,
            user!.Info.Email);

            await storage.SetAsync(Constants.LOGGED_USER, currentUser!.Email!);

            if (currentUser?.CurrentRole is not null) {

                FlyoutHelper.CreateFlyoutMenu(currentUser.CurrentRole!);
                FlyoutHelper.CreateFlyoutHeader(currentUser);

                await appService.NavigateTo($"//{currentUser.CurrentRole}DashboardPage", true);

            } else {

                await appService.NavigateTo($"//{nameof(RoleSelectionPage)}", true);
            }
        }

        IsBusy = false;
    }

    [RelayCommand]
    public void Appearing() {

        //ClearUserFields();
    }


    [RelayCommand]
    async Task Register() {

        IsBusy = true;

        var completeName = $"{User.Firstname} {User.Lastname}";

        var user = await authenticationService.RegisterWithEmailAndPassword(
            User.Email!, User.Password!, completeName!);

        if (user != null) {

            User.DemyId = NumberGenerator.GenerateRandomNumberString(8);

            var uid = await dataService.AddAsync("Users", User);

            await dataService.UpdateAsync<DemyUser>("Users", uid, uid, Constants.UID);

            await appService.DisplayAlert("Congratulations", "Registration successful", "OK");

            IsPopOpen = false;

            IsBusy = false;
        }

        IsBusy = false;
    }

}
