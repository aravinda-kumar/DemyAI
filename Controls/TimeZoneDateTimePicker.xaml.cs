namespace DemyAI.Controls;

public partial class TimeZoneDateTimePicker : ContentView {

    DateTime SelectedTime;
    int? TimeZone;
    private HttpClient _httpClient;

    ObservableCollection<string> Data = [];

    public TimeZoneDateTimePicker() {
        InitializeComponent();
    }

    private async void OpenPicker_Clicked(object sender, EventArgs e) {
        if(TimeZonePicker != null) {
            TimeZonePicker.IsOpen = true;

            _httpClient = new HttpClient();

            var res = await _httpClient.GetAsync("https://www.timeapi.io/api/TimeZone/AvailableTimeZones");

            if(res.IsSuccessStatusCode) {

                var data = await res.Content.ReadFromJsonAsync<List<string>>();

                for(int i = 0; i < data!.Count - 1; i++) {
                    Data.Add(data[i]);
                }
            }
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

        //Select the timeZone
    }
}