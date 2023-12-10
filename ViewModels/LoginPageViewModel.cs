using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<User> dataService, IAppService appService,
    IAuthenticationService authenticationService) : BaseViewModel {

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
        var user = await authenticationService.LoginWithEmailAndPassword("admin@admin.com", "111111");
        if (user != null) {

            var currentUser = await dataService.GetByUidAsync<User>("Users", user.Uid);

            if (currentUser != null) {

                WeakReferenceMessenger.Default.Send(currentUser, "UserLoggedIn");

                await appService.NavigateTo($"//{nameof(HomePage)}", true);
            }


        }

        IsBusy = false;
    }

    [RelayCommand]
    async Task Register() {

        var IsFilled = await VerifyUserAsync(User);

        if (IsFilled) {
            IsBusy = true;

            var user = await authenticationService.RegisterWithEmailAndPassword(User.Email, User.Password);
            if (user != null) {

                IsPopOpen = false;
                User.Uid = user.Uid;
                User.Id = User.GenerateRandomNumberString();
                User.Name = User.Name;
                User.Email = User.Email;
                User.Password = BCrypt.Net.BCrypt.HashPassword(User.Password);
                User.Role = User.Role;

                await dataService.AddAsync("Users", User);

                await appService.NavigateTo($"//{nameof(HomePage)}", true);
            }
        }



        IsBusy = false;
    }

    private async Task<bool> VerifyUserAsync(User user) {

        if (string.IsNullOrEmpty(user.Name)
            && string.IsNullOrEmpty(user.Email)
            && string.IsNullOrEmpty(user.Password)
            && string.IsNullOrEmpty(user.Role)) {

            await appService.DisplayAlert("Error", "Please make sure everything is filed", "OK");
            return false;
        }

        return true;


    }
}
