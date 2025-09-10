// this BonusIntroWithIocAndProjRef project uses a project ref to include the classes from our OopIntroLib project.
// Right click a project to add references to other projects. The OopIntroLib is a class library project rather than a console app.
// Class libraries produce a DLL rather than an EXE like a console app does..
using BonusIntroWithIocAndProjRef;
using OopIntroLib.Instructor; 
using OopIntroLib.PersonComponents;
using OopIntroLib.Student;
using System.Drawing;

namespace IntroWithAbstractClass
{
    internal class Program
    {
        private const string INSTRUCTOR_MESSAGE = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        // we can initialize class variables here too. It doesn't always have to be set in the constructor separately.
        private readonly static Eye[] JanesEyes = new Eye[]
        {
            new Eye(Color.Brown, 24, 32, Position.Left),
            new Eye(System.Drawing.Color.Brown, 24, 32, Position.Right) // it's redundant for us to specify the namespace as System.Drawing here since we have the using statement at the start of the file. If you had more than one object named Color in different namespaces, then you'd need to specify which one you meant.
        };

        // because we know this will be an Eye[] from the assignment, and since it's using an initializer for a collection of Eye objects,
        // the compiler knows the type that's being created and can remove the "new Eye[]" part of the declaration and initialization of the array.
        private readonly static Eye[] SamuelsEyes = 
        {
            new Eye(Color.Green, 25, 33, Position.Left),
            new Eye(Color.Green, 25, 33, Position.Right)
        };

        private readonly static Eye[] RobertsEyes = 
        {
            new Eye(Color.Blue, 26, 34, Position.Left),
            new Eye(Color.Blue, 26, 34, Position.Right)
        };

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello " + Person.Genus + " " + Person.Species);
            Console.WriteLine($"Hello { Person.Genus } { Person.Species }");

            //var userWantsToGoAgain = false; // we could've tracked whether the user wants to go again by assigning to this variable each loop, but there's no need to create a variable for this when we can simply place the condition in the while statement.
            do
            {
                MainLoop(args);
                Console.WriteLine("Want to go again? y/n");

            } while (
                string.Equals(
                    Console.ReadLine()
                    , "y"
                    , StringComparison.OrdinalIgnoreCase)); // sets the userWantsToGoAgain variable to true if the user types "y" or "Y", otherwise false.);

            Console.WriteLine(); // let's leave a blank line before the exit message to make it easier to read.
            Console.WriteLine("press any key to exit...");
            Console.Read();
        }

        static void MainLoop(string[] args)
        {
            // let's figure out the version to call, call it, then prompt the user to exit the program.
            var userPrompt = "Please enter the version to call (v1 or v2): ";
            CallSpecifiedVersion(VersionHandler.DetermineVersionToCall(userPrompt, args));
        }

        internal static void CallSpecifiedVersion(VersionToCall versionToCall)
        {
            // since we're simply comparing a set of strings, enums, ints... to a set of available options, we can use a switch statements instead of if/else if/else.
            // This is a cleaner way to express the same logic.
            switch (versionToCall)
            {
                case VersionToCall.V1:
                    MainV1();
                    break;
                case VersionToCall.V2:
                    MainV2();
                    break;
                default:
                    Console.WriteLine("No valid version selected.");
                    break;
            }

            //// this is an if / else if / if statement. It's not as clean as the switch statement above, but it works the same.
            //if (versionToCall == VersionToCall.V1)
            //{
            //    MainV1();
            //}
            //else if (versionToCall == VersionToCall.V2)
            //{
            //    MainV2();
            //}
            //else
            //{
            //    Console.WriteLine("No valid version selected.");
            //}
        }

        private static void MainV2()
        {
            IReceiveInstruction[] students = new Student[]
            {
                new Student("Jane", "Doe", 170, GradeLevel.Sophomore, JanesEyes, "JD"),
                new Student("Samuel", "Winchester", 193, GradeLevel.Freshman, SamuelsEyes)
            };

            IInstruct instructor = new InstructorV2("Robert", "Singer", 185, RobertsEyes, students, "Bobby");
            instructor.Instruct(INSTRUCTOR_MESSAGE);
        }

        private static void MainV1()
        {
            var people = new IAmAPerson[]
            {
                new Student("Jane", "Doe", 170, GradeLevel.Sophomore, JanesEyes, "JD"),
                new Student("Samuel", "Winchester", 193, GradeLevel.Freshman, SamuelsEyes), // notice, we didn't provide a nickname. Because the Student constructor has a default value for the nickname parameter, we can choose to provide it or not.
                new InstructorV1("Robert", "Singer", 185, RobertsEyes, "Bobby")
            };

            foreach (var person in people) // person variable is reassigned after each loop, to the next student in the array. It starts with the one at Index 0 and then Index 1...
            {
                person.GiveIntroduction(); // We can do this because IAmAPerson interface exposes the Speak method.

                //person.ReceiveInstruction(""); // IAmAPerson doesn't expose ReceiveInstruction. Since we stored these as IIamAPerson, we can't call the methods available to the students without getting this error: 'IAmAPerson' does not contain a definition for 'ReceiveInstruction' and no accessible extension method 'ReceiveInstruction' accepting a first argument of type 'IAmAPerson' could be found (are you missing a using directive or an assembly reference?)

                // you could cast the IAmAPerson to a Student though and then call the Student methods.
                if (person is Student student) // this won't do anything for People that aren't Students.
                {
                    student.InstructionStarting();
                }
            }

            var instructor = people.Where(p => p is InstructorV1).First() as InstructorV1; // will find the first Instructor in people. This is a shortcut way to loop through a list and grab the first item that meets some condition.

            // the following is a similar way to select items from a list that meets a certain condition, except it will grab multiple items if more than one meets the condition.
            var students = people.Where(p => p is Student).Cast<Student>().ToArray(); // here, we have to cast differently. We're doing this for potentially multiple items, rather than just the first one we find.
            foreach (var s in students)
            {
                s.InstructionStarting();
            }

            //if (instructor != null)
            //{
            //    instructor.Instruct(INSTRUCTOR_MESSAGE);
            //}

            // the question mark here means that we'll only try to call the Instruct method if the Instructor is not null. This is called the null conditional operator.
            instructor?.Instruct(INSTRUCTOR_MESSAGE); // in the future, maybe we'll pass the students array to the instructor's constructor. Then the Instructor can deliver the message directly to the students.

            foreach (var s in students)
            {
                s.InstructionInProgress(INSTRUCTOR_MESSAGE);
            }
        }
    }
}
