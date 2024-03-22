namespace DemyAI.Services;

public class DataService<T> : IDataService<T> {

    readonly FirebaseClient _client;

    public DataService() {
        _client = new FirebaseClient(Constants.DATABASE_URL);
    }

    public async Task<string> AddAsync<T>(string nodeName,
        T newItem, string? customUID = null) {
        if (!string.IsNullOrEmpty(customUID)) {
            await _client.Child(nodeName).Child(customUID).PostAsync(newItem);
            return customUID;
        }

        var obj = await _client.Child(nodeName).PostAsync(newItem);

        return obj.Key;
    }

    public async Task<List<DemyUser>> GetByRole(string role) {
        var usersCollection = await GetAllAsync<DemyUser>(
            Constants.USERS);

        var filteredData = usersCollection.Where(
            u => u.CurrentRole == role).ToList();

        return filteredData;
    }

    public async Task<T?> GetByEmailAsync(string nodeName, string email) {

        var objects = await _client.Child(nodeName).OnceAsync<T>();

        // Iterate through each item in the Objects collection
        foreach (var item in objects) {

            // Get the Uid property of the current item's object type
            var uidProp = item.Object?.GetType().GetProperty(Constants.EMAIL);

            // Check if the Uid property exists for the current object type
            if (uidProp is not null) {

                // Retrieve the value of the Uid property for the current object
                var value = uidProp.GetValue(item.Object);

                // Check if the Uid property value matches the provided uid
                if (value != null && value.ToString() == email) {

                    // If there's a match, return the object
                    return item.Object;
                }
            }
        }

        return default;
    }

    public Task DeleteAsync(string NodeName, string uid) {
        throw new NotImplementedException();
    }

    public async Task<ObservableCollection<T>> GetAllAsync<T>(string nodeName) {

        var colletion = new ObservableCollection<T>();

        var firebaseObjects = await _client.Child(nodeName)
            .OnceAsync<T>();

        foreach (var item in firebaseObjects) {
            colletion.Add(item.Object);
        }

        return colletion;
    }

    public async Task UpdateAsync<T>(string nodeName, string uid,
        string propertyValue, string propertyName) {

        await _client.Child(nodeName)
            .Child(uid).PatchAsync($"{{ \"{propertyName}\" : \"{propertyValue}\" }}");
    }

    public async Task UpdateAsync<T>(string nodeName, string uid, T newData) {
        // Assuming "nodeName" represents the parent node where rooms are stored
        await _client
            .Child(nodeName)
            .Child(uid)
            .PutAsync(newData);
    }

    public void ListenForChanges<T>(string nodeName, string uid, Action<T> onDataChanged) {
        var observable = _client.Child(nodeName).Child(uid).AsObservable<T>()
            .Subscribe(updatedData => {
                // Invoke the provided action with the updated data
                onDataChanged?.Invoke(updatedData.Object);

                Debug.WriteLine("Is time to uipdate");
            });
    }
}
