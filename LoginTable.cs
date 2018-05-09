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
    class LoginTable
    {



        public int id { get; set; }
        [MaxLength(25)]
        public string username { get; set; }
        public string password { get; set; }
    }
}