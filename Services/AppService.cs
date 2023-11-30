namespace DemyAI.Services;
public class AppService : IAppService {
    public async Task DisplayAlert(string errorMessage, string message, string cancelMessage) {
        await Shell.Current.DisplayAlert(errorMessage, message, cancelMessage);
    }

    public async Task DisplayToast(string message, ToastDuration toastDuration, double fontSize) {
        var toast = Toast.Make(message, toastDuration, fontSize);
        await toast.Show();
    }

    public async Task NavigateTo(string pageName, bool isAnimated, Dictionary<string, object> obj) {
        await Shell.Current.GoToAsync(pageName, isAnimated, obj);
    }

    public async Task NavigateTo(string pageName, bool isAnimated) {
        await Shell.Current.GoToAsync(pageName, isAnimated);
    }
}
