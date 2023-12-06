namespace DemyAI.Controls;

public partial class TileControl : ContentView {

    public TileControl() {
        InitializeComponent();
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(title), typeof(string), typeof(TileControl), default(string));

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(Color), typeof(Color), typeof(TileControl), Colors.LightGray);

    public static readonly BindableProperty ImageProperty = BindableProperty.Create(
        nameof(Image), typeof(ImageSource), typeof(TileControl), default(ImageSource));

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command), typeof(RelayCommand), typeof(TileControl));

    public string title {

        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Color Color {

        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public ImageSource Image {

        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public RelayCommand Command {
        get => (RelayCommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
}