namespace DemyAI.Views;

public partial class MyCoursesDetailPage : ContentPage {

    public MyCoursesDetailPage(MyCoursesDetailPageViewModel myCoursesDetailPageViewModel) {
        InitializeComponent();
        BindingContext = myCoursesDetailPageViewModel;
    }
}