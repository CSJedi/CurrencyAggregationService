using System;
using System.Collections.Generic;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationServiceLibrary.Interfaces
{
	public interface IDataProvider
	{
		List<Currency> GetData(DateTime dateStart, DateTime dateEnd, string filePath);
	}
}
