// Ignore Spelling: namespace DemyAI.Services; uid

using Firebase.Database.Query;
namespace DemyAI.Services;

public class DataService<T> : IDataService<T> {
    private const string UID = "Uid";
    private const string ROLE = "Role";
    private const string Courses = "Courses";
    readonly FirebaseClient _client;

    public DataService() {
        _client = new FirebaseClient(Constants.DATABASE_URL);
    }

    public async Task<string> AddAsync<T>(string nodeName, T newItem) {
        var obj = await _client.Child(nodeName).PostAsync(JsonSerializer.Serialize(newItem));
        return obj.Key;
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

            if(roleProperty is not null) {

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
            if(uidProp is not null) {

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

    public async Task<T?> GetByNameAsync<T>(string nodeName) {

        var objectList = await _client.Child(nodeName).OnceAsync<T>();

        foreach(var item in objectList) {

            var nameProperty = item.Object?.GetType().GetProperty("Name");

            if(nameProperty is not null) {

                var val = nameProperty.GetValue(item.Object);

                if(val is not null && val.ToString() == "Name") {

                    return item.Object;
                }
            }
        }

        return default;
    }

    public async Task UpdateAsync<T>(string nodeName, string Key, string propertyValue, string propertyName) {

        await _client.Child(nodeName).Child(Key).PatchAsync($"{{ \"{propertyName}\" : \"{propertyValue}\" }}");
    }

    public async Task<bool> UpdateRegistrationCourseVisibility() {

        var todaysdate = DateTime.Now;

        var corseslist = await _client.Child(Courses).OnceAsync<Course>();

        foreach(var item in corseslist) {

            var endRegitrationDate = DateTime.Parse(item.Object.EndRegistrationDate).Date;

            if(todaysdate < endRegitrationDate) {
                return true;
            }
        }

        return false;
    }
}