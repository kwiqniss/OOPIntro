using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroWithAbstractClass
{
    public interface IInstruct
    {
        void Instruct(string message);
    }

    public class Instructor : Person, IInstruct
    {
        public Instructor(string firstName, string lastName, int heightInCm, string? nickName) : base(firstName, lastName, heightInCm, nickName) { }

        public override string FullName => $"{this.FirstName} {this.LastName}";

        public override void Listen(string? message)
        {
            Console.WriteLine("Instructor is listening carefully...");
        }

        public void Instruct(string message)
        {
            Console.WriteLine("Instructor is instructing the class...");
            this.Speak();
            Console.WriteLine(message);
            Console.WriteLine("Instructor has finished instructing the class.");
        }
    }
}
