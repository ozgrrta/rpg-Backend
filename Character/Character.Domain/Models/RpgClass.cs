using System.Text.Json.Serialization;

namespace Character.Domain.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum RpgClass
	{
		Knight = 1,
		Mage = 2,
		Cleric = 3
	}
}
