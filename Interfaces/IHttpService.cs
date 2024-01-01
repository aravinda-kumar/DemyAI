namespace DemyAI.Interfaces;
/// <summary>
/// Interface defining the contract for an HTTP service.
/// </summary>
public interface IHttpService {
    /// <summary>
    /// Performs an HTTP GET request asynchronously and retrieves data of type T from the specified URL.
    /// </summary>
    /// <typeparam name="T">Type of data to retrieve.</typeparam>
    /// <param name="url">URL from which to fetch the data.</param>
    /// <returns>Task returning nullable data of type T retrieved from the specified URL.</returns>
    Task<T?> GetAsync<T>(string url);

    Task<HttpResponseMessage?> PostAsync(string url, HttpContent content, string key);
}
