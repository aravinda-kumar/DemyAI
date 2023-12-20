namespace DemyAI.Views;

public partial class ManagePage : ContentPage {
    public ManagePage(ManagePageViewModel managePageViewModel) {
        InitializeComponent();
        BindingContext = managePageViewModel;
    }
}