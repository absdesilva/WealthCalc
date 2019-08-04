using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WealthCalc
{
    [Activity(Label = "BookletPickerActivity", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class BookletPickerActivity : Activity
    {
        static readonly List<string> bookletData = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_picker);

            Button expenseButton = FindViewById<Button>(Resource.Id.expenseButton);
            Button incomeButton = FindViewById<Button>(Resource.Id.incomeButton);
            Button savingsButton = FindViewById<Button>(Resource.Id.savingsButton);

            var intent = new Intent(this, typeof(BookletActivity));
            expenseButton.Click += (sender, e) =>
            {
                String catType = "Expense";
                intent.PutExtra("catType", catType);
                StartActivity(intent);
            };
            incomeButton.Click += (sender, e) =>
            {
                String catType = "Income";
                intent.PutExtra("catType", catType);
                StartActivity(intent);
            };
            savingsButton.Click += (sender, e) =>
            {
                String catType = "Saving";
                intent.PutExtra("catType", catType);
                StartActivity(intent);
            };

        }
    }
}