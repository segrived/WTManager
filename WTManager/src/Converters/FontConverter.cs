using System;
using System.Drawing;
using Newtonsoft.Json;

namespace WtManager.Converters
{
    public class FontConverter : JsonConverter
    {
        private readonly System.Drawing.FontConverter _converter;

        public FontConverter()
        {
            this._converter = new System.Drawing.FontConverter();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value is Font fontObject))
                return;

            writer.WriteValue(this._converter.ConvertToString(fontObject));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!(reader.Value is string serializedData))
                return null;

            return this._converter.ConvertFromString(serializedData);
        }

        public override bool CanConvert(Type objectType) 
            => objectType == typeof(Font);
    }
}