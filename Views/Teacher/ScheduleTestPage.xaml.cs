namespace DemyAI.Views;

public partial class ScheduleTestPage : ContentPage {

    public ScheduleTestPage(ScheduleTestPageViewModel scheduleTestPageViewModel) {
        InitializeComponent();
        BindingContext = scheduleTestPageViewModel;
    }
}