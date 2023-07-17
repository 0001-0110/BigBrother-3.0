using InversionOfControl;

namespace BigBrother.DeSpaghettification.InversionOfControl
{
	internal class DependencyInjectorTest
	{
		DependencyInjector injector;

		[SetUp]
		public void SetUp()
		{
			injector = new DependencyInjector()
				.Map<INoDependencyClass, NoDependencyClass>()
				.Map<IOneDependencyClass, OneDependencyClass>()
				.Map<ITwoDependencyClass, TwoDependencyClass>()
				.Map<ITwoDependencyWithDependenciesClass, TwoDependencyWithDependenciesClass>()
				.Map<INoDependencyWithArgsClass, NoDependencyWithArgsClass>()
				.Map<IOneDependencyWithArgsClass, OneDependencyWithArgsClass>()
				.Map<IOneDependencyWithDependenciesAndArgsClass, OneDependencyWithDependenciesAndArgsClass>();
		}

		[Test]
		[TestCase(typeof(NoDependencyClass))]
		[TestCase(typeof(OneDependencyClass))]
		[TestCase(typeof(TwoDependencyClass))]
		[TestCase(typeof(TwoDependencyWithDependenciesClass))]
		public void TestDependencyInjectionWithoutArguments(Type implementation)
		{
			object? result = injector.Instantiate(implementation, Array.Empty<object>());
			Assert.That(result, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.InstanceOf(implementation));
				Assert.That(((ITestClass)result).Dependencies.All(dependency => dependency != null), Is.True);
			});
			foreach (object dependency in ((ITestClass)result).Dependencies)
				Assert.That(((ITestClass)dependency).Dependencies.All(dependency => dependency != null), Is.True);
		}

		[Test]
		[TestCase(typeof(NoDependencyWithArgsClass), "test")]
		[TestCase(typeof(NoDependencyWithArgsClass), 10)]
		[TestCase(typeof(NoDependencyWithArgsClass), 10f)]
		[TestCase(typeof(OneDependencyWithArgsClass), "test")]
		[TestCase(typeof(OneDependencyWithArgsClass), 90)]
		[TestCase(typeof(OneDependencyWithArgsClass), true)]
		[TestCase(typeof(OneDependencyWithDependenciesAndArgsClass), "", 10)]
		[TestCase(typeof(OneDependencyWithDependenciesAndArgsClass), false, true)]
		[TestCase(typeof(OneDependencyWithDependenciesAndArgsClass), 10f)]
		public void TestDependencyIjectionWithArgumengts(Type implementation, params object[] arguments)
		{
			object? result = injector.Instantiate(implementation, arguments);
			Assert.That(result, Is.Not.Null);
			Assert.Multiple(() =>
			{
				Assert.That(result, Is.InstanceOf(implementation));
				Assert.That(((ITestClass)result).Dependencies.All(dependency => dependency != null), Is.True);
			});
			foreach (object dependency in ((ITestClass)result).Dependencies)
				Assert.That(((ITestClass)dependency).Dependencies.All(dependency => dependency != null), Is.True);
			Assert.That(arguments.All(arg => ((ITestClassWithArgs)result).Arguments.Contains(arg)), Is.True);
		}
	}
}
