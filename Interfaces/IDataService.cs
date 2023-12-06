namespace DemyAI.Interfaces;
public interface IDataService<T> {

    Task<T?> GetByUidAsync<T>(string nodeName, string uid);

    Task<IReadOnlyCollection<FirebaseObject<T>>> GetAllAsync<T>(string nodeNem);

    Task<string> AddAsync(string nodeName, T newItem);

    Task UpdateAsync(string uid, T updatedItem);

    Task DeleteAsync(string uid);


}
