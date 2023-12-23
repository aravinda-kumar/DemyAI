using Syncfusion.Maui.Calendar;

using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;

public partial class ManageCoursePageViewModel(IDataService<User> dataService, IAppService appService) : BaseViewModel {

    private const string CourseNode = "Courses";
    private const string Uid = "Uid";

    public ObservableCollection<User> Teachers { get; set; } = [];

    [ObservableProperty]
    Course course = new();

    private User User = new();

    [RelayCommand]
    async Task Appearing() {
        await GetTeachers();
    }

    private async Task GetTeachers() {

        Teachers.Clear();

        var data = await dataService.GetByRole<User>("Users", Roles.Teacher.ToString());

        foreach(var user in data) {

            Teachers.Add(user);
        }
    }

    [RelayCommand]
    async Task CreateCourse(CalendarDateRange dateRange) {

        var todayDate = DateTime.Today.ToString("d");

        Course.Uid = string.Empty;
        Course.DemyId = NumberGenerator.GenerateRandomNumberString(4);
        Course.Name = Course.Name;
        Course.InitialRegistrationDate = dateRange.StartDate!.Value.ToString("d");
        Course.EndRegistrationDate = dateRange.EndDate!.Value.ToString("d");
        Course.ProfessorName = User.Name;
        Course.ProfessorEmail = User.Email;
        Course.professorAssigned = User.Uid;

        if(todayDate == Course.InitialRegistrationDate) {
            Course.isCourseOpen = true;
        }

        var cousesList = await dataService.GetAllAsync<Course>("Courses");
        bool CourseExsist = false;

        foreach(var item in cousesList) {

            if(item.Object.Name == Course.Name) {
                CourseExsist = true;
                break;
            }
        }

        if(CourseExsist) {
            await appService.DisplayAlert("Error", "This course already exist", "OK");
        } else {
            var uid = await dataService.AddAsync(CourseNode, Course);
            if(uid != null) {
                await dataService.UpdateAsync<Course>(CourseNode, uid, uid, Uid);

                await appService.DisplayAlert("Congratulations", "the course has been created successfully", "OK");
            }
        }
    }

    [RelayCommand]
    void HandleCheckBox(User user) {

        if(user != null && user.IsAssigned == true) {

            User = user;
        }
    }
}
