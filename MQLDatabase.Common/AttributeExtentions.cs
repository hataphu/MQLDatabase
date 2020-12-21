using MQLDatabase.Common.Attribute;
using System.Linq;

namespace MQLDatabase.Common
{
    public static class AttributeExtentions
    {
        public static string GetName<T>(this T ienum)
        {
            try
            {
                var type = ienum.GetType();
                var memInfo = type.GetMember(ienum.ToString());
                var name = memInfo[0].GetCustomAttributes(true).OfType<NameAttr>().FirstOrDefault();
                return name.Name;
            }
            catch
            {
                return "";
            }
        }

    }
}
