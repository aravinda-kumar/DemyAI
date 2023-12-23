using User = DemyAI.Models.User;
namespace DemyAI.ViewModels;

public partial class AppShellViewModel(IAuthenticationService authenticationService, IAppService appService) : BaseViewModel {

    [ObservableProperty]
    User? user;

    [ObservableProperty]
    bool isCoordinator;

    [ObservableProperty]
    bool isStudent;

    [ObservableProperty]
    bool isTeacher;

    [ObservableProperty]
    bool isRegisterOpen;

    public void CheckRegistrationReminderOpen(IReadOnlyCollection<FirebaseObject<Course>> courses) {

        var today = DateTime.Today;
        bool isOpen = courses.Any(course => {
            DateTime dateTime = DateTime.Parse(course.Object.EndRegistrationDate);
            return today <= dateTime;
        });
        IsRegisterOpen = isOpen;

    }

    [RelayCommand]
    async Task SignOut() {

        authenticationService.SignOut();

        await appService.NavigateTo($"//{nameof(LoginPage)}", true);

    }
}
