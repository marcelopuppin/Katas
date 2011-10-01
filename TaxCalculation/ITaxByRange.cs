namespace TaxCalculation
{
    public interface ITaxByRange
    {
        decimal LowerRange { get; }
        decimal UpperRange { get; }
        decimal CalculatePriceWithTax(decimal price);
    }
}
