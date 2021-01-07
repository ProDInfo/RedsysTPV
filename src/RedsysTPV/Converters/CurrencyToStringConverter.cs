using Newtonsoft.Json;
using RedsysTPV.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedsysTPV.Converters
{
    public class CurrencyToStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (typeof(decimal) == objectType)
                return true;
            else
                return false;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Decimal dvalue = (Decimal)value;
            int truncate = (int)Math.Truncate(dvalue);
            int remainder = (int)Math.Truncate((dvalue - truncate) * 100);

            Currency currency = (Currency)serializer.Context.Context;
            int amount = 0;

            if (currency == Currency.JPY)
                amount = truncate;
            else
                amount = truncate * 100 + remainder;

            writer.WriteValue(amount.ToString());
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return 0M;
            }

            return Convert.ToDecimal(reader.Value);
        }
    }
}
