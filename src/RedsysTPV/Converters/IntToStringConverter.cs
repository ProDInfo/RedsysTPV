using Newtonsoft.Json;
using RedsysTPV.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedsysTPV.Converters
{
    public class IntToStringJsonConverter : JsonConverter
    {
        public string Format { get; set; }
     
        public IntToStringJsonConverter(string format)
        {
            this.Format = format;
        }
        public override bool CanConvert(Type objectType)
        {
            if (typeof(int) == objectType)
                return true;
            else
                return false;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((int)value).ToString(this.Format));
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return (int)0;
            }
            return Convert.ToInt32(reader.Value);
        }
    }
}
