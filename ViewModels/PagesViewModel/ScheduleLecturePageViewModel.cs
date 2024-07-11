namespace DemyAI.ViewModels;

public partial class ScheduleLecturePageViewModel(IAppService appService,
    IHttpService httpService,
    IDataService<DemyUser> dataService,
    IMeetingService meetingServic) : BaseViewModel {


    [ObservableProperty]
    bool isDateTimeZonePickerVisible;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ButtonText), nameof(IsButtonEnabled))]
    DateTime? selectedDateTime = null;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsButtonEnabled))]
    String selectedTimeZone;

    [ObservableProperty]
    public List<string> timezones;

    public string ButtonText => SelectedDateTime.HasValue ? $"Schedule for {SelectedDateTime:MMMM dd yyyy 'at' HH:mm}" : "";

    public bool IsButtonEnabled => SelectedDateTime.HasValue && !string.IsNullOrEmpty(SelectedTimeZone);

    [RelayCommand]
    void Appearing() {
        Timezones = TimeZoneService.GetTimeZones();
    }

    [RelayCommand]
    void OpenDateTimePicker() {
        IsDateTimeZonePickerVisible = true;
    }

    [RelayCommand]
    void OkButtonClicked() {
        IsDateTimeZonePickerVisible = false;
    }

    [RelayCommand]
    void CancelButtonClicked() {
        IsDateTimeZonePickerVisible = false;
    }

    [RelayCommand]
    async Task ScheduleButtonClicked() {

        if (appService != null) {
            await appService.DisplayToast($"You have a meeting on {SelectedDateTime}",
                ToastDuration.Short, 14);
        }
    }
}
