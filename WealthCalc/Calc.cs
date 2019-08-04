using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WealthCalc
{

    /*
        This class is the template on how the data should be stored. Each category:
        Income, Expenses and Savings will use this template to store data.
    */
    class Calc
    {
        public string Name { get; set; }
        public string CateType { get; set; }
        public double Amount { get; set; }
    }
}