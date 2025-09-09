namespace BonusIntroWithIoc.Student
{
    public interface IReceiveInstruction
    {
        void InstructionStarting();
        void InstructionInProgress(string message);
        void InstructionComplete();
    }
}
