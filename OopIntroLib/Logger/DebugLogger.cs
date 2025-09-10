using System.Diagnostics;

namespace OopIntroLib.Logger
{
    public class DebugLogger : ILogger
    {
        public void WriteLine(string? message = null)
        {
            Debug.WriteLine(message);
        }

        public void WriteError(string? message = null)
        {
            Debug.WriteLine($"Error: {message}");
        }
    }
}
