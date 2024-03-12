namespace DemyAI.Views;

public partial class ManageCoursePage : ContentPage {
    public ManageCoursePage(ManageCoursePageViewModel manageCoursePageViewModel) {
        InitializeComponent();
        BindingContext = manageCoursePageViewModel;
    }
}