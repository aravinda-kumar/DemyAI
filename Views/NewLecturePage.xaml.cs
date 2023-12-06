namespace DemyAI.Views;

public partial class NewLecturePage : ContentPage {
    public NewLecturePage(NewLecturePageViewModel lecturePageViewModel) {
        InitializeComponent();

        BindingContext = lecturePageViewModel;
    }
}