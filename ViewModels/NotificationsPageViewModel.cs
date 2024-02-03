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

        var savedUserUID = await SecureStorage.GetAsync("CurrentUser");
        if(savedUserUID is not null) {
            currentUser = await dataService.GetByUidAsync<User>("Users", savedUserUID);
        }

        var objects = await dataService.GetAllAsync<Course>("Courses");

        var coursesAssigned = objects
                                              .Where(c => c.Object.ProfessorsAssigned.Contains(currentUser!.Uid!))
                                              .Select(c => c.Object);

        foreach(var item in coursesAssigned) {

            Courses.Add(item);
        }

        IsBusy = false;
        areCousesLoaded = true;

    }
}
