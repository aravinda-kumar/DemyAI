namespace DemyAI.Services;
public class AppService : IAppService {

    public async Task DisplayAlert(string title, string message, string cancelMessage) {
        await Shell.Current.DisplayAlert(title, message, cancelMessage);
    }

    public async Task DisplayAlert(string message) {
        await Shell.Current.DisplayAlert("Error", message, "OK");
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

    public async Task NavigateBack() {
        await Shell.Current.GoToAsync("..");
    }

    public async Task<bool> DisplayAlert(string title, string message, string positive, string negative) {
        var answer = await Shell.Current.DisplayAlert(title, message, positive, negative);
        return answer;
    }
}
