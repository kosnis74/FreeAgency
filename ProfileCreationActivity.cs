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
    [Activity(Label = "Create Your Profile")]
    public class ProfileCreationActivity : Activity
    {

        EditText txtUsername;
        EditText txtPassword;
        EditText txtLeagueChoice;
        EditText txtAvailability;
        EditText txtSports;
        Button btnCreate;
        Button btnClear;
        Button btnHome;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ProfileCreation);

            btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtLeagueChoice = FindViewById<EditText>(Resource.Id.txtLeagueChoice);
            txtAvailability = FindViewById<EditText>(Resource.Id.txtAvailability);
            txtSports = FindViewById<EditText>(Resource.Id.txtSports);
            btnCreate.Click += BtnCreate_Click;
            btnClear = FindViewById<Button>(Resource.Id.btnClear);
            btnClear.Click += BtnClear_Click;
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnHome.Click += BtnHome_Click;
            CreateDB();

        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            

            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<User>();
                User tbl = new User();
                tbl.username = txtUsername.Text;
                tbl.leagueChoice = txtLeagueChoice.Text;
                tbl.availability = txtAvailability.Text;
                tbl.sports = txtSports.Text;
                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
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
        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtLeagueChoice.Text = "";
            txtSports.Text = "";
            txtAvailability.Text = "";

        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}