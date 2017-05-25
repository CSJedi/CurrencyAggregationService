using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using CurrencyAggregationServiceLibrary.Interfaces;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationServiceLibrary.DataProviders
{
	class XmlDataProvider: IDataProvider
	{
		public List<Currency> GetData(DateTime dateStart, DateTime dateEnd, string filePath)
		{
			var currencyListResult = new List<Currency>();
			try
			{
				var documentXml = new XmlDocument();
				documentXml.Load(filePath);

				var rates = documentXml.SelectSingleNode("rates");
				if (rates?.ChildNodes == null) return currencyListResult;

				currencyListResult.AddRange(from XmlNode currencyCode in rates.ChildNodes
					where currencyCode?.ChildNodes != null
					from XmlNode rate in currencyCode.ChildNodes
					where rate.Attributes != null
					let rateDate = DateTime.ParseExact(rate.Attributes?["date"].Value, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None)
					where rateDate >= dateStart && rateDate <= dateEnd
					select new Currency(currencyCode.Attributes?["code"].Value, double.Parse(rate.Attributes?["rate"].Value)
					));
			}
			catch (Exception exception)
			{
				Console.WriteLine($"CurrencyAggregationServiceLibrary.DataProviders:XmlDataProvider \n {exception}", exception);
			}

			return currencyListResult;
		}
	}
}
