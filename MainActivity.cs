using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

using System.IO;
using SQLite;

namespace FreeAgency
{
    [Activity(Label = "Welcome to FreeAgency", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnLoginScreen;
        Button btnSignup;
        Button btnForgot;
        Button btnAbout;
        Button btnTeamCapRate;
        Button btnSubRate;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            CreateDB();

            btnLoginScreen = FindViewById<Button>(Resource.Id.btnLoginScreen);
                btnLoginScreen.Click += OnLoginClick;
            btnSignup = FindViewById<Button>(Resource.Id.btnSignup);
                btnSignup.Click += OnSignupClick;
            btnForgot = FindViewById<Button>(Resource.Id.btnForgot);
                 btnForgot.Click += OnForgotClick;
            btnAbout = FindViewById<Button>(Resource.Id.btnAbout);
                   btnAbout.Click += OnAboutClick;
            btnTeamCapRate = FindViewById<Button>(Resource.Id.btnTeamCapRate);
                btnTeamCapRate.Click += OnTeamCapClick;
            btnSubRate = FindViewById<Button>(Resource.Id.btnSubRate);
                btnSubRate.Click += OnSubClick;

        }

        void OnLoginClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }

        void OnSignupClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ProfileCreationActivity));
            StartActivity(intent);
        }

        void OnForgotClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ForgotPasswordActivity));
            StartActivity(intent);
        }
        
        void OnAboutClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }
        void OnTeamCapClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TeamRepRatingActivity));
            StartActivity(intent);
        }
        void OnSubClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SubPlayerRatingActivity));
            StartActivity(intent);
        }

        public string CreateDB()
        {
            var output = "";
            output += "Creating Database if it doesn't exist";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";
            return output;
        }

    }
}

