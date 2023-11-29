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

        await appService.NavigateTo($"//{nameof(HomePage)}", true);
    }

    [RelayCommand]
    async Task Register() {

        if (string.IsNullOrEmpty(Student.Email)) {

            await appService.DisplayToast("Please enter a email address", ToastDuration.Short, 18);
            return;
        }

        if (string.IsNullOrEmpty(Student.Password)) {

            await appService.DisplayToast("Please enter a password", ToastDuration.Short, 18);
            return;
        }

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
