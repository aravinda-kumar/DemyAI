namespace DemyAI.Views;

public partial class NewTestPage : ContentPage {
    public NewTestPage(NewTestPageViewMode newTestPageViewMode) {
        InitializeComponent();
        BindingContext = newTestPageViewMode;
    }
}