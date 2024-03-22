namespace DemyAI.ViewModels;

public partial class RegisterStudentPageViewModel : BaseViewModel {

    private readonly IDataService<DemyUser> _userService;

    public ObservableCollection<DemyUser> Students { get; set; } = [];

    public ObservableCollection<Course> Courses { get; set; } = [];

    public ObservableCollection<DemyUser>? SelectedStudents { get; set; }

    [ObservableProperty]
    Course? selectedCourse;

    bool IsLoadedFinished = false;

    public RegisterStudentPageViewModel(IDataService<DemyUser> dataService) {
        _userService = dataService;
    }

    [RelayCommand]
    async Task Appearing() {

        if (IsLoadedFinished == false) {

            await Task.Delay(1000);

            await GetStudents();
        }

    }

    private async Task GetStudents() {
        Students.Clear();
        var users = await _userService.GetByRole(nameof(Roles.Student));
        foreach (var item in users) {
            Students.Add(item);
        }

        await GetCourses();

        IsLoadedFinished = true;
    }

    private async Task GetCourses() {
        Courses.Clear();

        var courses = await _userService.GetAllAsync<Course>(Helpers.Constants.COURSES);
        foreach (var course in courses) {
            Courses.Add(course);
        }
    }
    [RelayCommand]
    public void Add(Syncfusion.Maui.Inputs.SelectionChangedEventArgs eventArgs) {

    }

    [RelayCommand]
    public async Task RegisterToCourse() {

        //var answer = await Shell.Current.DisplayAlert("Warning",
        //    $"You are about to register\nStudent: {SelectedStudent!.FullName}\nin Course: {SelectedCourse!.Name}", "Confirm", "Cancel");

        //if(answer == false) {
        //    return;
        //} else {
        //    UpdateUser(SelectedStudent);
        //}

    }

    private void UpdateUser(DemyUser? selectedStudent) {

    }
}
