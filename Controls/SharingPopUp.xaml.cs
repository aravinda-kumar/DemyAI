namespace DemyAI.Controls;

public partial class SharingPopUp : ContentView {
    public SharingPopUp() {
        InitializeComponent();
    }

    public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(
        nameof(IsOpen), typeof(bool), typeof(SharingPopUp));

    public bool IsOpen {
        get => (bool)GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }


    public static readonly BindableProperty RoomLinkProperty = BindableProperty.Create(
        nameof(RoomLink), typeof(string), typeof(SharingPopUp));

    public string RoomLink {
        get => (string)GetValue(RoomLinkProperty);
        set => SetValue(RoomLinkProperty, value);
    }

    public static readonly BindableProperty CopyRoomURLCommandProperty = BindableProperty.Create(
        nameof(CopyRoomURLCommand), typeof(IRelayCommand), typeof(SharingPopUp));

    public IRelayCommand CopyRoomURLCommand {
        get => (IRelayCommand)GetValue(CopyRoomURLCommandProperty);
        set => SetValue(CopyRoomURLCommandProperty, value);
    }
}