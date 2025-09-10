using OopIntroLib.PersonComponents;
using OopIntroLib.Student;

namespace OopIntroLib.Instructor
{
    public class InstructorV1 : Person, IInstruct
    {
        public InstructorV1(string firstName, string lastName, int heightInCm, Eye[] eyes, string? nickName = null) : base(firstName, lastName, heightInCm, eyes, nickName) { }

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
            // What we're doing here is wrong. Never implement an interface unless you are implementing all of its functionality. 
            // The only thing we could've done to make this worse is to throw a NotImplementedException.
            // Perhaps we should've given a separate interface IUpdateStudents to InstructorV2 to implement in addition to IInstruct.
        }
    }
}
