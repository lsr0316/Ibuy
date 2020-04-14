using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

           

                User user = new User();
                user.firstname = editFName.Text;
                user.lastname = editLName.Text;
                user.username = editEmail.Text;
                user.password = editPassword.Text;
                user.phonenumber = editPNumber.Text;
                user.address = editAddress.Text;
                user.country = editCountry.Text;

                var request = HttpWebRequest.Create(string.Format(@"https://10.0.2.2:5001/api/userDetail"));
                request.ContentType = "application/json";
                request.Method = "POST";


                var userJason = JsonConvert.SerializeObject(user);


                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {

                    streamWriter.Write(userJason);
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    if (response.StatusCode != HttpStatusCode.Created)
                    {
                        Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
                        Toast.MakeText(this, "Failed to create user. Please retry!", ToastLength.Long);
                    }
                    else
                    {
                        Toast.MakeText(this, "User created successfully", ToastLength.Long);


                        Intent LoginIntent = new Intent(this, typeof(MainActivity));
                        StartActivity(LoginIntent);
                    }
                }
            
        }
    }
}
            


            
