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
using SQLite;

namespace FreeAgency
{
    class RatingTable
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int id { get; set; } // AutoIncrement and set primaryke

        public string user { get; set; }
        public string rating { get; set; }
        public string description { get; set; }

    }
}