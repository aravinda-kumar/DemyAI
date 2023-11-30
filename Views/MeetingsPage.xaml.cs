namespace DemyAI.Views;
public partial class MeetingsPage : ContentPage {
    public MeetingsPage(MeetingsPageViewModel meetingsPageViewModel) {
        InitializeComponent();
        BindingContext = meetingsPageViewModel;
    }
}