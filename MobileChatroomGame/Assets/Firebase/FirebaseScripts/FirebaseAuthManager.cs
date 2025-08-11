using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class FirebaseAuthManager : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    [Space]
    [Header("Login")]
    public InputField emailLoginField;
    public InputField passwordLoginField;

    [Space]
    [Header("Registration")]
    public InputField nameRegisterField;
    public InputField emailRegisterField;
    public InputField passwordRegisterField;
    public InputField confirmPasswordRegisterField;

    private void awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all firebase dependencies: " + dependencyStatus);
            }
        });
    }

    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;

        auth.StateChange += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (authCurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserID);
            }

            user = auth.CurrentUser;

            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserID);
            }
        }
    }

    public void Login()
    {
        StartCoroutine(LoginAsync(emailLoginField.test, passwordLoginField.text));
    }

    private IEnumerator LoginAsync(string email, string password)
    {
        var loginTask = auth.SignInWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            Debug.LogError(loginTask.Exception);

            FirebaseException firebaseException = loginTask.Exception.GetBaseException() as firebaseException;
            AuthError authError = (AuthError)firebaseException.ErrorCode;

            string failedMessage = "Login Failed! Because: ";

            switch (authError)
            {
                case AuthError.InvalidEmail:
                    failedMessage += "Email is invalid";
                    break;
                case AuthError.WrongPassword:
                    failedMessage += "Wrong Password";
                    break;
                case AuthError.MissingEmail:
                    failedMessage += "Email is missing";
                    break;
                case authError.MissingPassword:
                    failedMessage += "Password is missing";
                    break;
                default:
                    failedMessage += "Login failed";
                    break;
            }

            Debug.Log(failedMessage);
        }
        else
        {
            user = loginTask.Result;

            Debug.LogFormat("{0} You are successfully logged in", user.DisplayName);
        }
    }

    public void Register()
    {
        StartCoroutine(RegisterAsync(nameRegisterField.test, emailRegisterField.text, passwordLoginField.text, confirmPasswordRegisterField.text));
    }

    private IEnumerator RegisterAsync(string name, string email, string password, string confirmPassword)
    {
        if (name == "")
        {
            Debug.LogError("User Name is Empty");
        }
        else if (email == "")
        {
            Debug.LogError("Email field is empty");
        }
        else if (passwordRegisterField.text != confirmPasswordRegisterField)
        {
            Debug.Error("Password does not match");
        }
        else
        {
            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

            yield return new WaitUntil(() => registerTask.IsCompleted);

            if (registerTask.Exception != null)
            {
                Debug.LogError(registerTask.Exception);

                FirebaseException firebaseException = registerTask.Exception.GetBaseException() as FirebaseException;
                AuthError authError = (AuthError)firebaseException.ErrorCode;

                string failedMessage = "Registration Failed! Because ";
                switch (authError)
                {
                    case AuthError.InvalidEmail:
                        failedMessage += "Email is invalid";
                        break;
                    case AuthError.WrongPassword:
                        failedMessage += "Wrong Password";
                        break;
                    case AuthError.MissingEmail:
                        failedMessage += "Email is missing";
                        break;
                    case authError.MissingPassword:
                        failedMessage += "Password is missing";
                        break;
                    default:
                        failedMessage = "Registration Failed";
                        break;
                }

                Debug.Log(failedMessage);
            }
            else
            {
                user = registerTask.Result;

                UserProfile userProfile = new UserProfile { DisplayName = Name };

                var updateProfileTask = user.UpdateUserProfileAsync(userProfile);

                yield return new WaitUntil(() => updateProfileTask.IsCompleted);

                if (updateProfileTask.Exception != null)
                {
                    user.DeleteAsync();

                    Debug.LogError(updateProfileTask.Exception);

                    FirebaseException firebaseException = updateProfileTask.Exception.GetBaseException() as FirebaseException;
                    AuthError authError = (AuthError)firebaseException.ErrorCode;

                    string failedMessage = "Registration Failed! Because ";
                    switch (authError)
                    {
                        case AuthError.InvalidEmail:
                            failedMessage += "Email is invalid";
                            break;
                        case AuthError.WrongPassword:
                            failedMessage += "Wrong Password";
                            break;
                        case AuthError.MissingEmail:
                            failedMessage += "Email is missing";
                            break;
                        case authError.MissingPassword:
                            failedMessage += "Password is missing";
                            break;
                        default:
                            failedMessage = "Profile update failed";
                            break;
                    }

                    Debug.Log(failedMessage);
                }
                else
                {
                    Debug.Log("Registration Successful! Welcome!" + user.DisplayName);
                }

            }
        }
    }
}
