using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class LoginPageViewModel(IDataService<User> dataService, IAppService appService,
    IAuthenticationService authenticationService, AppShellViewModel appShellViewModel) : BaseViewModel {

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
        if(user != null) {

            var currentUser = await dataService.GetByUidAsync<User>("Users", user.Uid);

            if(currentUser != null) {

                var courses = await dataService.GetAllAsync<Course>("Courses"); 
                appShellViewModel.CheckRegistrationReminderOpen(courses);

                ManageFlyoutItemsVisibility(currentUser.Role);

                appShellViewModel.User = currentUser;

                await appService.NavigateTo($"//{nameof(WelcomePage)}", true);
            }


        }

        IsBusy = false;
    }


    [RelayCommand]
    async Task Register() {

        var IsFilled = await VerifyUserAsync(User);

        if(IsFilled) {
            IsBusy = true;

            var user = await authenticationService.RegisterWithEmailAndPassword(User.Email, User.Password, User.Name);
            if(user != null) {

                IsPopOpen = false;

                User.DemyId = NumberGenerator.GenerateRandomNumberString(8);

                await dataService.AddAsync("Users", User);

                await appService.DisplayAlert("Congratulations", "Registration successful", "OK");

                IsPopOpen = false;

                IsBusy = false;
            }
        }
    }

    private async Task<bool> VerifyUserAsync(User user) {

        if(string.IsNullOrEmpty(user.Name)
            && string.IsNullOrEmpty(user.Email)
            && string.IsNullOrEmpty(user.Role)) {

            await appService.DisplayAlert("Error", "Please make sure everything is filed", "OK");
            return false;
        }

        return true;
    }

    private void ManageFlyoutItemsVisibility(string role) {

        switch(role) {
            case nameof(Roles.Coordinator):
                appShellViewModel.IsCoordinator = true;
                break;
            case nameof(Roles.Teacher):
                appShellViewModel.IsTeacher = true;
                break;
            case nameof(Roles.Student):
                appShellViewModel.IsStudent = true;
                break;
            default:
                break;
        }
    }
}
