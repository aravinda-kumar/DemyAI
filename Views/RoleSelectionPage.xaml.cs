namespace DemyAI.Views;

public partial class RoleSelectionPage : ContentPage {
    public RoleSelectionPage(RoleSelectionPageViewModel roleSelectionPageViewModel) {
        InitializeComponent();
        BindingContext = roleSelectionPageViewModel;
    }
}