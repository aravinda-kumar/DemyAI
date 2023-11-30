namespace DemyAI.Interfaces;
public interface IDataService<T> {

    Task<T?> GetByKeyAsync<T>(string nodeName, string key);
    Task<string> AddAsync(string nodeName, T newItem);
    Task UpdateAsync(string key, T updatedItem);
    Task DeleteAsync(string key);

}
