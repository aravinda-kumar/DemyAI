
namespace DemyAI.ViewModels;

public partial class RegisterStudentPageViewModel(IDataService<DemyUser> dataService) : BaseViewModel {

    public ObservableCollection<DemyUser> Students { get; set; } = [];

    public ObservableCollection<Course> Courses { get; set; } = [];

    [ObservableProperty]
    DemyUser? selectedStudent;

    [ObservableProperty]
    Course? selectedCourse;

    bool IsLoadedFinished = false;

    [RelayCommand]
    async Task Appearing() {

        if(IsLoadedFinished == false) {

            await Task.Delay(1000);

            await GetStudents();
        }

    }

    private async Task GetStudents() {
        Students.Clear();
        var users = await dataService.GetByRole(nameof(Role.Student));
        foreach(var item in users) {
            Students.Add(item);
        }

        await GetCourses();
    }

    private async Task GetCourses() {
        Courses.Clear();
        var courses = await dataService.GetAllAsync<Course>(Helpers.Constants.COURSES);
        foreach(var course in courses) {
            Courses.Add(course);
        }
    }

    [RelayCommand]
    public async void RegisterToCourse() {

        var answer = await Shell.Current.DisplayAlert("Warning",
            $"You are about to register {SelectedStudent} in {SelectedCourse}", "Confirm", "Cancel");

        if(answer == false) {
            return;
        } else {
            UpdateUser(SelectedStudent);
        }

    }

    private void UpdateUser(DemyUser? selectedStudent) {

    }
}
