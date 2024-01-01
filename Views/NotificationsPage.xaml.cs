namespace DemyAI.Views;

public partial class NotificationsPage : ContentPage {
    public NotificationsPage(NotificationsPageViewModel notificationsPageViewModel) {
        InitializeComponent();
        BindingContext = notificationsPageViewModel;
    }
}