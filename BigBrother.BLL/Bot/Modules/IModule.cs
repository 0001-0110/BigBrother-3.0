namespace Bot.Modules
{
    internal interface IModule
    {
        public void Init();

        // TODO might not be the correct return type
        public void Help();

        // The method to call when this module is called
        // TODO might not be the correct return type
        // TODO might not be the best name
        public void Run();
    }
}
