using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CurrencyAggregationServiceLibrary.Interfaces;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationServiceLibrary.DataProviders
{
	class CsvDataProvider: IDataProvider
	{
		public List<Currency> GetData(DateTime dateStart, DateTime dateEnd, string filePath)
		{
			var currencyListResult = new List<Currency>();
			try
			{
				using(var csvReader = new StreamReader(File.OpenRead(filePath)))
				while (!csvReader.EndOfStream)
				{
					var rate = csvReader.ReadLine()?.Split(',');
					if (rate == null || rate.Length != 3) continue;
					var rateDate = DateTime.ParseExact(rate[1].Trim(' '), "yyyyMMdd",
						CultureInfo.InvariantCulture, DateTimeStyles.None);
					if (rateDate >= dateStart && rateDate <= dateEnd)
					{
						currencyListResult.Add(new Currency(rate[0], double.Parse(rate[2])));
					}
				}
			}
			catch (Exception exception)
			{
				Console.WriteLine($"CurrencyAggregationServiceLibrary.DataProviders:CsvDataProvider \n {exception}", exception);
			}

			return currencyListResult;
		}
	}
}
