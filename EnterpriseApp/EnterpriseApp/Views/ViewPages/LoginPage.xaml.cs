using EnterpriseApp.Constants;
using EnterpriseApp.Interface;
using EnterpriseApp.Models;
using EnterpriseApp.Views.Authentication;
using EnterpriseApp.Views.ViewPages;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnterpriseApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Account account;
        AccountStore store;
        public LoginPage()
        {
            try
            {
                InitializeComponent();

                store = AccountStore.Create();
                account = store.FindAccountsForService(MobileConstants.AppName).FirstOrDefault();

                NavigationPage.SetHasNavigationBar(this, false);
            }
            catch(Exception ex)
            {

            }
        }

        private void SignUpWithGoogle(object sender, System.EventArgs e)
        {
            try
            {
                string clientId = null;
                string redirectUri = null;

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        clientId = MobileConstants.iOSClientId;
                        redirectUri = MobileConstants.iOSRedirectUrl;
                        break;

                    case Device.Android:
                        clientId = MobileConstants.AndroidClientId;
                        redirectUri = MobileConstants.AndroidRedirectUrl;
                        break;
                }

                var authenticator = new OAuth2Authenticator(
                    clientId,
                    null,
                    MobileConstants.Scope,
                    new Uri(MobileConstants.AuthorizeUrl),
                    new Uri(redirectUri),
                    new Uri(MobileConstants.AccessTokenUrl),
                    null,
                    false);

                var uri = authenticator.GetInitialUrlAsync();
                Device.OpenUri(uri.Result);

                authenticator.Completed += OnAuthCompleted;
                authenticator.Error += OnAuthError;

                AuthenticationState.Authenticator = authenticator;
            }
            catch(Exception ex)
            {

            }
        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            try
            {
                var authenticator = sender as OAuth2Authenticator;
                if (authenticator != null)
                {
                    authenticator.Completed -= OnAuthCompleted;
                    authenticator.Error -= OnAuthError;
                }

                User user = null;
                if (e.IsAuthenticated)
                {
                    // DismissViewController(true, null);

                
                    // If the user is authenticated, request their basic user data from Google
                    var request = new OAuth2Request("GET", new Uri(MobileConstants.UserInfoUrl), null, e.Account);
                    var response = await request.GetResponseAsync();
                    if (response != null)
                    {
                        // Deserialize the data and store it in the account store
                        // The users email address will be used to identify data in SimpleDB
                        string userJson = await response.GetResponseTextAsync();
                        user = JsonConvert.DeserializeObject<User>(userJson);
                        if (user != null)
                        {
                            await Navigation.PushAsync(new Page1(user?.Email));
                        }
                    }

                    if (account != null)
                    {
                        store.Delete(account, MobileConstants.AppName);
                    }

                    await store.SaveAsync(account = e.Account, MobileConstants.AppName);
                    // await DisplayAlert("Email address", user.Email, "OK");

                    var token = new GoogleOAuthToken
                    {
                        TokenType = e.Account.Properties["token_type"],
                        AccessToken = e.Account.Properties["access_token"]
                    };
                   // authenticator.IsLoadableRedirectUri()

                }
            }
            catch (Exception ex)
            {

            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            try
            {
                var authenticator = sender as OAuth2Authenticator;
                if (authenticator != null)
                {
                    authenticator.Completed -= OnAuthCompleted;
                    authenticator.Error -= OnAuthError;
                }

                Debug.WriteLine("Authentication error: " + e.Message);
            }
            catch(Exception ex)
            {

            }
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (CheckValidatiions())
            {
                var token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(txtEmail.Text, txtPassword.Text);
                if (token != null)
                {
                    await DisplayAlert("Message", "Login Successfully", "OK", "Cancel");
                }
                else
                {
                    await DisplayAlert("Message", "Login Failed", "OK", "Cancel");
                }
            }

        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            if (CheckValidatiions())
            {
                var token = await DependencyService.Get<IFirebaseAuthenticator>().RegsiterWithEmailPassword(txtEmail.Text, txtPassword.Text);
                if (token != null)
                {
                    await DisplayAlert("Message", "Registered Successfully", "OK", "Cancel");
                }
                else
                {
                    await DisplayAlert("Message", "Registered Failed", "OK", "Cancel");
                }
            }
        }

        private bool CheckValidatiions()
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                DisplayAlert("Alert", "Enter email", "ok");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {

                DisplayAlert("Alert", "Enter password", "ok");
                return false;
            }
            return true;
        }

    }
}