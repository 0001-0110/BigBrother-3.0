using Bot;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        // Create a new Instance of the bot
        BigBrother thing = new BigBrother();
        // Start the bot
        int exitCode = thing.Run();
        return exitCode;
    }
}
