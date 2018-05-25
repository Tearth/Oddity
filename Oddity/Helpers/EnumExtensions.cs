using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Oddity.Helpers
{
    public static class EnumExtensions
    {
        public static string GetEnumMemberAttrValue(this Enum enumObject, object enumValue)
        {
            var enumType = enumObject.GetType();

            var memberInfo = enumType.GetMember(enumValue.ToString())[0];
            var enumMemberAttribute = memberInfo.GetCustomAttributes(false).OfType<EnumMemberAttribute>().FirstOrDefault();

            return enumMemberAttribute?.Value;
        }
    }
}
