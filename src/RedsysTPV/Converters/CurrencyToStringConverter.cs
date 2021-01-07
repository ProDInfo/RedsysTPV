using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RedsysTPV.Converters
{
    public class CurrencyToStringJsonConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (string.IsNullOrEmpty(value))
            {
                return (decimal)0;
            }
            return Convert.ToDecimal(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}
