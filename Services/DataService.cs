// Ignore Spelling: namespace DemyAI.Services; uid

namespace DemyAI.Services;

public class DataService<T> : IDataService<T> {
    private const string UID = "Uid";
    private const string ROLE = "Role";
    readonly FirebaseClient _client;

    public DataService() {
        _client = new FirebaseClient(Constants.DATABASE_URL);
    }

    public async Task<string> AddAsync(string nodeName, T newItem) {
        var obj = await _client.Child(nodeName).PostAsync(JsonSerializer.Serialize(newItem));
        return obj.Object;
    }


    public Task DeleteAsync(string NodeName, string uid) {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyCollection<FirebaseObject<T>>> GetAllAsync<T>(string nodeName) {
        var Objects = await _client.Child(nodeName).OnceAsync<T>();

        return Objects;
    }

    public async Task<ObservableCollection<T>> GetByRole<T>(string nodeName, string role) {

        var teachers = new ObservableCollection<T>();

        var objects = await GetAllAsync<T>(nodeName);

        // Iterate through each item in the Objects collection
        foreach(var items in objects) {

            // Get the Role property of the current item's object type
            var roleProperty = items.Object?.GetType().GetProperty(ROLE);

            if(roleProperty != null) {

                // Retrieve the value of the role property for the current object
                var roleValue = roleProperty.GetValue(items.Object);

                if(roleValue != null && roleValue.ToString() == role) {

                    teachers.Add(items.Object);
                }
            }
        }

        return teachers;
    }

    public async Task<T?> GetByUidAsync<T>(string nodeName, string uid) {
        var objects = await _client.Child(nodeName).OnceAsync<T>();

        // Iterate through each item in the Objects collection
        foreach(var item in objects) {

            // Get the Uid property of the current item's object type
            var uidProp = item.Object?.GetType().GetProperty(UID);

            // Check if the Uid property exists for the current object type
            if(uidProp != null) {

                // Retrieve the value of the Uid property for the current object
                var value = uidProp.GetValue(item.Object);

                // Check if the Uid property value matches the provided uid
                if(value != null && value.ToString() == uid) {

                    // If there's a match, return the object
                    return item.Object;
                }
            }
        }

        return default;
    }


    public Task UpdateAsync(string uid, T updatedItem) {
        throw new NotImplementedException();
    }

}