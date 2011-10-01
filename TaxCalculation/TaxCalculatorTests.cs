using NUnit.Framework;

namespace TaxCalculation
{
    [TestFixture]
    public class TaxCalculatorTests
    {
        [Test]
        public void When_SumIs5000_Then_TaxIs500()
        {
            var calculator = new TaxCalculator();
            Assert.That(calculator.TaxPrice(5000), Is.EqualTo(500));
        }

        [Test]
        public void When_SumIs5800_Then_TaxIs609E2()
        {
            var calculator = new TaxCalculator();
            Assert.That(calculator.TaxPrice(5800), Is.EqualTo(609.2m));
        }

        [Test]
        public void When_SumIs9000_Then_TaxIs1087E8()
        {
            var calculator = new TaxCalculator();
            Assert.That(calculator.TaxPrice(9000), Is.EqualTo(1087.8m));
        }

        [Test]
        public void When_SumIs15000_Then_TaxIs2532E9()
        {
            var calculator = new TaxCalculator();
            Assert.That(calculator.TaxPrice(15000), Is.EqualTo(2532.9m));
        }

        [Test]
        public void When_SumIs50000_Then_TaxIs15068E1()
        {
            var calculator = new TaxCalculator();
            Assert.That(calculator.TaxPrice(50000), Is.EqualTo(15068.1m));
        }

    }
}
