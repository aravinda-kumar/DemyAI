namespace DemyAI.Interfaces;
/// <summary>
/// Interface defining the contract for a data service that operates on entities of type T.
/// </summary>
/// <typeparam name="T">Type of the entity.</typeparam>
public interface IDataService<T> {
    /// <summary>
    /// Retrieves an entity by its UID asynchronously.
    /// </summary>
    /// <param name="nodeName">UID of the node where the entity is located.</param>
    /// <param name="uid">UID (Unique Identifier) of the entity to retrieve.</param>
    /// <returns>Task returning a nullable entity object of type T.</returns>

    Task<T?> GetByUidAsync<T>(string nodeName, string uid);

    Task<T?> GetByNameAsync<T>(string nodeName);

    // TODO Create comment

    Task<ObservableCollection<T>> GetByRole<T>(string nodeName, string role);

    /// <summary>
    /// Retrieves all entities of type T from the specified node asynchronously.
    /// </summary>
    /// <param name="nodeNem">ROLE of the node from which to retrieve entities.</param>
    /// <returns>Task returning a read-only collection of FirebaseObject containing entities of type T.</returns>

    Task<IReadOnlyCollection<FirebaseObject<T>>> GetAllAsync<T>(string nodeName);

    /// <summary>
    /// Adds a new item of type T to the specified node asynchronously.
    /// </summary>
    /// <param name="nodeName">ROLE of the node where the new item will be added.</param>
    /// <param name="newItem">Item of type T to be added.</param>
    /// <returns>Task returning the UID (Unique Identifier) of the newly added item as a string.</returns>

    Task<string> AddAsync<T>(string nodeName, T newItem);

    /// <summary>
    /// Updates an existing item of type T identified by its UID asynchronously.
    /// </summary>
    /// <param name="uid">UID (Unique Identifier) of the item to update.</param>
    /// <param name="updatedItem">Updated item of type T.</param>
    /// <returns>Task representing the completion of the update operation.</returns>

    Task UpdateAsync<T>(string nodeName, string Key, string propertyValue, string propertyName);

    /// <summary>
    /// Deletes an item identified by its UID asynchronously.
    /// </summary>
    /// <param name="uid">UID (Unique Identifier) of the item to delete.</param>
    /// <returns>Task representing the completion of the delete operation.</returns>
    Task DeleteAsync(string NodeName, string uid);

    Task<bool> UpdateRegistrationCourseVisibility();
}
