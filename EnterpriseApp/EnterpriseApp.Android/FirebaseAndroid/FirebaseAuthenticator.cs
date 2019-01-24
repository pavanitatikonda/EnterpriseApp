using System;
using System.Threading.Tasks;
using EnterpriseApp.Interface;
using Firebase.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(EnterpriseApp.Droid.FirebaseAndroid.FirebaseAuthenticator))]
namespace EnterpriseApp.Droid.FirebaseAndroid
{
        public class FirebaseAuthenticator : IFirebaseAuthenticator
        {
            FirebaseAuth auth;
            public FirebaseAuthenticator()
            {
                auth = FirebaseAuth.GetInstance(MainActivity.firebaseApp);
            }

            public async Task<string> LoginWithEmailPassword(string email, string password)
            {
                try
                {
                    // var user = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                    var user = await auth.SignInWithEmailAndPasswordAsync(email, password);
                    var token = await user.User.GetTokenAsync(false);
                    return token.Token;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public async Task<string> RegsiterWithEmailPassword(string email, string password)
            {
                //  var user = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var user = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetTokenAsync(false);
                return token.Token;
            }

        }
    }