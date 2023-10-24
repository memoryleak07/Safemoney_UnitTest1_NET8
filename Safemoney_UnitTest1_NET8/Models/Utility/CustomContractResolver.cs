using Client.Models.SMEnum;
using Client.Models.SMModels;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Client.Models.Utility
{
    public class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(SMDenominations) && property.PropertyName == "Denomination")
            {
                property.Converter = new JsonEnumConverter<EurDenomination>();
            }
            else if (property.DeclaringType == typeof(SMDenominations) && property.PropertyName == "DeviceType")
            {
                property.Converter = new StringEnumConverter();
            }

            return property;
        }
    }
}
