using NUnit.Framework;

namespace Potter
{
    [TestFixture]
    public class PotterTests
    {
        ShoppingPotterBooks2 _shopping;
        
        [SetUp]
        public void Setup()
        {
            _shopping = new ShoppingPotterBooks2();
        }

        [Test]
        public void When_AddingOneBookToBasket_Then_PriceIs_8()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 1);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(8m));
        }

        [Test]
        public void When_AddingTwoIdenticalBooksToBasket_Then_PriceIs_16()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 2);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(16m));
        }

        [Test]
        public void When_AddingTwoDifferentBooksToBasket_Then_PriceIs_15E2()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 1);
            _shopping.AddToBasket(PotterLibrary.Book2, 1);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(2 * 8 * .95));
        }

        [Test]
        public void When_AddingThreeDifferentBooksToBasket_Then_PriceIs_21E6()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 1);
            _shopping.AddToBasket(PotterLibrary.Book2, 1);
            _shopping.AddToBasket(PotterLibrary.Book3, 1);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(3 * 8 * .90));
        }

        [Test]
        public void When_AddingFourDifferentBooksToBasket_Then_PriceIs_25E6()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 1);
            _shopping.AddToBasket(PotterLibrary.Book2, 1);
            _shopping.AddToBasket(PotterLibrary.Book3, 1);
            _shopping.AddToBasket(PotterLibrary.Book4, 1); 
            Assert.That(_shopping.GetPrice(), Is.EqualTo(4 * 8 * .80));
        }

        [Test]
        public void When_AddingFiveDifferentBooksToBasket_Then_PriceIs_30()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 1);
            _shopping.AddToBasket(PotterLibrary.Book2, 1);
            _shopping.AddToBasket(PotterLibrary.Book3, 1);
            _shopping.AddToBasket(PotterLibrary.Book4, 1);
            _shopping.AddToBasket(PotterLibrary.Book5, 1); 
            Assert.That(_shopping.GetPrice(), Is.EqualTo(5 * 8 * .75));
        }

        [Test]
        public void When_Adding3BooksBut2AreDifferentToBasket_Then_PriceIs_51E2()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 2);
            _shopping.AddToBasket(PotterLibrary.Book2, 1);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(2 * 8 * .95 + 8));
        }
 

        [Test]
        public void When_AddingAuthorExampleBooksToBasket_Then_PriceIs_51E2()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 2);
            _shopping.AddToBasket(PotterLibrary.Book2, 2);
            _shopping.AddToBasket(PotterLibrary.Book3, 2);
            _shopping.AddToBasket(PotterLibrary.Book4, 1);
            _shopping.AddToBasket(PotterLibrary.Book5, 1);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(4*8*.80 + 4*8*.80));
        }

        [Test]
        public void When_AddingDoubleAuthorExampleBooksToBasket_Then_PriceIs_102E4()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 4);
            _shopping.AddToBasket(PotterLibrary.Book2, 4);
            _shopping.AddToBasket(PotterLibrary.Book3, 4);
            _shopping.AddToBasket(PotterLibrary.Book4, 2);
            _shopping.AddToBasket(PotterLibrary.Book5, 2);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(4 * 8 * .80 + 4 * 8 * .80 + 4 * 8 * .80 + 4 * 8 * .80));
        }

        [Test]
        public void When_AddingFewBooksToBasket_Then_PriceIs_188()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 7);
            _shopping.AddToBasket(PotterLibrary.Book2, 7);
            _shopping.AddToBasket(PotterLibrary.Book3, 7);
            _shopping.AddToBasket(PotterLibrary.Book4, 4);
            _shopping.AddToBasket(PotterLibrary.Book5, 5);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(2*5*8*.75 + 5*4*8*.80));
        }

        [Test, Ignore("Must be optimized!")]
        public void When_AddingManyBooksToBasket_Then_PriceIs_828()
        {
            _shopping.AddToBasket(PotterLibrary.Book1, 32);
            _shopping.AddToBasket(PotterLibrary.Book2, 30);
            _shopping.AddToBasket(PotterLibrary.Book3, 30);
            _shopping.AddToBasket(PotterLibrary.Book4, 20);
            _shopping.AddToBasket(PotterLibrary.Book5, 20);
            Assert.That(_shopping.GetPrice(), Is.EqualTo(10*5*8*.75 + 20*4*8*.8 + 2*8));
        }
    }
}
