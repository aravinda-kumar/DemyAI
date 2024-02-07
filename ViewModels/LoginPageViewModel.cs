using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<User> dataService, IAppService appService,
    IAuthenticationService authenticationService, AppShellViewModel appShellViewModel) : BaseViewModel {

    [ObservableProperty]
    bool isPopOpen;

    [ObservableProperty]
    User user = new();

    [RelayCommand]
    void OpenPopUp() {
        IsPopOpen = true;
    }

    [RelayCommand]
    async Task Login() {

        IsBusy = true;

        //var user = await authenticationService.LoginWithEmailAndPassword(User.Email, User.Password);
        var user = await authenticationService.LoginWithEmailAndPassword("egomezr@outlook.com", "111111");

        if(user != null) {
            await SecureStorage.SetAsync("CurrentUser", user.Uid);
            await RoleVisibility.ManageFlyoutItemsVisibility(appShellViewModel, dataService, user.Uid, appService);
        }

        IsBusy = false;
    }


    [RelayCommand]
    async Task Register() {

        var IsFilled = await VerifyUserAsync(User);

        if(IsFilled) {
            IsBusy = true;
            var user = await authenticationService.RegisterWithEmailAndPassword(User.Email!, User.Password!,
                User.Name!);

            if(user != null) {

                IsPopOpen = false;

                User.DemyId = NumberGenerator.GenerateRandomNumberString(8);

                await dataService.AddAsync("Users", User);

                await appService.DisplayAlert("Congratulations", "Registration successful", "OK");

                IsPopOpen = false;

                IsBusy = false;
            }
        }
    }

    private async Task<bool> VerifyUserAsync(User user) {

        if(string.IsNullOrEmpty(user.Name)
            && string.IsNullOrEmpty(user.Email)
            && string.IsNullOrEmpty(user.Role)) {

            await appService.DisplayAlert("Error", "Please make sure everything is filed", "OK");
            return false;
        }

        return true;
    }
}
