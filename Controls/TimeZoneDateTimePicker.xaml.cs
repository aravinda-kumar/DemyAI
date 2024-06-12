namespace DemyAI.Controls;

public partial class TimeZoneDateTimePicker : ContentView {

    DateTime SelectedDateTime;
    string SelectedTimeZone;
    int TimeZonePickerSelectedIndex;

    public TimeZoneDateTimePicker() {
        InitializeComponent();
    }

    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
        nameof(Items), typeof(List<string>), typeof(TimeZoneDateTimePicker));

    public List<string> Items {
        get => (List<string>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    private void DateTimePicker_CancelButtonClicked(object sender, EventArgs e) {

        DateTimePicker.IsOpen = false;
    }

    private void DateTimePicker_OkButtonClicked(object sender, EventArgs e) {

        TimeZonePicker.IsOpen = true;

        SelectedDateTime = (DateTime)DateTimePicker.SelectedDate!;

    }

    private void TimeZonePicker_OkButtonClicked(object sender, EventArgs e) {

        SelectedTimeZone = Items[TimeZonePickerSelectedIndex];
    }

    private void TimeZonePicker_CancelButtonClicked(object sender, EventArgs e) {

        TimeZonePicker.IsOpen = false;
    }

    private void OpenDateTimePicker_Clicked(object sender, EventArgs e) {

        DateTimePicker.IsOpen = true;
    }

    private void TimeZonePicker_SelectionChanged(object sender, PickerSelectionChangedEventArgs e) {

        TimeZonePickerSelectedIndex = e.NewValue;

    }
}