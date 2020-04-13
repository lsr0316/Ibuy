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

namespace Ibuy.Activities
{
    class User
    {

        public long id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}