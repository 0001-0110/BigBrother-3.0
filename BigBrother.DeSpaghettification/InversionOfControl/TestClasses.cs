namespace BigBrother.DeSpaghettification.InversionOfControl
{
	#region Without arguments

	internal abstract class TestClass : ITestClass
	{
		public ICollection<object> Dependencies { get; protected set; }

		protected TestClass(params object[] dependencies)
		{
			Dependencies = dependencies.ToList();
		}
	}

	internal class NoDependencyClass : TestClass, INoDependencyClass
	{
		public NoDependencyClass() : base() { }
	}

	internal class OneDependencyClass : TestClass, IOneDependencyClass
	{
		public OneDependencyClass(INoDependencyClass noDependencyClass) : base(noDependencyClass) { }
	}

	internal class TwoDependencyClass : TestClass, ITwoDependencyClass
	{
		public TwoDependencyClass(INoDependencyClass noDependencyClass1, INoDependencyClass noDependencyClass2) : base(noDependencyClass1, noDependencyClass2) { }
	}

	internal class TwoDependencyWithDependenciesClass : TestClass, ITwoDependencyWithDependenciesClass
	{
		public TwoDependencyWithDependenciesClass(IOneDependencyClass oneDependencyClass, ITwoDependencyClass twoDependencyClass) : base(oneDependencyClass, twoDependencyClass) { }
	}

	#endregion
	#region With arguments

	internal abstract class TestClassWithArgs : TestClass, ITestClassWithArgs
	{
		public ICollection<object> Arguments { get; protected set; }

		protected TestClassWithArgs(object[] dependencies, params object[] args) : base(dependencies)
		{
			Arguments = args;
		}
	}

	internal class NoDependencyWithArgsClass : TestClassWithArgs, INoDependencyWithArgsClass
	{
		public NoDependencyWithArgsClass(string arg) : base(Array.Empty<object>(), arg) { }
		public NoDependencyWithArgsClass(int arg) : base(Array.Empty<object>(), arg) { }
		public NoDependencyWithArgsClass(float arg) : base(Array.Empty<object>(), arg) { }
	}

	internal class OneDependencyWithArgsClass : TestClassWithArgs, IOneDependencyWithArgsClass
	{
		public OneDependencyWithArgsClass(INoDependencyClass noDependencyClass, string arg)
			: base(new object[] { noDependencyClass, }, arg) { }

		public OneDependencyWithArgsClass(INoDependencyClass noDependencyClass, int arg)
			: base(new object[] { noDependencyClass, }, arg) { }

		public OneDependencyWithArgsClass(INoDependencyClass noDependencyClass, bool arg)
			: base(new object[] { noDependencyClass, }, arg) { }
	}

	internal class OneDependencyWithDependenciesAndArgsClass : TestClassWithArgs, IOneDependencyWithDependenciesAndArgsClass
	{
		public OneDependencyWithDependenciesAndArgsClass(IOneDependencyClass oneDependencyWithArgsClass, string arg1, int arg2)
			: base(new object[] { oneDependencyWithArgsClass, }, arg1, arg2) { }

		public OneDependencyWithDependenciesAndArgsClass(IOneDependencyClass oneDependencyWithArgsClass, bool arg1, bool arg2)
			: base(new object[] { oneDependencyWithArgsClass, }, arg1, arg2) { }

		public OneDependencyWithDependenciesAndArgsClass(IOneDependencyClass oneDependencyWithArgsClass, float arg1)
			: base(new object[] { oneDependencyWithArgsClass, }, arg1) { }
	}

	#endregion
}
