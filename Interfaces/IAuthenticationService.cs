using User = Firebase.Auth.User;

namespace DemyAI.Interfaces;

/// <summary>
/// Interface defining the contract for authentication-related services.
/// </summary>
public interface IAuthenticationService {
    /// <summary>
    /// Registers a new user with email and password.
    /// </summary>
    /// <param name="email">DeemyUser's email address.</param>
    /// <param name="password">DeemyUser's password.</param>
    /// <returns>Task returning a nullable DeemyUser object upon successful registration.</returns>

    Task<User?> RegisterWithEmailAndPassword(string email, string password, string DisplayName);

    /// <summary>
    /// Logs in using a student ID.
    /// </summary>
    /// <param name="id">Student ID for login.</param>
    /// <returns>Task returning a string upon successful login.</returns>

    Task<string> LoginWithStudentId(string id);

    /// <summary>
    /// Logs in a user with email and password.
    /// </summary>
    /// <param name="email">DeemyUser's email address.</param>
    /// <param name="password">DeemyUser's password.</param>
    /// <returns>Task returning a nullable DeemyUser object upon successful login.</returns>

    Task<User?> LoginWithEmailAndPassword(string email, string password);

    /// <summary>
    /// Retrieves the currently logged-in user.
    /// </summary>
    /// <returns>Task returning a nullable DeemyUser object representing the currently logged-in user.</returns>

    Task<User?> GetLoggedInUser();

    /// <summary>
    /// Signs out the currently logged-in user.
    /// </summary>

    void SignOut();
}
