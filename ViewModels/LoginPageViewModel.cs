namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<Student> dataService, IAppService appService,
    IAuthenticationService authenticationService,
    AppShellViewModel appShellViewModel) : BaseViewModel {

    [ObservableProperty]
    bool isElementVisible = true;

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

        IsElementVisible = false;
        IsBusy = true;
        //TODO change hard coded string in the view

        //var user = await authenticationService.LoginWithEmailAndPassword(Student.Email, Student.Password);
        var user = await authenticationService.LoginWithEmailAndPassword("admin@admin.com", "111111");
        if (user != null) {

            await GetStudentAndNavigate(dataService, appService, appShellViewModel, user);

        }
        IsElementVisible = true;
        IsBusy = false;
    }

    [RelayCommand]
    async Task Register() {

        IsBusy = true;
        IsElementVisible = false;

        var user = await authenticationService.RegisterWithEmailAndPassword(Student.Email, Student.Password);
        if (user != null) {

            IsPopOpen = false;
            Student.Id = Student.GenerateRandomNumberString();
            Student.Email = Student.Email;
            Student.Password = BCrypt.Net.BCrypt.HashPassword(Student.Password);
            Student.Uid = user.Uid;

            await dataService.AddAsync("Users", Student);

            await GetStudentAndNavigate(dataService, appService, appShellViewModel, user);
        }
        IsElementVisible = true;
        IsBusy = false;
    }

    private static async Task GetStudentAndNavigate(IDataService<Student> dataService, IAppService appService, AppShellViewModel appShellViewModel, User user) {
        var obj = await dataService.GetByKeyAsync<Student>("Users", user.Uid);

        appShellViewModel.User = obj!;

        await appService.NavigateTo($"//{nameof(HomePage)}", true);
    }
}
