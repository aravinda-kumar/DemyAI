using Syncfusion.Maui.Calendar;

using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;

public partial class ManageCoursePageViewModel(IDataService<User> dataService) : BaseViewModel {

    public ObservableCollection<User> Teachers { get; set; } = [];

    [ObservableProperty]
    Course course = new();

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
    void CreateCourse(CalendarDateRange dateRange) {
        Course.Name = Course.Name;
        Course.initialDate = dateRange.StartDate;
        Course.endDate = dateRange.EndDate;
    }

    [RelayCommand]
    void HandleCheckBoxCommand(User user) {

    }
}
