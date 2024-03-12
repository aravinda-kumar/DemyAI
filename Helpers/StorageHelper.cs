
namespace DemyAI.Helpers;
public static class StorageHelper<T> {

    public static async Task<T?> GetJsonFromStorageAsync(string data = "") {

        if(string.IsNullOrWhiteSpace(data)) {

            data = await SecureStorage.GetAsync(Constants.LOGGED_USER)!;
        }

        var obj = JsonSerializer.Deserialize<T>(data);

        return obj;
    }
}
