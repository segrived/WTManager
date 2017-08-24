using System;
using System.Drawing;
using Newtonsoft.Json;

namespace WTManager.Converters
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
            var fontObject = value as Font;

            if (fontObject == null)
                return;

            writer.WriteValue(this._converter.ConvertToString(fontObject));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string serializedData = reader.Value as string;

            if (serializedData == null)
                return null;

            return this._converter.ConvertFromString(serializedData);
        }

        public override bool CanConvert(Type objectType) 
            => objectType == typeof(Font);
    }
}