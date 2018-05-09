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
using System.Linq;

namespace FreeAgency
{
    [Activity(Label = "Search For Players", MainLauncher = false)]
    public class SearchActivity : Activity
    {

        //ListView lsvResults;
        EditText txtSearch;
        Button btnSearch;

        private UserAdapter mAdapter;
        private List<User> mUsers;

        public ListView lsvResults;
        //public ListView mListView;
        
         

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Search);

            lsvResults = FindViewById<ListView>(Resource.Id.lsvResults);
            txtSearch = FindViewById<EditText>(Resource.Id.txtSearch);
            btnSearch = FindViewById<Button>(Resource.Id.btnSearch);

            txtSearch.Alpha = 0;
            txtSearch.TextChanged += mSearch_TextChanged;

            mUsers = new List<User>();
            mUsers.Add(new User { username = "Jdawg", leagueChoice = "male", availability = "any", sports = "football" });
            mUsers.Add(new User { username = "Baller21", leagueChoice = "coed", availability = "Tuesdays", sports = "basketball" });
            mUsers.Add(new User { username = "VolleyBGirl82", leagueChoice = "female", availability = "Fridays", sports = "racquetball, football, baseball"});
            mUsers.Add(new User { username = "scott", leagueChoice = "Male", availability = "any", sports = "football, dodgeball" });
            mUsers.Add(new User { username = "jorge", leagueChoice = "coed", availability = "monday", sports = "tennis" });

            mAdapter = new UserAdapter(this, Resource.Layout.row_user, mUsers);
            lsvResults.Adapter = mAdapter;


        }

        void mSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<User> searchedUsers = (from user in mUsers
                                        where user.username.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) || 
                                        user.leagueChoice.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) || 
                                        user.availability.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                                        user.sports.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)
                                        select user).ToList<User>();
            mAdapter = new UserAdapter(this, Resource.Layout.row_user, searchedUsers);
           lsvResults.Adapter = mAdapter;

        }
    }
}