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

            Student student = new Student("Jane", "Doe", 170, GradeLevel.Sophomore, "JD");
            var student2 = new Student("Samuel", "Winchester", 193, GradeLevel.Freshman, "Sammy");
            //var students = new Student[] { student, student2 }; // this would work to create our student array, but it would be unusual to declare the student and student2 variables and immediately put them in an array since that's creating variables that are only used once and it's on the next line, so there's no reason for the overhead of creatin a variable. See sample below.

            Instructor instructor = new Instructor("Robert", "Singer", 185, "Bobby");

            instructor.Speak();
            student.Listen("");
            student2.Listen("");

            student.Speak();
            student2.Speak();
            instructor.Listen("");

            student.NickName = "Janey";
            student.Speak();

            student.PrepareToReceiveInstruction();
            student2.PrepareToReceiveInstruction();
            instructor.Instruct(Message);
            student.ReceiveInstruction(Message);
            student2.ReceiveInstruction(Message);

            // a better way to do that would be to have a collection of students, and loop through them instead of being so redundant.
            var students = new Student[]
            {
                new Student("Jane", "Doe", 170, GradeLevel.Sophomore, "JD"),
                new Student("Samuel", "Winchester", 193, GradeLevel.Freshman, "Sammy")
            };

            foreach (var s in students)
            {
                s.PrepareToReceiveInstruction();
            }

            instructor.Instruct(Message);

            foreach (var s in students)
            {
                s.ReceiveInstruction(Message);
            }


            Console.WriteLine();
            Console.Write("press any key to exit...");
            Console.Read();
        }
    }
}
