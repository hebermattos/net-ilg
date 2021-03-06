﻿using Domain.Data;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Reports
{
    public class MostExpensiveSale : ReportDataGenerator
    {
        public override string Key
        {
            get
            {
                return "Most expensive sale";
            }
        }

        protected override string Generate(IEnumerable<string> rawData)
        {
            var mostExpensiveSale = rawData
                .Where(x => x.StartsWith("003"))
                .Select(x => new Sale(x))
                .OrderByDescending(x => x.CalculateValue())
                .First()
                .SaleID;

            return mostExpensiveSale;
        }
    }
}
