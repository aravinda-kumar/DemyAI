namespace DemyAI.Views;

public partial class RoomPage : ContentPage {
    public RoomPage(RoomPageViewModel roomPageViewModel) {
        InitializeComponent();
        BindingContext = roomPageViewModel;
    }
}