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
    [Activity(Label = "BookletActivity", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class BookletActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_booklet);

            TextView textTitle = FindViewById<TextView>(Resource.Id.viewTitle);
            ListView listData = FindViewById<ListView>(Resource.Id.bookletlist);

            string catType = Intent.GetStringExtra("catType");
            List<string> bookletData = new List<string>();
            if (catType.Equals("Expense"))
            {
                foreach (Calc aPart in DataStore.ExpensesList)
                {
                    bookletData.Add(aPart.Name + " - $" + aPart.Amount.ToString());
                }
            }
            else if (catType.Equals("Income"))
            {
                foreach (Calc aPart in DataStore.IncomeList)
                {
                    bookletData.Add(aPart.Name + " - $" + aPart.Amount.ToString());
                }
            }
            else if (catType.Equals("Saving"))
            {
                foreach (Calc aPart in DataStore.SavingsList)
                {
                    bookletData.Add(aPart.Name + " - $" + aPart.Amount.ToString());
                }
            }

            textTitle.Text = catType;
            listData.Adapter = new CalcListViewAdapter(this, bookletData);
        }
    }
}