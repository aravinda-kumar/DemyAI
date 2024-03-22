namespace DemyAI.ViewModels;

public partial class ManageCoursePageViewModel(IDataService<DemyUser> dataService, IAppService appService) : BaseViewModel {

    public ObservableCollection<DemyUser> Teachers { get; set; } = [];

    [ObservableProperty]
    DemyUser? selectedTeacher;

    [ObservableProperty]
    Course course = new();

    bool IsLoadedFinished = false;

    [RelayCommand]
    async Task Appearing() {

        if(IsLoadedFinished == false) {

            await Task.Delay(1000);

            await GetTeachers(dataService);
        }

    }

    private async Task GetTeachers(IDataService<DemyUser> dataService) {
        var teahers = await dataService.GetByRole(nameof(Roles.Teacher));

        foreach(var teaher in teahers) {
            Teachers.Add(teaher);
        }

        IsLoadedFinished = true;
    }


    [RelayCommand]
    public async Task CreateCourse() {

        if(string.IsNullOrEmpty(Course.Name)) {
            await appService.DisplayAlert("Error", $"Course name cannot be empty", "OK");
            return;
        }

        if(SelectedTeacher is null) {
            await appService.DisplayAlert("Error", $"Please select a teacher for {Course.Name}", "OK");
            return;
        }

        var courses = await dataService.GetAllAsync<Course>(Constants.COURSES);

        foreach(var course in courses) {
            if(course.Name == Course.Name) {
                await appService.DisplayAlert("Error", $"The courses: {Course.Name} already exist", "OK");
                return;
            }
        }

        Course.Name = Course.Name;

        Course.ProfessorsAssigned.Clear();

        Course.ProfessorsAssigned.Add(SelectedTeacher);

        var CourseUid = await dataService.AddAsync(Constants.COURSES, Course);

        await dataService.UpdateAsync<Course>(
            Constants.COURSES, CourseUid,
            CourseUid,
            Constants.UID);

        if(!string.IsNullOrEmpty(CourseUid)) {
            await appService.DisplayAlert("Success", $"Your course: {Course.Name} was crested successfully", "OK");
        }
    }
}