

namespace DemyAI.ViewModels;

public partial class MyCoursesPageViewModel(
    IDataService<DemyUser> dataService,
    IAppService appService,
    ISecureStorage secure) : BaseViewModel {

    public ObservableCollection<Course> CoursesAssigned { get; set; } = [];

    public ObservableCollection<string> CoursesStudents { get; set; } = [];

    public ObservableCollection<Course> OriginalCourseList { get; set; } = [];

    [ObservableProperty]
    int total;

    [ObservableProperty]
    string textToSearch;

    bool areCousesLoaded;

    [RelayCommand]
    async Task Appearing() {
        if (areCousesLoaded == false) {
            await GetCourses();
            OriginalCourseList = new ObservableCollection<Course>(CoursesAssigned);
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
            OriginalCourseList.Add(course);
        }

        foreach (var course in courses) {
            Total = course.Students.Count;
        }

        IsBusy = false;
        areCousesLoaded = true;

    }

    [RelayCommand]
    void Search() {

        PerformSearch(TextToSearch);
    }

    private void PerformSearch(string text) {
        if (!string.IsNullOrEmpty(text)) {
            var newStudents = CoursesAssigned.Where(c => c.Name!.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
            CoursesAssigned.Clear();
            foreach (var student in newStudents) {
                CoursesAssigned.Add(student);
            }
        } else {
            CoursesAssigned.Clear();
            foreach (var item in OriginalCourseList) {
                CoursesAssigned.Add(item);
            }
        }
    }

    [RelayCommand]
    async Task GoToDetails(Course course) {

        await appService.NavigateTo($"{nameof(MyCoursesDetailPage)}",
            true, new Dictionary<string, object> {
            {"Course", course }
        });
    }


}
