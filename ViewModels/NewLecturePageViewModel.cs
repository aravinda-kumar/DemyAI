using System.Reactive.Linq;

using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class NewLecturePageViewModel(IAppService appService, IDataService<User> dataService,
    IAuthenticationService authenticationService) : BaseViewModel {

    public ObservableCollection<User> Users { get; set; } = [];

    [RelayCommand]
    void Appearing() {
        GetUsers();
    }

    private async void GetUsers() {
        Users.Clear();

        var currenUser = await authenticationService.GetLoggedInUser();

        if (currenUser != null) {

            var data = await dataService.GetAllAsync<User>("Users");

            var filterUsers = data
                .Where(u => u.Object.Uid != currenUser?.Uid)
                .Select(u => u.Object)
                .ToList();

            foreach (var filterUser in filterUsers) {

                Users.Add(filterUser);
            }
        }


    }
}
