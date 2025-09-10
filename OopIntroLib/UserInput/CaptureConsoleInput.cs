namespace OopIntroLib.UserInput
{
    public class CaptureConsoleInput : ICaptureInput
    {
        public int Read(string? prompt = null)
        {
            if (prompt != null) Console.WriteLine(prompt); // we don't actually need brackets for one liners in if statements.
            return Console.Read();
        }

        public string ReadLine(string? prompt = null)
        {
            if (prompt != null) Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty; // in case Console.ReadLine() returns null, we return an empty string instead. ?? means if the previous item was null, use this instead.
        }
    }
}
