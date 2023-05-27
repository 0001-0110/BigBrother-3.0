using System.Reflection;

namespace BigBrother.DAL.Extensions
{
    internal static class TypeExtensions
    {
        public static PropertyInfo? GetProperty(this Type type, Type propertyType)
        {
            return type.GetProperties().SingleOrDefault(property => property.PropertyType == propertyType);
        }
    }
}
