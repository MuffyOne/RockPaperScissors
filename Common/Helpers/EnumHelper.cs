using System.ComponentModel;
using System.Reflection;

namespace RockPaperScissors.Common.Helpers
{
    public class EnumHelper
    {
        public static string GetEnumDescription(object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi == null)
            {
                return value.ToString();
            }
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }
    }
}
