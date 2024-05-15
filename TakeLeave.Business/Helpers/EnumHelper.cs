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

        public static T GetEnumValueFromDisplayName<T>(string displayName)
        {
            try
            {
                foreach (T enumValue in Enum.GetValues(typeof(T)))
                {
                    var desc = enumValue.GetEnumDescription<T>();
                    if (desc.Equals(displayName))
                    {
                        return enumValue;
                    }
                }
                throw new Exception();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
