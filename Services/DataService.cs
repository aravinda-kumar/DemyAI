namespace DemyAI.Services;
public class DataService<T> : IDataService<T> {

    readonly FirebaseClient _client;

    public DataService() {
        _client = new FirebaseClient(Constants.DATABASE_URL);
    }

    public async Task<string> AddAsync(string nodeName, T newItem) {
        var obj = await _client.Child(nodeName).PostAsync(JsonSerializer.Serialize(newItem));
        return obj.Key;
    }

    public Task DeleteAsync(string key) {
        throw new NotImplementedException();
    }

    public Task<T> GetByKeyAsync(string key) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string key, T updatedItem) {
        throw new NotImplementedException();
    }
}
