using User = Firebase.Auth.User;

namespace DemyAI.Services;

public class AuthenticationService(FirebaseAuthClient firebaseAuthClient, IAppService appService) : IAuthenticationService {

    public async Task<User?> GetLoggedInUser() {

        try {

            return firebaseAuthClient.User;

        } catch (Exception e) {

            await appService.DisplayAlert("error", e.Message, "OK");
            return default;
        }
    }

    public async Task<User?> LoginWithEmailAndPassword(string email, string password) {

        try {

            var user = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(email, password);
            return user.User;

        } catch (FirebaseAuthException ex) {

            GetHumanRedeableMesage(ex.Reason);

            return default;

        }

    }

    public Task<string> LoginWithStudentId(string id) {
        throw new NotImplementedException();
    }

    public async Task<User?> RegisterWithEmailAndPassword(string email, string password, string name) {

        try {

            var user = await firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password, name);
            return user.User;

        } catch (FirebaseAuthException ex) {

            GetHumanRedeableMesage(ex.Reason);

            return null;
        }

    }

    public void SignOut() {
        firebaseAuthClient.SignOut();
    }

    private void GetHumanRedeableMesage(AuthErrorReason reason) {

        switch (reason) {
            case AuthErrorReason.Undefined:
                appService.DisplayAlert("Request didn't even complete, possibly due to network issue.");
                break;
            case AuthErrorReason.Unknown:
                appService.DisplayAlert("Invalid login credentials");
                break;
            case AuthErrorReason.OperationNotAllowed:
                appService.DisplayAlert("The sign in method is not enabled.");
                break;
            case AuthErrorReason.UserDisabled:
                appService.DisplayAlert("The user was disabled and is not granted access anymore");
                break;
            case AuthErrorReason.UserNotFound:
                appService.DisplayAlert("The user was not found");
                break;
            case AuthErrorReason.InvalidProviderID:
                appService.DisplayAlert("Third-party Auth Providers: PostBody does not contain or contains invalid Authentication Provider string.");
                break;
            case AuthErrorReason.InvalidAccessToken:
                appService.DisplayAlert("Third-party Auth Providers: PostBody does not contain or contains invalid Access Token string obtained from Auth Provider.");
                break;
            case AuthErrorReason.LoginCredentialsTooOld:
                appService.DisplayAlert("Changes to user's account has been made since last log in. User needs to login again.");
                break;
            case AuthErrorReason.MissingRequestURI:
                appService.DisplayAlert("Third-party Auth Providers: Request does not contain a value for parameter: requestUri.");
                break;
            case AuthErrorReason.SystemError:
                appService.DisplayAlert("Third-party Auth Providers: Request does not contain a value for parameter: postBody.");
                break;
            case AuthErrorReason.InvalidEmailAddress:
                appService.DisplayAlert("Email/Password Authentication: Email address is not in valid format.");
                break;
            case AuthErrorReason.MissingPassword:
                appService.DisplayAlert("Email/Password Authentication: No password provided!");
                break;
            case AuthErrorReason.WeakPassword:
                appService.DisplayAlert("Email/Password Signup: Password must be more than 6 characters. This error could also be caused by attempting to create a user account using Set Account Info without supplying a password for the new user.");
                break;
            case AuthErrorReason.EmailExists:
                appService.DisplayAlert("Email/Password Signup: Email address already connected to another account. This error could also be caused by attempting to create a user account using Set Account Info and an email address already linked to another account.");
                break;
            case AuthErrorReason.MissingEmail:
                appService.DisplayAlert("Email/Password Signin: No email provided! This error could also be caused by attempting to create a user account using Set Account Info without supplying an email for the new user.");
                break;
            case AuthErrorReason.UnknownEmailAddress:
                appService.DisplayAlert("Email/Password Signin: No user with a matching email address is registered.");
                break;
            case AuthErrorReason.WrongPassword:
                appService.DisplayAlert("Email/Password Signin: The supplied password is not valid for the email address.");
                break;
            case AuthErrorReason.TooManyAttemptsTryLater:
                appService.DisplayAlert("Email/Password Signin: Too many password login attempts have been made. Try again later.");
                break;
            case AuthErrorReason.MissingRequestType:
                appService.DisplayAlert("Password Recovery: Request does not contain a value for parameter: requestType or supplied value is invalid.");
                break;
            case AuthErrorReason.ResetPasswordExceedLimit:
                appService.DisplayAlert("Password Recovery: Reset password limit exceeded.");
                break;
            case AuthErrorReason.InvalidIDToken:
                appService.DisplayAlert("Account Linking: Authenticated User ID Token is invalid!");
                break;
            case AuthErrorReason.MissingIdentifier:
                appService.DisplayAlert("Linked Accounts: Request does not contain a value for parameter: identifier.");
                break;
            case AuthErrorReason.InvalidIdentifier:
                appService.DisplayAlert("Linked Accounts: Request contains an invalid value for parameter: identifier.");
                break;
            case AuthErrorReason.AlreadyLinked:
                appService.DisplayAlert("Linked accounts: Account to link has already been linked.");
                break;
            case AuthErrorReason.InvalidApiKey:
                appService.DisplayAlert("Specified API key is not valid.");
                break;
            case AuthErrorReason.AccountExistsWithDifferentCredential:
                appService.DisplayAlert("The email user tried to sign in with is already registered under a different provider.");
                break;
            default:
                break;
        }
    }
}
