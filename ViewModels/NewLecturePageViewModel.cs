using System.Reactive.Linq;

using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class NewLecturePageViewModel(IAppService appService, IDataService<User> dataService,
    IAuthenticationService authenticationService) : BaseViewModel {

    [ObservableProperty]
    bool isChecked;

    partial void OnIsCheckedChanged(bool value) {

    }

    public ObservableCollection<User> Users { get; set; } = [];

    public ObservableCollection<User> Invited { get; set; } = [];

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

    [RelayCommand]
    void HandleCheckBox(User user) {

        if (IsChecked is false) {
            appService.DisplayToast("False", ToastDuration.Short, 18);
        } else {
            appService.DisplayToast("true", ToastDuration.Short, 18);

        }

    }
}
