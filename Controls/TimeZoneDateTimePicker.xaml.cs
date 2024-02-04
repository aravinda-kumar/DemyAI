namespace DemyAI.Controls;

public partial class TimeZoneDateTimePicker : ContentView {

    DateTime SelectedTime;
    string SelectedTimeZone;

    public TimeZoneDateTimePicker() {
        InitializeComponent();
    }

    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
        nameof(Items), typeof(IDictionary<int, string>), typeof(TimeZoneDateTimePicker));

    public IDictionary<int, string> Items {
        get => (IDictionary<int, string>)GetValue(ItemsProperty);
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
        //Concatenate DateTime with TimeZone and sen it to the NewLectureViewModel, need help
    }
}