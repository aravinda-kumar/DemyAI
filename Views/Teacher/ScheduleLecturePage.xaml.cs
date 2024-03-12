namespace DemyAI.Views;

public partial class ScheduleLecturePage : ContentPage {
    public ScheduleLecturePage(ScheduleLecturePageViewModel scheduleLecturePageViewModel) {
        InitializeComponent();
        BindingContext = scheduleLecturePageViewModel;
    }
}