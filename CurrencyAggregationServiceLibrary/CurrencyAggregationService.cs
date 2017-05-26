using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CurrencyAggregationServiceLibrary.DataProviders;
using CurrencyAggregationServiceLibrary.Extencion;
using CurrencyAggregationServiceLibrary.Interfaces;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationServiceLibrary
{
	public class CurrencyAggregationService : ICurrencyAggregationService
	{
		public List<Currency> GetCurrenciesAggregation(DateTime dateStart, DateTime dateEnd, Mode mode)
		{
			var currenciesResult = new List<Currency>();
			switch (mode.Code)
			{
				case 0: currenciesResult.AddRange(GetCurrenciesFromFiles(dateStart, dateEnd).SelectMany(i => i).AverageValue()); break;
				case 1: currenciesResult.AddRange(GetCurrenciesFromFiles(dateStart, dateEnd).Select(i => i.AverageValue()).SelectMany(i => i).AverageValue()); break;
					
			}
			return currenciesResult;
		}

		private List<List<Currency>> GetCurrenciesFromFiles(DateTime dateStart, DateTime dateEnd)
		{
			return Directory.GetFiles(@"..\..\..\CurrencyAggregationServiceLibrary\Files").ToList()
				.Select(path => new FileProvider().GetDataProvider(path).GetData(dateStart, dateEnd, path).ToList()).ToList();
		}
	}
}
