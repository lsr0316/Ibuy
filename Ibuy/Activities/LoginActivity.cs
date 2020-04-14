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
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        Button btn1 ;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            btn1 = FindViewById<Button>(Resource.Id.btn_register_page);
            btn1.Click += Btn1_Click;

            // Create your application here
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
             StartActivity(typeof(AddUserDetailsActivity)); 
            // SetContentView(Resource.Layout.navigation_layout);
        }
    }
}