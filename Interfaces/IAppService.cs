namespace DemyAI.Interfaces;
/// <summary>
/// Interface defining the contract for application-related services.
/// </summary>
public interface IAppService {

    Task NavigateTo(string pageName, bool isAnimated, Dictionary<string, object> obj);

    Task NavigateTo(string pageName, bool isAnimated);

    Task DisplayToast(string message, ToastDuration toastDuration, double fontSize);

    Task DisplayAlert(string title, string message, string cancelMessage);

    Task NavigateBack();
}
