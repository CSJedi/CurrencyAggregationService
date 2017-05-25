using System;
using CurrencyAggregationServiceLibrary;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationProject
{
	class Program
	{
		static void Main(string[] args)
		{
			var service = new CurrencyAggregationService();
			foreach (var currency in service.GetCurrenciesAggregation(new DateTime(2017, 1, 3), new DateTime(2017, 1, 3), new Mode(1)))
			{
				Console.WriteLine(currency.Code + " " + currency.Value);
			}

			Console.ReadLine();
		}
	}
}
