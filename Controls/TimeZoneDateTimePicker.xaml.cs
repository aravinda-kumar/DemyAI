namespace DemyAI.Controls;

public partial class TimeZoneDateTimePicker : ContentView {

    DateTime SelectedTime;
    int? TimeZone;

    public TimeZoneDateTimePicker() {
        InitializeComponent();
    }

    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
        nameof(Items), typeof(IDictionary), typeof(TimeZoneDateTimePicker));

    public IDictionary Items {
        get => (IDictionary)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }


    private void OpenPicker_Clicked(object sender, EventArgs e) {
        if(TimeZonePicker != null) {
            TimeZonePicker.IsOpen = true;
        }
    }

    private void TimeZonePicker_OkButtonClicked(object sender, EventArgs e) {
        Picker.IsOpen = true;
        TimeZonePicker.IsOpen = true;
        TimeZonePicker.SelectedDate = SelectedTime;
    }

    private void TimeZonePicker_CancelButtonClicked(object sender, EventArgs e) {
        TimeZonePicker.IsOpen = false;
    }

    private void Picker_OkButtonClicked(object sender, EventArgs e) {
        Picker.IsOpen = false;
    }

    private void Picker_SelectionChanged(object sender, PickerSelectionChangedEventArgs e) {

    }
}