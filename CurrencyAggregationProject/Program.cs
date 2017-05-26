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
			for (int i = 0; i < 2; i++)
			{
				foreach (var currency in service.GetCurrenciesAggregation(new DateTime(2016, 1, 1), new DateTime(2017, 1, 3), new Mode(i)))
				{
					Console.WriteLine(currency.Code + " " + currency.Value);
				}
			}

			Console.ReadLine();
		}
	}
}
