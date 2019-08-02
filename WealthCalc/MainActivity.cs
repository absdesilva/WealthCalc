using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace WealthCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {


        TextView textCashInHand, textSavings, textIncome, textExpenses;
        double totalCashInHand, totalSavings, totalIncome, totalExpenses = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
           

            SetContentView(Resource.Layout.activity_main);

            //navigation button event
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            //get home page text view id and assign values
            textCashInHand = FindViewById<TextView>(Resource.Id.showcashinhand);
            textSavings = FindViewById<TextView>(Resource.Id.showsavings);
            textIncome = FindViewById<TextView>(Resource.Id.showincome);
            textExpenses = FindViewById<TextView>(Resource.Id.showexpenses);

            //These variables assign data to home page views
            textCashInHand.Text = "$" + totalCashInHand;
            textSavings.Text = "$" + totalSavings;
            textIncome.Text = "$" + totalIncome;
            textExpenses.Text = "$" + totalExpenses;
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
                    SetContentView(Resource.Layout.activity_main);
                    return true;
                case Resource.Id.navigation_dashboard:
                    SetContentView(Resource.Layout.activity_add);
                    return true;
                case Resource.Id.navigation_notifications:
                    //textMessage.SetText(Resource.String.title_notifications);
                    return true;
            }
            return false;
        }
    }
}

