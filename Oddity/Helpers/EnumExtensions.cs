using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Oddity.Helpers
{
    public static class EnumExtensions
    {
        public static string GetEnumMemberAttributeValue(this Enum enumObject, object enumValue)
        {
            var enumType = enumObject.GetType();

            var memberInfo = enumType.GetMember(enumValue.ToString())[0];
            var enumMemberAttribute = memberInfo.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

            return enumMemberAttribute?.Value;
        }
    }
}
