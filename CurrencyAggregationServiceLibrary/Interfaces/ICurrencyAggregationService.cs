using System;
using System.Collections.Generic;
using System.ServiceModel;
using CurrencyAggregationServiceLibrary.Models;

namespace CurrencyAggregationServiceLibrary.Interfaces
{
	[ServiceContract]
	public interface ICurrencyAggregationService
	{
		[OperationContract]
		List<Currency> GetCurrenciesAggregation(DateTime dateStart, DateTime dateEnd, Mode mode );
	}
}
