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

            //calls the add layout
            SetContentView(Resource.Layout.activity_add);

            //Creates the submit button by searching for its id
            Button submitButton = FindViewById<Button>(Resource.Id.submitButton);

            //Checks for the selected dropdown value and displays to the user
            //with the use of a toast
            Spinner dropDownCate = FindViewById<Spinner>(Resource.Id.spinner1);
            dropDownCate.ItemSelected += (s, e) =>
            {
                string firstItem = dropDownCate.SelectedItem.ToString();
                if(firstItem.Equals(dropDownCate.SelectedItem.ToString()))
                {
                    Toast.MakeText(this, "You Have Selected: " + e.Parent.GetItemAtPosition(e.Position).ToString(), ToastLength.Short).Show();
                }
            };

            //Creats textviews to get the values in the layout
            EditText nameView = FindViewById<EditText>(Resource.Id.nameView);
            EditText amountView = FindViewById<EditText>(Resource.Id.amountView);

            //creates what happens when user submits the button.
            submitButton.Click += (sender, e) =>
            {
                /*
                    Checks what is the category user has selected and they presist that
                    dynamic list created in the DataStoreClass
                */
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
                /*
                    After storing data, the program displays a toast saying the type
                    of category the user have added and then they are redirected to the main page
                */
                Toast.MakeText(this, "You Have Added New " + dropDownCate.SelectedItem.ToString(), ToastLength.Short).Show();
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);


            };

        }
    }
}