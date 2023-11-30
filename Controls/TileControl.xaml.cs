namespace DemyAI.Controls;

public partial class TileControl : TemplatedView {

    public static readonly BindableProperty FooterTextProperty = BindableProperty.Create(
        nameof(HeaderText),  typeof(string), typeof(TileControl), default(string));

    public static readonly BindableProperty BoxColorProperty = BindableProperty.Create(
        nameof(BoxColor), typeof(Color), typeof(TileControl), Colors.LightGray);

    public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
        nameof(ImageSource), typeof(ImageSource), typeof(TileControl), default(ImageSource));

    public string HeaderText {

        get => (string)GetValue(FooterTextProperty);
        set => SetValue(FooterTextProperty, value);
    }

    public Color BoxColor {

        get => (Color)GetValue(BoxColorProperty);
        set => SetValue(BoxColorProperty, value);
    }
    
    public ImageSource ImageSource {

        get => (ImageSource)GetValue(ImageSourceProperty); 
        set => SetValue(ImageSourceProperty, value);
    }
}