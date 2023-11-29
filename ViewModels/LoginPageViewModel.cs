using System.ComponentModel.DataAnnotations;

namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<Student> dataService, IAppService appService) : BaseViewModel {

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
        if (!new EmailAddressAttribute().IsValid(Student.Email)) {
            await appService.DisplayToast("Please provide a valid email address", ToastDuration.Short, 18);
            return;
        }
        Student.Id = Student.GenerateRandomNumberString();
        Student.Email = Student.Email;

        IsBusy = true;
        IsVisible = false;
        IsPopOpen = false;
        Student.SetPassword(Student.PasswordHash);

        var key = await dataService.AddAsync("Users", Student);
        if (key is not null) {
            IsBusy = false;
            IsVisible = true;
        }

    }
}
