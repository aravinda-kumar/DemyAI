namespace DemyAI.ViewModels;

public partial class LoginPageViewModel(IDataService<DemyUser> dataService, IAppService appService,
    IAuthenticationService authenticationService) : BaseViewModel {

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

        var user = await authenticationService.LoginWithEmailAndPassword("a@a.com", "123456");
        if(user is not null) {

            await appService.NavigateTo($"//{nameof(RoleSelectionPage)}", true);
        }

        IsBusy = false;
    }


    [RelayCommand]
    async Task Register() {

        IsBusy = true;

        var user = await authenticationService.RegisterWithEmailAndPassword(User.Email!, User.Password!,
            User.Name!);

        if(user != null) {

            User.DemyId = NumberGenerator.GenerateRandomNumberString(8);

            var uid = await dataService.AddAsync("Users", User);

            await dataService.UpdateAsync<DemyUser>("Users", uid, uid, "Uid");

            await appService.DisplayAlert("Congratulations", "Registration successful", "OK");

            IsPopOpen = false;

            IsBusy = false;
        }

        IsBusy = false;
    }
}
