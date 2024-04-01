
namespace DemyAI.ViewModels;

[QueryProperty($"{nameof(Course)}", "Course")]
public partial class MyCoursesDetailPageViewModel(IDataService<DemyUser> dataService) : BaseViewModel {

    [ObservableProperty]
    Course? course;

    public ObservableCollection<DemyUser> Students { get; set; } = [];

    [RelayCommand]
    async Task Contact(string email) {

        await EmailHelper.OpenEmailClientAsync(email);
    }


    [RelayCommand]
    async Task AppearingAsync() {

        if (Course is not null) {

            foreach (var item in Course.Students) {

                var users = await dataService.GetByUidAsync<DemyUser>(Constants.USERS, item);

                if (users is not null) {

                    Students.Clear();

                    Students.Add(users);


                }
            }
        }
    }

}
