namespace DemyAI.Controls;

public partial class UserTemplate : ContentView {
    public UserTemplate() {
        InitializeComponent();
    }


    public static readonly BindableProperty DataProperty = BindableProperty.Create(
        nameof(Data), typeof(IEnumerable), typeof(UserTemplate));

    public IEnumerable Data {
        get => (IEnumerable)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }


    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem), typeof(DemyUser),
        typeof(UserTemplate), null, BindingMode.TwoWay);

    public DemyUser SelectedItem {
        get => (DemyUser)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }


    public static readonly BindableProperty TexBoxHintTextProperty = BindableProperty.Create(
        nameof(TexBoxHintText), typeof(string), typeof(UserTemplate));

    public string TexBoxHintText {
        get => (string)GetValue(TexBoxHintTextProperty);
        set => SetValue(TexBoxHintTextProperty, value);
    }


    public static readonly BindableProperty PlaceHolderTextProperty = BindableProperty.Create(
        nameof(PlaceHolderText), typeof(string), typeof(UserTemplate));

    public string PlaceHolderText {
        get => (string)GetValue(PlaceHolderTextProperty);
        set => SetValue(PlaceHolderTextProperty, value);
    }

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
    nameof(ImageSource), typeof(ImageSource), typeof(UserTemplate));

    public ImageSource ImageSource {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
}