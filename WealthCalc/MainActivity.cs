using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WealthCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        //these variables get and store the total values to display
        public double totalCashInHand, totalSavings, totalIncome, totalExpenses;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Gets all the data from the datastore and assign to the created variables
            totalSavings = DataStore.getTotalSavings();
            totalIncome = DataStore.getTotalIncome();
            totalExpenses = DataStore.getTotalExpenses();
            totalCashInHand = totalIncome - (totalSavings + totalExpenses); ;


            //get home page text view and button id and assign values
            TextView textCashInHand = FindViewById<TextView>(Resource.Id.showcashinhand);
            TextView textSavings = FindViewById<TextView>(Resource.Id.showsavings);
            TextView textIncome = FindViewById<TextView>(Resource.Id.showincome);
            TextView textExpenses = FindViewById<TextView>(Resource.Id.showexpenses);
            Button buttonAdd = FindViewById<Button>(Resource.Id.addButton);
            Button buttonBooklet = FindViewById<Button>(Resource.Id.bookletButton);

            //These variables assign data to home page views
            textCashInHand.Text = "$" + totalCashInHand;
            textSavings.Text = "$" + totalSavings;
            textIncome.Text = "$" + totalIncome;
            textExpenses.Text = "-$" + totalExpenses;


            //Add Button On Click Event
            buttonAdd.Click += (sender, e) =>
             {
                 var intent = new Intent(this, typeof(AddActivity));
                 StartActivity(intent);
             };
            buttonBooklet.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(BookletPickerActivity));
                StartActivity(intent);
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}

