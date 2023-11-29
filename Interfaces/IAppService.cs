namespace DemyAI.Interfaces {
    public interface IAppService {

        Task NavigateTo(string pageName, bool isAnimated, Dictionary<string, object> obj);

        Task NavigateTo(string pageName, bool isAnimated);

        Task DisplayToast(string message, ToastDuration toastDuration, double fontSize);

        Task DisplayAlert(string errorMessage, string message, string cancelMessage);

    }
}
