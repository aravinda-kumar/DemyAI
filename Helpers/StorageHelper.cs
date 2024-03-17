
namespace DemyAI.Helpers;
public static class StorageHelper<T> {

    public static async Task<T?> GetObjFromStorageAsync() {

        var data = await SecureStorage.GetAsync(Constants.LOGGED_USER)!;
        if(data is not null) {
            var obj = JsonSerializer.Deserialize<T>(data!);
            return obj;
        }

        return default;
    }

    public static void StoreObjectToStorage(T data, ISecureStorage storage) {

        if(data is not null) {

            var json = JsonSerializer.Serialize(data);

            storage.SetAsync(Constants.LOGGED_USER, json);

        }
    }
}
