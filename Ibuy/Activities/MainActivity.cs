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
using Android.Views;

namespace Ibuy
{//test
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        private Button btnAddUser, btnUpdateUser, btnDeleteUser ,btnMap;


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

            btnMap.Click += BtnMap_Click;
            btnAddUser.Click += delegate { StartActivity(typeof(AddUserDetailsActivity)); };
            btnUpdateUser.Click += delegate { StartActivity(typeof(UpdateUserDetailsActivity)); };
            btnDeleteUser.Click += delegate { StartActivity(typeof(DeleteUserDetailsActivity)); };





        }

        //Android.Widget.SearchView searchView;
        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    this.MenuInflater.Inflate(Resource.Menu.menu1, menu);

        //  //  var searchItem = menu.FindItem(Resource.Id.navigation_map);

        //  //  searchView = searchItem.ActionProvider.JavaCast<Android.Widget.SearchView>();

        //    searchView.QueryTextSubmit += (sender, args) =>
        //    {
        //        Toast.MakeText(this, "You searched: " + args.Query, ToastLength.Short).Show();

        //    };


        //    return base.OnCreateOptionsMenu(menu);
        //}


        private void BtnMap_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.share);
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
    }
}