using BonusIntroWithIoc.PersonComponents;
using BonusIntroWithIoc.Student;

namespace BonusIntroWithIoc.Instructor
{
    public class InstructorV1 : Person, IInstruct
    {
        public InstructorV1(string firstName, string lastName, int heightInCm, Eye[] eyes, string nickName = "") : base(firstName, lastName, heightInCm, eyes, nickName) { }

        public override string FullName => $"{FirstName} {LastName}";

        public override void Listen(string? message)
        {
            Console.WriteLine("Instructor is listening carefully...");
        }

        public void Instruct(string message)
        {
            Console.WriteLine("Instructor is instructing the class...");
            GiveIntroduction();
            Console.WriteLine(message);
            Console.WriteLine("Instructor has finished instructing the class.");
        }

        public void UpdatePresentStudents(ICollection<IReceiveInstruction> students)
        {
            // This version of the Instructor does not keep track of students, so this method does nothing.
        }
    }
}
