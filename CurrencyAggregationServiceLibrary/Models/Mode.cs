using System.Runtime.Serialization;

namespace CurrencyAggregationServiceLibrary.Models
{
	[DataContract]
	public class Mode
	{
		[DataMember]
		public int Code { get; }
		public Mode(int code)
		{
			Code = code;
		}
	}
}
