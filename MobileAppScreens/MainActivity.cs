using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MobileAppScreens
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
       
        Product rProduct;
        //ItemAdapter rAdapter;
        RecyclerView rRecycleView;
        RecyclerView.LayoutManager rLayoutManager;
        TextView textMessage;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            rProduct = new Product();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


         

            rLayoutManager = new LinearLayoutManager(this);

            //For when the Item Adapter is complete 
           // rAdapter = new ItemAdapter(rProduct);        
               

           

            rRecycleView = FindViewById<RecyclerView>(Resource.Id.recycler1);
            rRecycleView.SetLayoutManager(rLayoutManager); ;
          //  rRecycleView.SetAdapter(rAdapter);



            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            
            navigation.SetOnNavigationItemSelectedListener(this);
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            int itemNum = e + 1;
            Toast.MakeText(this, "Item number " + itemNum, ToastLength.Short).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_maps:
                    textMessage.SetText(Resource.String.title_map);
                    return true;
                case Resource.Id.navigation_account:
                    textMessage.SetText(Resource.String.title_account);
                    return true;
            }
            return false;
        }
    }
}

