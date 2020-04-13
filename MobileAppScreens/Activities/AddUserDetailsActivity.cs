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
    [Activity(Label = "AddUserDetailsActivity")]
    public class AddUserDetailsActivity : Activity
    {
        private EditText editFName, editLName, editPNumber, editEmail, editPassword, editAddress, editCountry;
        private Button btnRegister;
        // SetContentView(Resource.Layout.activity_add_user_details_);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_add_user_details);
            base.OnCreate(savedInstanceState);
            btnRegister = FindViewById<Button>(Resource.Id.btn_register_add);
            editFName = FindViewById<EditText>(Resource.Id.txt_first_name_add);
            editLName = FindViewById<EditText>(Resource.Id.txt_last_name_add);
            editAddress = FindViewById<EditText>(Resource.Id.txt_address_add);
            editCountry = FindViewById<EditText>(Resource.Id.txt_country_add);
            editPNumber = FindViewById<EditText>(Resource.Id.txt_phone_number_add);
            editPassword = FindViewById<EditText>(Resource.Id.txt_password_add);
            editEmail = FindViewById<EditText>(Resource.Id.txt_email_address_add);

            btnRegister.Click += async delegate
            {

                User user = new User();
                user.firstname = editFName.Text;
                user.lastname = editLName.Text;
                user.username = editEmail.Text;
                user.password = editPassword.Text;
                user.phonenumber = editPNumber.Text;
                user.address = editAddress.Text;
                user.country = editCountry.Text;

                HttpClient client = new HttpClient();
                string url = "https://localhost:5001/api/userDetails?firstName={user.FirstName}&lastname={user.LastName}&address={user.Address}&password{user.Password}&phonenumber{user.PhoneNumber}&country{user.Country}&username{user.Email}";

                var uri = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(uri, content);
                Clear();
                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    Toast.MakeText(this, "Your feedback was saved", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Your feedback was  not saved", ToastLength.Long).Show();
                }
            };
            void Clear()
            {
                editEmail.Text = "";
                editAddress.Text = "";
                editCountry.Text = "";
                editFName.Text = "";
                editLName.Text = "";
                editPNumber.Text = "";
                editPassword.Text = "";

            }

            // Create your application here
        }


    }
}