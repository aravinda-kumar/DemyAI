namespace DemyAI.Controls;

public partial class SharingPopUp : ContentView {
    public SharingPopUp() {
        InitializeComponent();
    }

    public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(
        nameof(IsOpen), typeof(bool), typeof(SharingPopUp),
        false, BindingMode.TwoWay);

    public bool IsOpen {
        get => (bool)GetValue(IsOpenProperty);
        set => SetValue(IsOpenProperty, value);
    }


    public static readonly BindableProperty RoomNameProperty = BindableProperty.Create(
        nameof(RoomName), typeof(string), typeof(SharingPopUp));

    public string RoomName {
        get => (string)GetValue(RoomNameProperty);
        set => SetValue(RoomNameProperty, value);
    }

    public static readonly BindableProperty ShareUrlProperty = BindableProperty.Create(
        nameof(ShareUrl), typeof(IRelayCommand), typeof(SharingPopUp));

    public IRelayCommand ShareUrl {
        get => (IRelayCommand)GetValue(ShareUrlProperty);
        set => SetValue(ShareUrlProperty, value);
    }


    public static readonly BindableProperty CopyURLProperty = BindableProperty.Create(
        nameof(CopyURL), typeof(IRelayCommand), typeof(SharingPopUp));

    public IRelayCommand CopyURL {
        get => (IRelayCommand)GetValue(CopyURLProperty);
        set => SetValue(CopyURLProperty, value);
    }

}