using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class NewLecturePageViewModel(IAppService appService, IDataService<User> dataService,
    IAuthenticationService authenticationService) : BaseViewModel {

    public ObservableCollection<User> Users { get; set; } = [];

    public ObservableCollection<User> Invited { get; set; } = [];

    [RelayCommand]
    void StartMeeting() {

        Console.WriteLine($"{Invited.Count}");
    }

    [RelayCommand]
    void Appearing() {
        GetUsers();
    }

    private async void GetUsers() {
        Users.Clear();

        var currenUser = await authenticationService.GetLoggedInUser();

        if (currenUser != null) {

            var data = await dataService.GetAllAsync<User>("Users");

            var filterUsers = data
                .Where(u => u.Object.Uid != currenUser?.Uid && u.Object.Role == Roles.Student.ToString())
                .Select(u => u.Object)
                .ToList();

            foreach (var filterUser in filterUsers) {

                Users.Add(filterUser);
            }
        }
    }

    [RelayCommand]
    void HandleCheckBox(User user) {

        if (user.IsInvited) {
            Invited.Add(user);
        } else {
            Invited.Remove(user);

        }

    }
}
