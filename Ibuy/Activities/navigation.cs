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
            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView nav = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            //nav.SetOnNavigationItemSelectedListener(this);
           
        }

          public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_map:
                    textMessage.SetText(Resource.String.title_map);
                    return true;
                case Resource.Id.navigation_Items:
                    textMessage.SetText(Resource.String.title_Items);
                    return true;
                case Resource.Id.navigation_profile:
                    textMessage.SetText(Resource.String.title_profile);
                    return true;
            }
            return false;
        }
    }
}