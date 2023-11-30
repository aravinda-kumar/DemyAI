namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<Student> dataService, IAppService appService,
    IAuthenticationService authenticationService,
    AppShellViewModel appShellViewModel) : BaseViewModel {

    [ObservableProperty]
    bool isRegisterVisible = true;

    [ObservableProperty]
    bool isPopOpen;

    [ObservableProperty]
    Student student = new();

    [ObservableProperty]
    bool canEnableRegisterButton = false;

    [RelayCommand]
    void OpenPopUp() {
        IsPopOpen = true;
    }

    [RelayCommand]
    async Task Login() {

        //TODO change hard coded string in the view

        //var user = await authenticationService.LoginWithEmailAndPassword(Student.Email, Student.Password);
        var user = await authenticationService.LoginWithEmailAndPassword("admin@admin.com", "111111");
        if (user != null) {
            var obj = await dataService.GetByKeyAsync<Student>("Users", user.Uid);

            appShellViewModel.User = obj!;

            await appService.NavigateTo($"//{nameof(HomePage)}", true);

        }

    }

    [RelayCommand]
    async Task Register() {

        IsBusy = true;
        IsRegisterVisible = false;

        var user = await authenticationService.RegisterWithEmailAndPassword("admin@admin.com", "111111");
        if (user != null) {
            IsPopOpen = false;
            Student.Id = Student.GenerateRandomNumberString();
            Student.Email = "admin@admin.com";
            //Student.Password = BCrypt.Net.BCrypt.HashPassword(Student.Password);
            Student.Uid = user.Uid;

            await dataService.AddAsync("Users", Student);
        }

    }
}
