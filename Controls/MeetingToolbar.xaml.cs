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


    public static readonly BindableProperty ShowParticipantCmmandProperty = BindableProperty.Create(
        nameof(ShowParticipantCmmand), typeof(RelayCommand<object>), typeof(MeetingToolbar));

    public RelayCommand<object> ShowParticipantCmmand {
        get => (RelayCommand<object>)GetValue(ShowParticipantCmmandProperty);
        set => SetValue(ShowParticipantCmmandProperty, value);
    }


    public static readonly BindableProperty ParticipantsListProperty = BindableProperty.Create(
        nameof(ParticipantsList), typeof(object), typeof(MeetingToolbar));

    public object ParticipantsList {
        get => GetValue(ParticipantsListProperty);
        set => SetValue(ParticipantsListProperty, value);
    }


}



