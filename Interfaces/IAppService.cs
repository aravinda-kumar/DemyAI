namespace DemyAI.Interfaces;
/// <summary>
/// Interface defining the contract for application-related services.
/// </summary>
public interface IAppService {
    /// <summary>
    /// Navigates to a specified page with animation and optional parameters.
    /// </summary>
    /// <param name="pageName">Name of the page to navigate to.</param>
    /// <param name="isAnimated">Boolean indicating if navigation includes animation.</param>
    /// <param name="obj">Dictionary of optional parameters for the navigation.</param>
    /// <returns>Task representing the asynchronous operation.</returns>
    /// 
    Task NavigateTo(string pageName, bool isAnimated, Dictionary<string, object> obj);

    /// <summary>
    /// Navigates to a specified page with animation.
    /// </summary>
    /// <param name="pageName">Name of the page to navigate to.</param>
    /// <param name="isAnimated">Boolean indicating if navigation includes animation.</param>
    /// <returns>Task representing the asynchronous operation.</returns>
    /// 
    Task NavigateTo(string pageName, bool isAnimated);

    /// <summary>
    /// Displays a toast message for a specified duration and font size.
    /// </summary>
    /// <param name="message">Message to be displayed in the toast.</param>
    /// <param name="toastDuration">Duration for displaying the toast message.</param>
    /// <param name="fontSize">Font size for the toast message.</param>
    /// <returns>Task representing the asynchronous operation.</returns>

    Task DisplayToast(string message, ToastDuration toastDuration, double fontSize);

    /// <summary>
    /// Displays an alert with an error message, a message, and a cancel option.
    /// </summary>
    /// <param name="title">Title of the alert to be displayed in the alert.</param>
    /// <param name="message">Message to be displayed in the alert.</param>
    /// <param name="cancelMessage">Text for the cancel option in the alert.</param>
    /// <returns>Task representing the asynchronous operation.</returns>
    /// 
    Task DisplayAlert(string title, string message, string cancelMessage);
}
