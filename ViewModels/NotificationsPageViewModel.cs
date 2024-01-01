using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;

public partial class NotificationsPageViewModel(IDataService<User> dataService, IAuthenticationService authenticationService) : BaseViewModel {

    public ObservableCollection<Course> Courses { get; set; } = [];
    bool IsCousesLoading = false;

    [ObservableProperty]
    string inviteText = string.Empty;

    [RelayCommand]
    async Task Appearing() {

        if(IsCousesLoading == false) {
            await GetCourses();
            IsCousesLoading = true;
        }

    }

    private async Task GetCourses() {

        IsBusy = true;

        Courses.Clear();

        var firebasseUser = await authenticationService.GetLoggedInUser();

        var currntUser = await dataService.GetByUidAsync<User>("Users", firebasseUser!.Uid);

        var objects = await dataService.GetAllAsync<Course>("Courses");

        var coursesAssigned = objects.Where(c => c.Object.ProfessorsAssigned.Contains(currntUser!.Uid))
                                              .Select(c => c.Object);

        foreach(var item in coursesAssigned) {

            Courses.Add(item);
        }

        IsBusy = false;

    }
}
