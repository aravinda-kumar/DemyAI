namespace DemyAI.Views;

public partial class RegisterStudentPage : ContentPage {
    public RegisterStudentPage(RegisterStudentPageViewModel registerStudentPageViewModel) {
        InitializeComponent();
        BindingContext = registerStudentPageViewModel;
    }
}