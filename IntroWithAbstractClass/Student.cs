using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroWithAbstractClass
{
    public interface IReceiveInstruction
    {
        void PrepareToReceiveInstruction();
        void ReceiveInstruction(string message);
    }

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

        public Student(string firstName, string lastName, int heightInCm, GradeLevel gradeLevel, string? nickName) : base(firstName, lastName, heightInCm, nickName)
        {
            this.GradeLevel = gradeLevel;
        }

        public void PrepareToReceiveInstruction()
        {
            Console.WriteLine("Student is preparing to receive instruction...");
        }

        public void ReceiveInstruction(string message)
        {
            this.Listen(message);
            Console.WriteLine("Student is receiving instruction...");
        }
    }
}
