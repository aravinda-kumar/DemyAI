namespace DemyAI.Views;

public partial class ScheduleLecturePage : ContentPage {
    public ScheduleLecturePage(ScheduleLecturePageViewModel scheduleLecturePageViewModel) {
        InitializeComponent();
        BindingContext = scheduleLecturePageViewModel;
    }

    private void TimeZonePicker_OkButtonClicked(object sender, EventArgs e) {
        
    }
}