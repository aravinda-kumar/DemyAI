
namespace DemyAI.ViewModels;

public partial class MyCoursesPageViewModel(IDataService<DemyUser> dataService, ISecureStorage secure) : BaseViewModel {

    public ObservableCollection<Course> CoursesAssigned { get; set; } = [];
    bool areCousesLoaded;

    [RelayCommand]
    async Task Appearing() {
        if (areCousesLoaded == false) {
            await GetCourses();
        }
    }

    private async Task GetCourses() {

        areCousesLoaded = false;
        IsBusy = true;

        var currentUserEmail = await secure.GetAsync(Constants.LOGGED_USER);

        CoursesAssigned.Clear();

        var currentUser = await dataService.GetByEmailAsync(Constants.USERS, currentUserEmail!);

        var courses = await dataService.GetAllAsync<Course>(Constants.COURSES);

        var coursesAssigned = courses.Where(
            c => c.ProfessorsAssigned.Any(p => p.Uid == currentUser!.Uid));

        foreach (var course in coursesAssigned) {
            CoursesAssigned.Add(course);
        }

        IsBusy = false;
        areCousesLoaded = true;

    }
}
