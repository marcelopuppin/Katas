namespace TaxCalculation
{
    public class TaxCalculator
    {
        private readonly ITaxByRange _taxCalculator;

        public TaxCalculator()
        {
            var tax0 = new TaxNop();
            var tax1 = new TaxByRange(5070, 0.1m, tax0);
            var tax2 = new TaxByRange(8660, 0.14m, tax1);
            var tax3 = new TaxByRange(14070, 0.23m, tax2);
            var tax4 = new TaxByRange(21240, 0.30m, tax3);
            var tax5 = new TaxByRange(40230, 0.33m, tax4);
            var tax6 = new TaxByRange(decimal.MaxValue, 0.45m, tax5);
            _taxCalculator = tax6;
        }

        public decimal TaxPrice(decimal sum)
        {
            return _taxCalculator.CalculatePriceWithTax(sum);
        }
    }
}