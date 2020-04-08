using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Ibuy.Activities
{
    [Activity(Label = "DeleteUserDetailsActivity")]
    public class DeleteUserDetailsActivity : Activity
    {
        private Button btnDlt;
        private EditText confirmUserName, confirmPassword;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_delete_user_details);
            // Create your application here
            btnDlt = FindViewById<Button>(Resource.Id.btn_delete);
            confirmUserName = FindViewById<EditText>(Resource.Id.txt_email_address_del);
            confirmPassword = FindViewById<EditText>(Resource.Id.txt_password_del);

            btnDlt.Click += async delegate
            {

                User user = new User();

                user.username = confirmUserName.Text;
                user.password = confirmPassword.Text;


                HttpClient client = new HttpClient();
                string url = "https://localhost:44366/api/User" + confirmUserName.Text.ToString();

                var uri = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(uri, content);

                Clear();
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    Toast.MakeText(this, "Your feedback was deleted", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Your feedback was  not deleted", ToastLength.Long).Show();
                }
            };
            void Clear()
            {
                confirmUserName.Text = "";
                confirmPassword.Text = "";
            }
        }

    }
}