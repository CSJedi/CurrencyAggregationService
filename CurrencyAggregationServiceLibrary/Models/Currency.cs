using System.Runtime.Serialization;

namespace CurrencyAggregationServiceLibrary.Models
{
	[DataContract]
	public class Currency
	{
		[DataMember]
		public string Code { get; }
		[DataMember]
		public double Value { get; }
		public Currency(string code, double value)
		{
			Code = code;
			Value = value;
		}
	}
}
