namespace DemyAI.ViewModels;

[QueryProperty($"{nameof(Course)}", "Course")]
public partial class MyCoursesDetailPageViewModel(IDataService<DemyUser> dataService) : BaseViewModel {

    [ObservableProperty]
    Course course;

    [ObservableProperty]
    DemyUser student;

}
