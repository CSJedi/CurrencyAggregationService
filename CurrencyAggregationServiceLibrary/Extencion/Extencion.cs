
using System.Collections.Generic;
using System.Linq;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationServiceLibrary.Extencion
{
	public static class Extencion
	{
		public static IEnumerable<Currency> AverageValue(this IEnumerable<Currency> list)
		{
			return from currency in list
				   group currency by currency.Code
				into currencies
				   select new Currency(currencies.Key, currencies.Average(row => row.Value));
		}

	}
}
