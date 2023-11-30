namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<Student> dataService, IAppService appService, IAuthenticationService authenticationService) : BaseViewModel {

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

        var user = await authenticationService.LoginWithEmailAndPassword(Student.Email, Student.Password);
        if (user != null) {

            await appService.NavigateTo($"//{nameof(HomePage)}", true, new Dictionary<string, object>() {
                {"user", user}
            });
        }

    }

    [RelayCommand]
    async Task Register() {

        IsBusy = true;
        IsRegisterVisible = false;

        var user = await authenticationService.RegisterWithEmailAndPassword(Student.Email, Student.Password);
        if (user != null) {
            IsPopOpen = false;
            Student.Id = Student.GenerateRandomNumberString();
            Student.Email = Student.Email;
            Student.Password = BCrypt.Net.BCrypt.HashPassword(Student.Password);

            await dataService.AddAsync("Users", Student);
        }

    }
}
