using System;

namespace TaxCalculation
{
    public class TaxByRange : ITaxByRange
    {
        private readonly decimal _upperRange;
        private readonly decimal _discount;
        private readonly ITaxByRange _innerTaxByRange;

        public TaxByRange(decimal upperRange, decimal discount, ITaxByRange innerTaxByRange)
        {
            _upperRange = upperRange;
            _discount = discount;
            _innerTaxByRange = innerTaxByRange;
            if (LowerRange > UpperRange)
            {
                throw new ArgumentException(string.Format("Upper range {0} is invalid! [cannot be lower than {1}]", 
                                            UpperRange, LowerRange));
            }
        }

        public decimal LowerRange
        {
            get { return _innerTaxByRange.UpperRange; }
        }

        public decimal UpperRange
        {
            get { return _upperRange; }
        }

        public decimal CalculatePriceWithTax(decimal price)
        {
            decimal sum = 0;
            decimal remainder = price;
            if (price >= LowerRange && price <= UpperRange)
            {
                sum += (price - LowerRange) * _discount;
                remainder = LowerRange;
            }
            sum += _innerTaxByRange.CalculatePriceWithTax(remainder);
            return sum;
        }
    }
}