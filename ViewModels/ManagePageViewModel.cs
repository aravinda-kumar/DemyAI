using User = DemyAI.Models.User;

namespace DemyAI.ViewModels;
public partial class ManagePageViewModel(DataService<User> dataService) : ObservableObject {

    public ObservableCollection<User> Users { get; set; } = [];

    [RelayCommand]
    async Task Appearing() {
        await GetTeachers();
    }

    private async Task GetTeachers() {

        Users = await dataService.GetByRole<User>("Users", Roles.Teacher.ToString());
    }
}
