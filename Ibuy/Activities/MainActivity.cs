using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Ibuy.Activities;

namespace Ibuy
{//test
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnAddUser, btnUpdateUser, btnDeleteUser;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnAddUser = FindViewById<Button>(Resource.Id.btn_one);
            btnUpdateUser = FindViewById<Button>(Resource.Id.btn_two);
            btnDeleteUser = FindViewById<Button>(Resource.Id.btn_three);


            btnAddUser.Click += delegate { StartActivity(typeof(AddUserDetailsActivity)); };
            btnUpdateUser.Click += delegate { StartActivity(typeof(UpdateUserDetailsActivity)); };
            btnDeleteUser.Click += delegate { StartActivity(typeof(DeleteUserDetailsActivity)); };




        }

        private void BtnDeleteUser_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BtnUpdateUser_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BtnAddUser_Click(object sender, System.EventArgs e)
        {


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}