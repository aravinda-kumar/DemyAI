using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;

public partial class NotificationsPageViewModel(IDataService<User> dataService) : BaseViewModel {

    public ObservableCollection<Course> Courses { get; set; } = [];
    bool areCousesLoaded;
    User? currentUser;

    [ObservableProperty]
    string inviteText = string.Empty;

    [RelayCommand]
    async Task Appearing() {
        if(areCousesLoaded == false) {
            await GetCourses();
        }

    }

    private async Task GetCourses() {

        areCousesLoaded = false;
        IsBusy = true;

        Courses.Clear();

        var savedUserEmail = await SecureStorage.GetAsync("CurrentUser");

        var courses = await dataService.GetAllAsync<Course>("Courses");

        var cousesAssigned = courses.Where(
            c => c.Object.ProfessorsAssigned.Contains(savedUserEmail!)).Select(
            c => c.Object);

        foreach(var item in cousesAssigned) {

            Courses.Add(item);
        }

        IsBusy = false;
        areCousesLoaded = true;

    }
}
