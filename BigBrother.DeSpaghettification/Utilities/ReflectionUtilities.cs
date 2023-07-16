using System.Reflection;

namespace BigBrother.DeSpaghettification.Utilities
{
	internal static class ReflectionUtility
	{
		public static object? CallPrivate(object instance, string methodName, params object?[] arguments)
		{
			return instance.GetType()
				.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance)?
				.Invoke(instance, arguments);
		}

		/*public static object? CallGeneric(object instance, string methodName, Type type, params object?[] arguments)
		{
			return CallGeneric(instance, methodName, new Type[] { type, }, arguments);
		}

		public static object? CallGeneric(object instance, string methodName, Type[] types, params object?[] arguments)
		{
			return instance
				.GetType()
				.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance)?
				.MakeGenericMethod(types)
				.Invoke(instance, arguments);
		}*/
	}
}
