using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace Ibuy.Activities
{
    [Activity(Label = "navigation")]
    public class navigation : Activity , BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            navigation navigation1 = this;
            Xamarin.Essentials.Platform.Init(navigation1, savedInstanceState);
            SetContentView(Resource.Layout.navigation_layout);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
           
        }

          public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                  //  textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_map:
                    SetContentView(Resource.Layout.share);
                    //textMessage.SetText(Resource.String.title_map);
                    
                    return true;
                case Resource.Id.navigation_Items:
                    StartActivity(typeof(AddUserDetailsActivity));
                    //textMessage.SetText(Resource.String.title_Items);
                    return true;
                case Resource.Id.navigation_profile:
                    // textMessage.SetText(Resource.String.title_profile);
                    StartActivity(typeof(AddUserDetailsActivity));
                    return true;
            }
            return false;
        }
    }
}