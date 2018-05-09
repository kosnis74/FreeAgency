using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FreeAgency
{
    [Activity(Label = "RatingActivity")]
    public class RatingActivity : Activity
    {

        Button btnPlayerRating;
        Button btnTeamCapRating;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Rating);

            FindViewById<Button>(Resource.Id.btnPlayerRating).Click += OnPlayerClick;
            FindViewById<Button>(Resource.Id.btnTeamCapRating).Click += OnTeamCapClick;
           
        }

        void OnPlayerClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SubPlayerRatingActivity));
            StartActivity(intent);
        }
        void OnTeamCapClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TeamRepRatingActivity));
            StartActivity(intent);
        }
    }
}