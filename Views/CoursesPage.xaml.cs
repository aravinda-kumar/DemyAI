namespace DemyAI.Views;

public partial class CoursesPage : ContentPage {
    public CoursesPage(CoursesPageViewModel coursesPageViewModel) {
        InitializeComponent();
        BindingContext = coursesPageViewModel;
    }
}