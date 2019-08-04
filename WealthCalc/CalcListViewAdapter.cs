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

    /*
    
        BaseAdapter Created to implement my own List View.
        Reference as follows:
        https://www.youtube.com/watch?v=OHvY1DUxzfo
        https://stacktips.com/tutorials/xamarin/listview-example-in-xamarin-android
    */
    class CalcListViewAdapter : BaseAdapter<string>
    {
        private List<string> mItems;
        private Activity mContext;

        public CalcListViewAdapter(Activity context, List<string> items)
        {
            mItems = items;
            mContext = context;
        }

        public override int Count
        {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this[int position]
        {
            get { return mItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if( row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.activity_booklet_item, null, false);
            }

            TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
            txtName.Text = mItems[position];

            return row;

        }

    }
}