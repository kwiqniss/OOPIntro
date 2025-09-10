namespace OopIntroLib.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLine(string? message = null)
        {
            Console.WriteLine(message);
        }

        public void WriteError(string? message = null)
        {
            Console.Error.WriteLine(message);
        }
    }
}
