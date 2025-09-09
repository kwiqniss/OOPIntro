using BonusIntroWithIoc.Student;

namespace BonusIntroWithIoc.Instructor
{
    public interface IInstruct
    {
        void Instruct(string message);

        void UpdatePresentStudents(ICollection<IReceiveInstruction> students);
    }
}
