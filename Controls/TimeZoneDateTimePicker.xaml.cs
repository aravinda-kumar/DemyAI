namespace DemyAI.Controls;

public partial class TimeZoneDateTimePicker : ContentView {
    public TimeZoneDateTimePicker() {
        InitializeComponent();
    }

    private void DateTimePicker_OkButtonClicked(object sender, EventArgs e) {



    }

    private void TimeZonePicker_OkButtonClicked(object sender, EventArgs e) {

    }

    private void CustomPickerOpen_Clicked(object sender, EventArgs e) {

        DateTimePicker.IsOpen = !DateTimePicker.IsOpen;
        CustomTimeZonePicker.IsOpen = !CustomTimeZonePicker.IsOpen;

    }
}