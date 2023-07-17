namespace InversionOfControl
{
	public interface IDependencyInjector
	{
		public DependencyInjector Map<TInterface, TImplementation>() where TImplementation : TInterface;

		public DependencyInjector MapSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface;

		public DependencyInjector MapSingleton<TInterface, TImplementation>(TImplementation singleton) where TImplementation : notnull, TInterface;

		public object? Instantiate(Type type, params object[] arguments);

		public T? Instantiate<T>(params object[] arguments);
	}
}
