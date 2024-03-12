namespace DemyAI.Views;

public partial class JoinMeetingPage : ContentPage {

    private readonly JoinMeetingPageViewModel joinMeetingPageViewModel;

    public JoinMeetingPage(JoinMeetingPageViewModel joinMeetingPageViewModel) {
        InitializeComponent();
        this.joinMeetingPageViewModel = joinMeetingPageViewModel;
        BindingContext = this.joinMeetingPageViewModel;
    }
}

