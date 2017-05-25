using System;
using System.IO;
using CurrencyAggregationServiceLibrary.Interfaces;

namespace CurrencyAggregationServiceLibrary.DataProviders
{
	public class FileProvider
	{
		public IDataProvider GetDataProvider(string pathToFile)
		{
			switch (Path.GetExtension(pathToFile))
			{
				case ".xml":
					return new XmlDataProvider();
				case ".csv":
					return new CsvDataProvider(); 
			}

			throw new Exception("File extension has not data provider");
		}
	}
}
