namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<Student> dataService) : BaseViewModel {

    [ObservableProperty]
    bool isVisible = true;

    [ObservableProperty]
    bool isPopOpen;

    [ObservableProperty]
    Student student = new();

    [RelayCommand]
    void OpenPopUp() {
        IsPopOpen = true;
    }

    [RelayCommand]
    Task Login() {
        return Task.FromResult(0);
    }

    [RelayCommand]
    async Task Register() {
        IsBusy = true;
        IsVisible = false;
        IsPopOpen = false;
        Student.Id = Student.GenerateRandomNumberString();
        Student.Email = Student.Email;
        Student.SetPassword(Student.PasswordHash);

        var key = await dataService.AddAsync("Users", Student);
        if (key is not null) {
            IsBusy = false;
            IsVisible = true;
        }

    }
}
