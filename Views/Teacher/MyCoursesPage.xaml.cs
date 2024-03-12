namespace DemyAI.Views;

public partial class MyCoursesPage : ContentPage {
    public MyCoursesPage(MyCoursesPageViewModel myCoursesPageViewModel) {
        InitializeComponent();
        BindingContext = myCoursesPageViewModel;
    }
}