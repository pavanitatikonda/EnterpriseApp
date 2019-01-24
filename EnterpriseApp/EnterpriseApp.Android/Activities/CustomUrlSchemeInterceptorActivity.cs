using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using EnterpriseApp.Views.Authentication;

namespace EnterpriseApp.Droid.Activities
{
    [Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
       // DataSchemes = new[] { "com.googleusercontent.apps.171840076765-iac9hhn5c00j89r0iajs85no078v16if" },
       // com.googleusercontent.apps.1026724755960 - dsd8v9vmt9h6ruemvvlbj6hhqimtkrcp:/ oauth2redirect
        DataSchemes = new[] { "com.googleusercontent.apps.1026724755960-dsd8v9vmt9h6ruemvvlbj6hhqimtkrcp" },
        DataPath = "/oauth2redirect")]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                // Convert Android.Net.Url to Uri
                var uri = new Uri(Intent.Data.ToString());

                // Load redirectUrl page
                AuthenticationState.Authenticator.OnPageLoading(uri);

                //new Task(() =>
                //{
                //    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                //}).Start();


                this.Finish();

               // return;
            }
            catch(Exception ex)
            {
                //return;
            }
        }
    }
}