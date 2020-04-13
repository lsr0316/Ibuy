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
    [Activity(Label = "UpdateUserDetailsActivity")]
    public class UpdateUserDetailsActivity : Activity
    {
        private EditText editFName, editLName, editPNumber, editEmail, editAddress, editCountry;
        private Button btnUpdate, btnGetEmail;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_update_user_details);

            btnUpdate = FindViewById<Button>(Resource.Id.btn_update_up);
            editFName = FindViewById<EditText>(Resource.Id.txt_first_name_up);
            editLName = FindViewById<EditText>(Resource.Id.txt_last_name_up);
            editAddress = FindViewById<EditText>(Resource.Id.txt_address_up);
            editCountry = FindViewById<EditText>(Resource.Id.txt_country_up);
            editEmail = FindViewById<EditText>(Resource.Id.txt_email_address_up);
            editPNumber = FindViewById<EditText>(Resource.Id.txt_phone_number_up);
            btnGetEmail = FindViewById<Button>(Resource.Id.btn_get_up);

            btnGetEmail.Click += async delegate
            {
                User user = null;
                HttpClient client = new HttpClient();
                string url = "https://localhost:44366/api/User" + editEmail.Text.ToString();
                var result = await client.GetAsync(url);
                var json = await result.Content.ReadAsStringAsync();
                try
                {
                    user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);
                }
                catch (Exception ex)
                { }

                if (user == null)
                {
                    editFName.Text = user.firstname;
                    editLName.Text = user.lastname;
                    editAddress.Text = user.address;
                    editCountry.Text = user.country;
                    editPNumber.Text = user.phonenumber;
                }

                //var uri = new Uri(url);
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage response;
                //var json = JsonConvert.SerializeObject(user);
                //var content = new StringContent(json, Encoding.UTF8, "application/json");
                //response = await client.PostAsync(uri, content);

                //if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                //{
                //    Toast.MakeText(this, "Your feedback was saved", ToastLength.Long).Show();
                //}
                //else
                //{
                //    Toast.MakeText(this, "Your feedback was  not saved", ToastLength.Long).Show();
                //}


            };

            btnUpdate.Click += async delegate
            {

                User user = new User();
                user.firstname = editFName.Text;
                user.lastname = editLName.Text;
                user.username = editEmail.Text;

                user.phonenumber = editPNumber.Text;
                user.address = editAddress.Text;
                user.country = editCountry.Text;

                HttpClient client = new HttpClient();
                string url = $"https://localhost:44366/api/User";
                var uri = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await client.PostAsync(uri, content);

                if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    Toast.MakeText(this, "Your feedback was saved", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Your feedback was  not saved", ToastLength.Long).Show();
                }



            };

            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}