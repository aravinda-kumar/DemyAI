namespace DemyAI.Services;

public class HttpService(IAppService appService, HttpClient httpClient) : IHttpService {

    public async Task<T?> GetAsync<T>(string url) {

        try {

            var respose = await httpClient.GetAsync(url);
            if (respose != null && respose.IsSuccessStatusCode) {

                var data = await respose.Content.ReadFromJsonAsync<T>();
                return data!;
            }

        } catch (Exception e) {

            await appService.DisplayAlert("Error", e.Message, "OK");
        }

        return default;
    }
}
