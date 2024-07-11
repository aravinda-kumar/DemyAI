namespace DemyAI.Controls;

public partial class DateTimeZonePicker : ContentView {

    public DateTimeZonePicker() {
        InitializeComponent();
    }


    public static readonly BindableProperty OpenDateTimePickerCommndProperty = BindableProperty.Create(
    nameof(OpenDateTimePickerCommnd), typeof(RelayCommand), typeof(DateTimeZonePicker));

    public RelayCommand OpenDateTimePickerCommnd {
        get => (RelayCommand)GetValue(OpenDateTimePickerCommndProperty);
        set => SetValue(OpenDateTimePickerCommndProperty, value);
    }

    public static readonly BindableProperty IsDateTimePickerVisibleProperty = BindableProperty.Create(
    nameof(IsDateTimePickerVisible), typeof(bool), typeof(DateTimeZonePicker));

    public bool IsDateTimePickerVisible {
        get => (bool)GetValue(IsDateTimePickerVisibleProperty);
        set => SetValue(IsDateTimePickerVisibleProperty, value);
    }


    public static readonly BindableProperty TimezonesProperty = BindableProperty.Create(
        nameof(Timezones), typeof(List<string>), typeof(DateTimeZonePicker));

    public List<string> Timezones {
        get => (List<string>)GetValue(TimezonesProperty);
        set => SetValue(TimezonesProperty, value);
    }

    public static readonly BindableProperty SelectedDateTimeProperty = BindableProperty.Create(
      nameof(SelectedDateTime), typeof(DateTime), typeof(DateTimeZonePicker), null,
      BindingMode.TwoWay);

    public DateTime SelectedDateTime {
        get => (DateTime)GetValue(SelectedDateTimeProperty);
        set => SetValue(SelectedDateTimeProperty, value);
    }

    public static readonly BindableProperty SelectedTimeZoneProperty = BindableProperty.Create(
        nameof(SelectedTimeZone), typeof(string), typeof(DateTimeZonePicker), null,
        BindingMode.TwoWay);

    public string SelectedTimeZone {
        get => (string)GetValue(SelectedTimeZoneProperty);
        set => SetValue(SelectedTimeZoneProperty, value);
    }

    public static readonly BindableProperty OkButtonClickedCommandProperty = BindableProperty.Create(
        nameof(OkButtonClickedCommand), typeof(RelayCommand), typeof(DateTimeZonePicker));

    public RelayCommand OkButtonClickedCommand {
        get => (RelayCommand)GetValue(OkButtonClickedCommandProperty);
        set => SetValue(OkButtonClickedCommandProperty, value);
    }


    public static readonly BindableProperty CancelButtonClickedCommandProperty = BindableProperty.Create(
        nameof(CancelButtonClickedCommand), typeof(RelayCommand), typeof(DateTimeZonePicker));

    public RelayCommand CancelButtonClickedCommand {
        get => (RelayCommand)GetValue(CancelButtonClickedCommandProperty);
        set => SetValue(CancelButtonClickedCommandProperty, value);
    }

    public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(
       nameof(ButtonText), typeof(string), typeof(DateTimeZonePicker));

    public string ButtonText {
        get => (string)GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    public static readonly BindableProperty IsButtonEnabledProperty = BindableProperty.Create(
        nameof(IsButtonEnabled), typeof(bool), typeof(DateTimeZonePicker));

    public bool IsButtonEnabled {
        get => (bool)GetValue(IsButtonEnabledProperty);
        set => SetValue(IsButtonEnabledProperty, value);
    }


    public static readonly BindableProperty ButtnClickCommandProperty = BindableProperty.Create(
        nameof(ButtnClickCommand), typeof(RelayCommand), typeof(DateTimeZonePicker));

    public RelayCommand ButtnClickCommand {
        get => (RelayCommand)GetValue(ButtnClickCommandProperty);
        set => SetValue(ButtnClickCommandProperty, value);
    }

}