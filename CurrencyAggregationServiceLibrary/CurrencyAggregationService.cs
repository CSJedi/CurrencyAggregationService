using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyAggregationServiceLibrary.DataProviders;
using CurrencyAggregationServiceLibrary.Interfaces;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationServiceLibrary
{
	public class CurrencyAggregationService : ICurrencyAggregationService
	{
		private List<string> PathList = new List<string> { "currency.xml","currency.csv" };
		private DateTime DateStart;
		private DateTime DateEnd;

		public CurrencyAggregationService()
		{
		}

		public List<Currency> GetCurrenciesAggregation(DateTime dateStart, DateTime dateEnd, Mode mode)
		{
			DateStart = dateStart;
			DateEnd = dateEnd;
			var currenciesResult = new List<Currency>();
			switch (mode.Code)
			{
				case 0: currenciesResult.AddRange(GetCurrenciesFromFiles().SelectMany(i=>i)); break;
				case 1: currenciesResult.AddRange(GetCurrenciesFromFiles().SelectMany(i => i)); break;
			}
			return currenciesResult;
		}

		private List<List<Currency>> GetCurrenciesFromFiles()
		{
			return PathList.Select(path => new FileProvider().GetDataProvider(path).GetData(DateStart, DateEnd, path).ToList()).ToList();
		}
	}
}
