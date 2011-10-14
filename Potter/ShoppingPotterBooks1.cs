using System.Linq;
using System.Collections.Generic;

namespace Potter
{
    public class ShoppingPotterBooks1
    {
        readonly List<BooksGrouped> _basket = new List<BooksGrouped>();
        private const decimal BookPrice = 8m;

        public void AddToBasket(PotterLibrary book, int quantity)
        {
            _basket.Add(new BooksGrouped(book, quantity));
        }

        public decimal GetPrice()
        {
            var booksGrouped = GetBasketList();
            decimal lowestPrice = booksGrouped.Sum(bg => bg.Quantity) * BookPrice;
            for (int i = booksGrouped.Count(); i > 0; i--)
            {
                decimal calculatedPrice = GetPriceWithDiscount(booksGrouped.ToList(), i);
                if (calculatedPrice < lowestPrice)
                {
                    lowestPrice = calculatedPrice;
                }
            }
            return lowestPrice;
        }

        private static decimal GetPriceWithDiscount(List<BooksGrouped> booksGrouped, int maxAllowedDistinctBooks)
        {
            decimal seriePrice = 0;
            int numberOfDistinctBooks = booksGrouped.Where(bg => bg.Quantity > 0).Distinct().Count();
            if (numberOfDistinctBooks > maxAllowedDistinctBooks)
            {
                numberOfDistinctBooks = maxAllowedDistinctBooks;
            }
            if (numberOfDistinctBooks > 0) {
                seriePrice = numberOfDistinctBooks * BookPrice * GetDiscount(numberOfDistinctBooks);
                RemoveUsedBooks(booksGrouped, numberOfDistinctBooks);
                seriePrice += GetPriceWithDiscount(booksGrouped, numberOfDistinctBooks);
            }
            return seriePrice;
        }

        private static void RemoveUsedBooks(IEnumerable<BooksGrouped> booksGrouped, int numberOfDistinctBooks)
        {
            foreach (var book in booksGrouped.Where(bg => bg.Quantity > 0))
            {
                if (numberOfDistinctBooks == 0)
                {
                    break;
                }
                book.Quantity -= 1;
                numberOfDistinctBooks -= 1;
            }
        }

        private static decimal GetDiscount(int numberOfDistinctBooks)
        {
            switch(numberOfDistinctBooks)
            {
                case 2:
                    return 0.95m;
                case 3:
                    return 0.90m;
                case 4:
                    return 0.80m;
                case 5:
                    return 0.75m;
                default:
                    return 1;
            }
        }

        private IEnumerable<BooksGrouped> GetBasketList()
        {
            return _basket.GroupBy(b => b.Book).Select(g => new BooksGrouped(g.Key, g.Sum(b => b.Quantity)));
        }
 
        internal class BooksGrouped
        {
            public PotterLibrary Book { get; set; }
            public int Quantity { get; set; }

            public BooksGrouped(PotterLibrary book, int quantity)
            {
                Book = book;
                Quantity = quantity;
            }
        }
    }

}