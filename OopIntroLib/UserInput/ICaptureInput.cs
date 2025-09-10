namespace OopIntroLib.UserInput
{
    public interface ICaptureInput
    {
        int Read(string? prompt = null);
        string ReadLine(string? prompt = null);
    }
}
