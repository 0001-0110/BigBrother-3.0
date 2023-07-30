namespace BigBrother.BLL.Bot.Commands.SubCommands
{
	[AttributeUsage(AttributeTargets.Class)]
	internal class SubCommandHandlerAttribute : Attribute
    {
        public readonly Type CommandHandlerType;

        public SubCommandHandlerAttribute(Type type)
        {
            if (!type.GetInterfaces().Contains(typeof(CommandHandler)))
                throw new ArgumentException($"Sub command handlers can only be affected to command handlers, not {type.Name}");

            CommandHandlerType = type;
        }
    }
}
