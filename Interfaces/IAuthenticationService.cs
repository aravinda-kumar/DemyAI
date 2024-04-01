using User = Firebase.Auth.User;

namespace DemyAI.Interfaces;

/// <summary>
/// Interface defining the contract for authentication-related services.
/// </summary>
public interface IAuthenticationService {

    Task<User?> RegisterWithEmailAndPassword(string email, string password, string DisplayName);

    Task<string> LoginWithStudentId(string id);

    Task<User?> LoginWithEmailAndPassword(string email, string password);

    Task<User?> GetLoggedInUser();

    Task ResetEmailPasswordAsync(string email);

    void SignOut();
}
