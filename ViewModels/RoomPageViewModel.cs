namespace DemyAI.ViewModels;

public partial class RoomPageViewModel(string RoomName) : BaseViewModel {

    [ObservableProperty]
    string url = $"{Constants.BASETTING_URL}{RoomName}";
}
