namespace DemyAI.Controls;

public partial class CourseTemplate : ContentView {
    public CourseTemplate() {
        InitializeComponent();
    }

    public static readonly BindableProperty DataProperty = BindableProperty.Create(
      nameof(Data), typeof(IEnumerable), typeof(CourseTemplate));

    public IEnumerable Data {
        get => (IEnumerable)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }


    public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
        nameof(SelectedItem), typeof(DemyUser),
        typeof(CourseTemplate), null, BindingMode.TwoWay);

    public DemyUser SelectedItem {
        get => (DemyUser)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }
}