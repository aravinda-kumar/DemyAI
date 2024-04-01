namespace DemyAI.ViewModels;

public partial class RegisterStudentPageViewModel(IDataService<DemyUser> dataService, IAppService appService) : BaseViewModel {
    public ObservableCollection<DemyUser> Students { get; set; } = [];

    public ObservableCollection<Course> Courses { get; set; } = [];

    public ObservableCollection<DemyUser>? SelectedStudents { get; set; } = [];

    [ObservableProperty]
    Course? selectedCourse;

    bool IsLoadedFinished = false;

    [RelayCommand]
    async Task Appearing() {

        if (IsLoadedFinished == false) {

            await Task.Delay(1000);

            await GetStudents();
        }

    }

    private async Task GetStudents() {
        Students.Clear();
        var users = await dataService.GetByRole(nameof(Roles.Student));
        foreach (var item in users) {
            Students.Add(item);
        }

        await GetCourses();

        IsLoadedFinished = true;
    }

    private async Task GetCourses() {
        Courses.Clear();

        var courses = await dataService.GetAllAsync<Course>(Helpers.Constants.COURSES);
        foreach (var course in courses) {
            Courses.Add(course);
        }
    }

    [RelayCommand]
    public async Task RegisterToCourse() {

        var originalStudentUids = new HashSet<string>(SelectedCourse!.Students);

        var studentNames = SelectedStudents?.Select(s => s.FullName).ToList();

        var Names = studentNames?.Select(name => $" - {name}").ToList();

        var answer = await appService.DisplayAlert("Warning",
             $"You are about to register: \n\n{string.Join("\n", Names!)}\n\ninto: {SelectedCourse!.Name}",
             "OK", "Cancel");

        if (answer) {

            SelectedCourse.Students.Clear();

            foreach (var item in SelectedStudents!) {
                var studentUid = item?.Uid;

                if (!string.IsNullOrEmpty(studentUid)) {
                    SelectedCourse.Students.Add(studentUid);
                }
            }

            if (!originalStudentUids.SetEquals(SelectedCourse.Students)) {
                await dataService.UpdateAsync(Constants.COURSES, SelectedCourse.Uid, SelectedCourse);
            }
        }

    }
}
