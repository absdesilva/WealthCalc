using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace WealthCalc
{
    [Activity(Label = "Add Activity")]
    public class AddActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_add);

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {

            

            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    var intent = new Intent(this, typeof(MainActivity));
                    StartActivity(intent);
                    return true;
                case Resource.Id.navigation_dashboard:
                    var intent1 = new Intent(this, typeof(AddActivity));
                    StartActivity(intent1);
                    return true;
                case Resource.Id.navigation_notifications:
                    SetContentView(Resource.Layout.activity_booklet);
                    return true;
            }
            return false;
        }
    }
}