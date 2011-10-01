using System;

namespace TaxCalculation
{
    public class TaxNop : ITaxByRange
    {
        public decimal LowerRange
        {
            get { return 0; }
        }

        public decimal UpperRange
        {
            get { return 0; }
        }

        public decimal CalculatePriceWithTax(decimal price)
        {
            return 0;
        }
    }
}