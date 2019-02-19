using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Data
{
    public class Sale
    {
        public Sale(string rawSale)
        {
            var saleData = rawSale.Split('ç');

            if (saleData[0] != "003")
                throw new ArgumentException("Invalid sale data");

            var rawItemData = saleData[2]
                .Replace("[", "")
                .Replace("]", "")
                .Split(',');

            Itens = rawItemData.Select(x => new Item(x)).ToList();
            SaleID = saleData[1];
            SalesmanName = saleData[3];
        }

        public string SaleID { get; set; }

        public List<Item> Itens { get; set; }

        public string SalesmanName { get; set; }

        public decimal CalculateValue() {

            var value = Itens
                .Select(x => Convert.ToInt32(x.ItemQuantity) * Convert.ToDecimal(x.ItemPrice))
                .Sum();

            return value;
        }
    }
}
