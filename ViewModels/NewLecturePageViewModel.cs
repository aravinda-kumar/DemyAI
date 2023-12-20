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
    async Task Appearing() {
        await GetStudents();
    }

    private async Task GetStudents() {
        Users.Clear();

        var data = await dataService.GetByRole<User>("Users", Roles.Student.ToString());

        foreach(var filterUser in data) {

            Users.Add(filterUser);
        }
    }

    [RelayCommand]
    void HandleCheckBox(User user) {

        if(user.IsInvited) {
            Invited.Add(user);
        } else {
            Invited.Remove(user);
        }
    }
}
