using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TakeLeave.Business.Helpers
{
    public static class EnumHelper
    {
        public static string GetEnumDescription<T>(this T enumValue)
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());

            DisplayAttribute attribute = field.GetCustomAttribute<DisplayAttribute>();

            return attribute != null ? attribute.Name : enumValue.ToString();
        }
    }
}
