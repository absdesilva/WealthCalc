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
using System;
using System.Collections.Generic;

namespace WealthCalc
{
    [Activity(Label = "Add Activity", Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait)]
    public class AddActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_add);

            //
            Button submitButton = FindViewById<Button>(Resource.Id.submitButton);

            Spinner dropDownCate = FindViewById<Spinner>(Resource.Id.spinner1);
            dropDownCate.ItemSelected += (s, e) =>
            {
                string firstItem = dropDownCate.SelectedItem.ToString();
                if(firstItem.Equals(dropDownCate.SelectedItem.ToString()))
                {
                    Toast.MakeText(this, "You Have Selected: " + e.Parent.GetItemAtPosition(e.Position).ToString(), ToastLength.Short).Show();
                }
            };

            EditText nameView = FindViewById<EditText>(Resource.Id.nameView);
            EditText amountView = FindViewById<EditText>(Resource.Id.amountView);


            submitButton.Click += (sender, e) =>
            {
                if(dropDownCate.SelectedItem.ToString().Equals("Expense"))
                {
                    DataStore.ExpensesList.Add(new Calc()
                    {
                        Name = nameView.Text,
                        CateType = dropDownCate.SelectedItem.ToString(),
                        Amount = Convert.ToDouble(amountView.Text)
                    });    
                }
                else if (dropDownCate.SelectedItem.ToString().Equals("Income"))
                {
                    DataStore.IncomeList.Add(new Calc()
                    {
                        Name = nameView.Text,
                        CateType = dropDownCate.SelectedItem.ToString(),
                        Amount = Convert.ToDouble(amountView.Text)
                    });
                }

                else if (dropDownCate.SelectedItem.ToString().Equals("Savings"))
                {
                    DataStore.SavingsList.Add(new Calc()
                    {
                        Name = nameView.Text,
                        CateType = dropDownCate.SelectedItem.ToString(),
                        Amount = Convert.ToDouble(amountView.Text)
                    });
                }

                Toast.MakeText(this, "You Have Added New " + dropDownCate.SelectedItem.ToString(), ToastLength.Short).Show();
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);


            };

        }
    }
}