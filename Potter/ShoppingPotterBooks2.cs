using System.Linq;
using System.Collections.Generic;

namespace Potter
{
    public class ShoppingPotterBooks2
    {
        readonly List<BooksGrouped> _basket = new List<BooksGrouped>();
        private const decimal BookPrice = 8m;
        private const int RowDimension = 0;
        private const int ColumnDimension = 1;

        public void AddToBasket(PotterLibrary book, int quantity)
        {
            _basket.Add(new BooksGrouped(book, quantity));
        }

        public decimal GetPrice()
        {
            var matrix = GenerateMatrix();
            return GetLowerPriceForNextColumn(matrix, 0);
        }

        private decimal GetLowerPriceForNextColumn(int[,] matrix, int nextColumn)
        {
            decimal lowerPrice = decimal.MaxValue;
            for (int column = nextColumn; column < matrix.GetLength(ColumnDimension); column++)
            {
                for (int row = 0; row < matrix.GetLength(RowDimension); row++)
                {
                    matrix = RotateRow(matrix, row);
                    decimal actualPrice = CalculatePrice(matrix);
                    if (actualPrice < lowerPrice)
                    {
                        lowerPrice = actualPrice;
                    }
                    if (column + 1 < matrix.GetLength(ColumnDimension))
                    {
                        decimal lowerPriceNextColumn = GetLowerPriceForNextColumn(matrix, column + 1);
                        if (lowerPriceNextColumn < lowerPrice)
                        {
                            lowerPrice = lowerPriceNextColumn;
                        }
                    }
                }
            }
            return lowerPrice;
        }

        private decimal CalculatePrice(int[,] matrix)
        {
            decimal price = 0;
            for (int column = 0; column < matrix.GetLength(ColumnDimension); column++)
            {
                int serieBooks = 0;
                for (int row = 0; row < matrix.GetLength(RowDimension); row++)
                {
                    serieBooks += matrix[row,column];
                }
                price += serieBooks*GetDiscount(serieBooks)*BookPrice;
            }
            return price;
        }

        private int[,] RotateRow(int[,] matrix, int row)
        {
            int initial = matrix[row, 0];
            for (int column = 0; column < matrix.GetLength(ColumnDimension) - 1; column++)
            {
                matrix[row, column] = matrix[row, column + 1];
            }
            matrix[row, matrix.GetLength(ColumnDimension) - 1] = initial;
            return matrix;
        }

        private int[,] GenerateMatrix()
        {
            int upperColumn = _basket.Max(b => b.Quantity);
            int upperRow = _basket.Count;
            var matrix = new int[upperRow, upperColumn];
            for (int row = 0; row < upperRow; row ++)
            {
                for (int column = 0; column < upperColumn; column ++)
                {
                    int value = (column < _basket[row].Quantity) ? 1 : 0;
                    matrix[row, column] = value;
                }
            }
            return matrix;
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