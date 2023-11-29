namespace DemyAI.Interfaces;
public interface IAuthenticationService {

    Task<User?> RegisterWithEmailAndPassword(string email, string password);

    Task<string> LoginWithStudentId(string id);

    Task<User?> LoginWithEmailAndPassword(string email, string password);

    void SignOut();
}
