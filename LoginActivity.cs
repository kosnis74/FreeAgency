using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace FreeAgency
{
    [Activity(Label = "Login")]

    

    public class LoginActivity : Activity
    {

        Button btnLogin;
        Button btnHome;
        EditText txtUsername;
        EditText txtPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here


            SetContentView(Resource.Layout.Login);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += OnLoginClick;

            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnHome.Click += OnHomeClick;

            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            CreateDB();
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

        void OnLoginClick(object sender, EventArgs e)
        {
           

            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<User>();
                var data1 = data.Where(x => x.username == txtUsername.Text && x.password == txtPassword.Text).FirstOrDefault();

                if (data != null)
                {
                    //Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
                     var intent = new Intent(this, typeof(SearchActivity));
                    StartActivity(intent);
                  
                }
                else
                {
                    Toast.MakeText(this, "Username or Password are invalid", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }

        }
        

        void OnHomeClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

       
    }
}