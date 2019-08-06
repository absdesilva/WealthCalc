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

            //Get the layout elements by its Id
            TextView textTitle = FindViewById<TextView>(Resource.Id.viewTitle);
            ListView listData = FindViewById<ListView>(Resource.Id.bookletlist);

            //Assign the data sent from previous activity
            string catType = Intent.GetStringExtra("catType");
            //Creates a dynamic array to store the list data
            List<string> bookletData = new List<string>();

            /*
                ThisConditional statements checks what which category button is pressed by the user
                in the previous activity. For example if it is expenses then the program first
                checks whether the sent pressed button is correct and start generating data out 
                of the expense list and create array of strings to put inside the variable which displays
                the data in the list view.
             */
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

            /*
             Once the data is filtered and ready to be used, we use a list view adapter,
             to show case our data.
             */

            textTitle.Text = catType;
            listData.Adapter = new CalcListViewAdapter(this, bookletData);
        }
    }
}