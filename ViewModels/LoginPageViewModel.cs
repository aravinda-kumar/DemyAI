
namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<Student> dataService, IAppService appService, IAuthenticationService authenticationService) : BaseViewModel {

    [ObservableProperty]
    bool isRegisterVisible = true;

    [ObservableProperty]
    bool isPopOpen;

    [ObservableProperty]
    Student student = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RegisterCommand))]
    bool canEnableRegisterButton = false;

    [RelayCommand]
    void OpenPopUp() {
        IsPopOpen = true;
    }

    [RelayCommand]
    async Task Login() {

        await appService.NavigateTo($"//{nameof(HomePage)}", true);
    }

    [RelayCommand(CanExecute = nameof(CanRegisterExecute))]
    async Task Register() {

        IsBusy = true;
        IsRegisterVisible = false;

        var user = await authenticationService.RegisterWithEmailAndPassword(Student.Email, Student.Password);
        if (user != null) {
            IsPopOpen = false;
            await dataService.AddAsync("Users", Student);
        }

    }

    private bool CanRegisterExecute() {
        if (string.IsNullOrEmpty(Student.Email) && string.IsNullOrEmpty(Student.Password)) {
            return true;
        }

        return false;
    }
}
