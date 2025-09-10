using OopIntroLib.Student;

namespace OopIntroLib.Instructor
{
    public interface IInstruct
    {
        void Instruct(string message);

        void UpdatePresentStudents(ICollection<IReceiveInstruction> students);
    }
}
