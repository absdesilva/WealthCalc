using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WealthCalc
{
    class DataStore
    {
        public static readonly List<Calc> ExpensesList = new List<Calc>();
        public static readonly List<Calc> IncomeList = new List<Calc>();
        public static readonly List<Calc> SavingsList = new List<Calc>();

        public static double getTotalExpenses()
        {
            double total = 0;

            foreach (Calc aPart in ExpensesList)
            {
                total = total + aPart.Amount;
            }

            return total;
        }

        public static double getTotalIncome()
        {
            double total = 0;

            foreach (Calc aPart in IncomeList)
            {
                total = total + aPart.Amount;
            }

            return total;
        }

        public static double getTotalSavings()
        {
            double total = 0;

            foreach (Calc aPart in SavingsList)
            {
                total = total + aPart.Amount;
            }

            return total;
        }

        /*public static double getTotalCashInHand()
        {
            double CashInHand = 0;

            double income = getTotalIncome();
            double expenses = getTotalExpenses();
            double savings = getTotalExpenses();

            CashInHand = income - (savings + expenses);

            return CashInHand;
        }*/
    }
}