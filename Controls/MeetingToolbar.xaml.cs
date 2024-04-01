namespace DemyAI.Controls;

public partial class MeetingToolbar : ContentView {
    public MeetingToolbar() {
        InitializeComponent();
    }

    public static readonly BindableProperty RoomNameProperty = BindableProperty.Create(
        nameof(RoomName), typeof(string), typeof(MeetingToolbar));

    public string RoomName {
        get => (string)GetValue(RoomNameProperty);
        set => SetValue(RoomNameProperty, value);
    }

    public static readonly BindableProperty TimeProperty = BindableProperty.Create(
        nameof(Time), typeof(string), typeof(MeetingToolbar));

    public string Time {
        get => (string)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }

    public static readonly BindableProperty VisibilityProperty = BindableProperty.Create(
        nameof(Visibility), typeof(bool), typeof(MeetingToolbar));

    public bool Visibility {
        get => (bool)GetValue(VisibilityProperty);
        set => SetValue(VisibilityProperty, value);
    }
}



