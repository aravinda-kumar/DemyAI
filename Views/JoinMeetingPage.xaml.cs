namespace DemyAI.Views;

public partial class JoinMeetingPage : ContentPage {

    public JoinMeetingPage(JoinMeetingPageViewModel joinMeetingPageViewModel) {
        InitializeComponent();
        BindingContext = joinMeetingPageViewModel;
    }
}

