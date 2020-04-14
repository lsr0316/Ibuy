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
    [Activity(Label = "LoginActivity",Theme = "@style/AppTheme", MainLauncher = false)]
    public class LoginActivity : Activity
    {
        Button btnLogin ,btnRegister;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            btnLogin = FindViewById<Button>(Resource.Id.btn_registerPage);
            btnRegister = FindViewById<Button>(Resource.Id.btn_login);
            SetContentView(Resource.Layout.activity_login);
            base.OnCreate(savedInstanceState);
            //btnLogin.Click += delegate { StartActivity(typeof(AddUserDetailsActivity)); };
            //// btnLogin.Click += BtnLogin_Click1;
            //// Create your application here
        
            //btnRegister.Click += delegate { StartActivity(typeof(navigation)); };
        }

        private void BtnLogin_Click1(object sender, EventArgs e)
        {
            StartActivity(typeof(AddUserDetailsActivity));
        }

        //private void BtnLogin_Click(object sender, EventArgs e)
        //{
            
        //}
    }
}