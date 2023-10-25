namespace Client.Models.Utility
{
    public class JsonEnumConverter<TEnum> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            if (Enum.TryParse(typeof(TEnum), reader.Value.ToString(), out var result))
                return result;

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && Enum.IsDefined(typeof(TEnum), value))
            {
                writer.WriteValue((int)value);
            }
            else
            {
                writer.WriteNull();
            }
        }
    }

}
