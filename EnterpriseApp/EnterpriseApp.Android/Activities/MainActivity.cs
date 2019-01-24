using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.PM;
using Android.Gms.Auth.Api.SignIn;
using Android.OS;
using Firebase;
using Firebase.Auth;

namespace EnterpriseApp.Droid
{
    [Activity(Label = "EnterpriseApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static FirebaseApp firebaseApp;
        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            InitEmailPasswordFirebaseAuth();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        private void InitEmailPasswordFirebaseAuth()
        {
            //GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
            //     .RequestIdToken("171840076765-iac9hhn5c00j89r0iajs85no078v16if.apps.googleusercontent.com")
            //     .RequestEmail()
            //     .Build();

            try
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("1:998282876744:android: faa6ee6196128554")
                    .SetApiKey("AIzaSyD09cd2YsnqlhZUBvenBgCAwxJqluN0dc8")
                    .Build();

                if (firebaseApp == null)
                {
                    IList<FirebaseApp> firebaseApps = FirebaseApp.GetApps(this);
                    if (firebaseApps != null && !(firebaseApps.Count == 0))
                    {
                        foreach (FirebaseApp app1 in firebaseApps)
                        {
                            if (app1.Name.Equals(FirebaseApp.DefaultAppName))
                            {
                                firebaseApp = app1;
                            }
                        }
                    }
                    else
                    {
                        firebaseApp = FirebaseApp.InitializeApp(this, options);
                    }
                    //app = FirebaseApp.InitializeApp(this, options);
                }
                auth = FirebaseAuth.GetInstance(firebaseApp);
            }
            catch (Exception ex)
            {

            }
        }
    }
}