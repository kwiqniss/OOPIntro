namespace IntroWithAbstractClass
{
    internal class Program
    {
        private static readonly string Message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello " + Person.Genus + " " + Person.Species);

            Student student = new Student("Jane", "Doe", 170, GradeLevel.Freshman, "JD");
            Instructor instructor = new Instructor("Robert", "Smith", 185, "Bob");

            instructor.Speak();
            student.Listen("");

            student.Speak();
            instructor.Listen("");

            student.PrepareToReceiveInstruction();
            instructor.Instruct(Message);
            student.ReceiveInstruction(Message);

            Console.WriteLine();
            Console.Write("press any key to exit...");
            Console.Read();
        }
    }
}
