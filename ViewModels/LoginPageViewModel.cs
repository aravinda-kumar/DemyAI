using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<User> dataService, IAppService appService,
    IAuthenticationService authenticationService,
    AppShellViewModel appShellViewModel) : BaseViewModel {

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
            await GenerateDemyId(dataService, appShellViewModel, user);

            await appService.NavigateTo($"//{nameof(HomePage)}", true);
        }

        IsBusy = false;
    }

    [RelayCommand]
    async Task Register() {

        if (string.IsNullOrEmpty(User.Name)
            && string.IsNullOrEmpty(User.Email)
            && string.IsNullOrEmpty(User.Password)
            && string.IsNullOrEmpty(User.Role)) {

            await appService.DisplayAlert("Error", "Please make sure everything is filed", "OK");
            return;
        }

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

            await GenerateDemyId(dataService, appShellViewModel, user);

            await appService.NavigateTo($"//{nameof(HomePage)}", true);
        }

        IsBusy = false;
    }

    private static async Task GenerateDemyId(IDataService<User> dataService,
        AppShellViewModel appShellViewModel, Firebase.Auth.User user) {

        var obj = await dataService.GetByUidAsync<User>("Users", user.Uid);

        appShellViewModel.User = obj!;

    }
}
