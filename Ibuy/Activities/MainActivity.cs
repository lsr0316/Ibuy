using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Ibuy.Activities;
using Android.Gms.Maps;
using System;
using Xamarin.Essentials;
using Android.Gms.Maps.Model;
using Android.Support.V7.Widget;
using Ibuy.Adapter;
using Android.Support.Design.Widget;
using Android.Views;

namespace Ibuy
{//test
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback //, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private Button btnAddUser, btnUpdateUser, btnDeleteUser ,btnMap ,btnList , btnLogin, btnShare;
        RecyclerView mRecycleView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbum mPhotoAlbum;
        PhotoAlbumAdapter mAdapter;
    

        private void MAdapter_ItemClick(object sender, int e)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnAddUser = FindViewById<Button>(Resource.Id.btn_one);
            btnUpdateUser = FindViewById<Button>(Resource.Id.btn_two);
            btnDeleteUser = FindViewById<Button>(Resource.Id.btn_three);
            btnMap = FindViewById<Button>(Resource.Id.btn_maps);
            btnList = FindViewById<Button>(Resource.Id.btn_list);
            btnLogin = FindViewById<Button>(Resource.Id.btn_login_page);
            btnList.Click += BtnList_Click;
            btnMap.Click += BtnMap_Click;
            btnLogin.Click         += delegate      { StartActivity(typeof(LoginActivity)); };
            btnAddUser.Click +=     delegate    { StartActivity(typeof(AddUserDetailsActivity)); };
            btnUpdateUser.Click += delegate { StartActivity(typeof(UpdateUserDetailsActivity)); };
            btnDeleteUser.Click += delegate { StartActivity(typeof(DeleteUserDetailsActivity)); };
            btnShare = FindViewById<Button>(Resource.Id.btn_share_page);
            btnShare.Click += BtnShare_Click;

            


        }

        private void BtnShare_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.share);
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
           
            mPhotoAlbum = new PhotoAlbum();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.list);
            mRecycleView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            mLayoutManager = new LinearLayoutManager(this);
            mRecycleView.SetLayoutManager(mLayoutManager);
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
            mAdapter.ItemClick += MAdapter_ItemClick;
            mRecycleView.SetAdapter(mAdapter);
        }

        private void BtnMap_Click(object sender, EventArgs e)
        {
            
                //map_layout
            SetContentView(Resource.Layout.navigation_layout);
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

        public void OnMapReady(GoogleMap googleMap)
        {
            googleMap.MapType = GoogleMap.MapTypeNormal;

            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;

            getCurrentLocAsync(googleMap);
        }

        private async System.Threading.Tasks.Task getCurrentLocAsync(GoogleMap googleMap)
        {
            Console.WriteLine("Test - CurrentLoc");
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"current Loc - Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    MarkerOptions curLoc = new MarkerOptions();
                    curLoc.SetPosition(new LatLng(location.Latitude, location.Longitude));
                    curLoc.SetTitle("You are here");
                    curLoc.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueAzure));

                    googleMap.AddMarker(curLoc);
                    CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                    builder.Target(new LatLng(location.Latitude, location.Longitude));
                    builder.Zoom(18);
                    builder.Bearing(155);
                    builder.Tilt(65);

                    CameraPosition cameraPosition = builder.Build();

                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

                    googleMap.MoveCamera(cameraUpdate);
                }
                else
                {
                    getLastLocation(googleMap);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Toast.MakeText(this, "Feature Not Supported", ToastLength.Short);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Toast.MakeText(this, "Feature Not Enabled", ToastLength.Short);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Toast.MakeText(this, "Needs more permission", ToastLength.Short);
            }
            catch (Exception ex)
            {
                getLastLocation(googleMap);
            }
        }

        private void getLastLocation(GoogleMap googleMap)
        {
            throw new NotImplementedException();
        }

        //public bool OnNavigationItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Resource.Id.navigation_home:
        //            //  textMessage.SetText(Resource.String.title_home);
        //            SetContentView(Resource.Layout.list);
        //            return true;
        //        case Resource.Id.navigation_map:
        //            SetContentView(Resource.Layout.map_layout);
        //            //textMessage.SetText(Resource.String.title_map);

        //            return true;
        //        case Resource.Id.navigation_Items:
        //            SetContentView(Resource.Layout.list);
        //            StartActivity(typeof(DeleteUserDetailsActivity));
        //            //  textMessage.SetText(Resource.String.title_Items);
        //            return true;
        //        case Resource.Id.navigation_profile:
        //            SetContentView(Resource.Layout.activity_update_user_details);
        //            //    textMessage.SetText(Resource.String.title_profile);
        //            return true;
        //    }
        //    return false;
        //}
    }

}