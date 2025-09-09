using BonusIntroWithIoc.PersonComponents;

namespace BonusIntroWithIoc.Student
{
    public class Student : Person, IReceiveInstruction
    {
        public GradeLevel GradeLevel { get; set; }

        public override string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.NickName))
                {
                    return $"{this.FirstName} {this.LastName}";
                }

                return $"{this.FirstName} '{this.NickName}' {this.LastName}";
            }
        }

        public Student(string firstName, string lastName, int heightInCm, GradeLevel gradeLevel, Eye[] eyes, string nickName = "") : base(firstName, lastName, heightInCm, eyes, nickName)
        {
            this.GradeLevel = gradeLevel;
        }

        public void InstructionStarting()
        {
            
            this.Speak("Hi professor!");
            this.GiveIntroduction();
            Console.WriteLine(); // blank line in console.
        }

        public void InstructionInProgress(string message)
        {
            this.Speak($"I, {this.FullName}, am receiving instruction...");
            this.Listen(message);
            Console.WriteLine(); // blank line in console.
        }

        public void InstructionComplete()
        {
            this.Speak("Thanks professor!");
        }
    }
}
