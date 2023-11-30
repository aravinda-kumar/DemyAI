namespace DemyAI.ViewModels;
public partial class MeetingsPageViewModel : BaseViewModel {

    [RelayCommand]
    Task CreateNewMeeeting() {

        return Task.FromResult(0);
    }

    [RelayCommand]
    Task JoinMeeting() {
        return Task.FromResult(0);
    }
}
