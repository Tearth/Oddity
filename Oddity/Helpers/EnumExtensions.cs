using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Oddity.Helpers
{
    internal static class EnumExtensions
    {
        public static string GetEnumMemberAttributeValue(this Enum enumObject, object enumValue)
        {
            var enumType = enumObject.GetType().GetTypeInfo();

            var memberInfo = enumType.GetDeclaredField(enumValue.ToString());
            var enumMemberAttribute = memberInfo.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

            return enumMemberAttribute?.Value;
        }
    }
}
