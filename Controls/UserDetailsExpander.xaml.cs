namespace DemyAI.Controls;

public partial class UserDetailsExpander : ContentView {
    public UserDetailsExpander() {
        InitializeComponent();
    }


    public static readonly BindableProperty PageTitleProperty = BindableProperty.Create(
        nameof(PageTitle), typeof(string), typeof(UserDetailsExpander));

    public string PageTitle {
        get => (string)GetValue(PageTitleProperty);
        set => SetValue(PageTitleProperty, value);
    }


    public static readonly BindableProperty HintProperty = BindableProperty.Create(
        nameof(Hint), typeof(string), typeof(UserDetailsExpander));

    public string Hint {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public static readonly BindableProperty RoomNameProperty = BindableProperty.Create(
        nameof(RoomName), typeof(string), typeof(UserDetailsExpander), string.Empty,
        BindingMode.TwoWay);

    public string RoomName {
        get => (string)GetValue(RoomNameProperty);
        set => SetValue(RoomNameProperty, value);
    }


    public static readonly BindableProperty UsersProperty = BindableProperty.Create(
        nameof(Users), typeof(IEnumerable), typeof(UserDetailsExpander));

    public IEnumerable Users {
        get => (IEnumerable)GetValue(UsersProperty);
        set => SetValue(UsersProperty, value);
    }

    public static readonly BindableProperty HandleCheckBoxCommandProperty = BindableProperty.Create(
        nameof(HandleCheckBoxCommand), typeof(RelayCommand), typeof(UserDetailsExpander));

    public RelayCommand HandleCheckBoxCommand {
        get => (RelayCommand)GetValue(HandleCheckBoxCommandProperty);
        set => SetValue(HandleCheckBoxCommandProperty, value);
    }
}