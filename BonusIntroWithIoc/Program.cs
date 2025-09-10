// the BonusIntroWithIocAndProjRef project uses a project ref to include the classes from our OopIntroLib project.
// Right click a project to add references to other projects. The OopIntroLib is a class library project rather than a console app.
// Class libraries produce a DLL rather than an EXE like a console app does..
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

        /// <summary>
        /// This is the scenario where you'll see private types (classes, enums...) We're only using VersionToCall from this class, so it might as well be in the class.
        /// </summary>
        private enum VersionToCall
        {
            V1 = 1,
            V2 = 2,
            Unknown = 0
        }

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
            var versionToCall = DetermineVersionToCall(userPrompt, args);
            CallSpecifiedVersion(versionToCall);
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

        private static VersionToCall DetermineVersionToCall(string userPrompt, string[]? args = null) // by using the ? here, we can use null as default instead of an empty array.
        {
            var versionToCall = VersionToCall.Unknown;

            // the question mark makes sure args was provided and isn't null before we try to access its Length property.
            // Separately, maybe there is a way we could do this using .Any() instead of comparing length? We'd still need to make sure args isn't null first though.
            // comparable to:
            //   if (args != null && args.Length > 0)
            if (args?.Length > 0) 
            {
                versionToCall = ConvertUserInputToVersion(args[0]);
            }

            if (versionToCall == VersionToCall.Unknown)
            {
                versionToCall = GetValidVersionInputFromUser(userPrompt);
            }

            return versionToCall;
        }

        private static VersionToCall ConvertUserInputToVersion(string? input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                // let's see if the user entered 1, v1, V1, 2, v2, or V2. If they did, return the appropriate enum value. Otherwise, return Unknown.

                if (input == 
                    ((int)VersionToCall.V1).ToString() // this is similar to input == "1", but if we ever change the enum value, this will automatically update too. We're casting the enum to its base value of an int. Then we call ToString() to convert the int to a string for comparison since input from the console is always a string.
                    || string.Equals(input, VersionToCall.V1.ToString(), StringComparison.OrdinalIgnoreCase)) // this part compares the string when the user types 'v' before the version number. We're comparing to the string representation of the enum value and ignoring differences in casing.
                {
                    return VersionToCall.V1;
                }
                else if (input ==
                    ((int)VersionToCall.V2).ToString() // this part compares the string when the user typed an integer only; we grab the backing int value of the enum and convert it to a string for comparison since input from the console is always a string. Just like the V1 part above.
                    || string.Equals(input, VersionToCall.V2.ToString(), StringComparison.OrdinalIgnoreCase)) // similar to input == "v2" || input == "V2", except we're ignoring any potential differences in casing (upper/lower). Just like the V1 part above.
                {
                    return VersionToCall.V2;
                }
            }
            
            return VersionToCall.Unknown;
        }

        /// <summary>
        /// We know we're going to prompt the user at least once, so we can use a do/while loop instead of a while loop to indicate that.
        /// </summary>
        /// <param name="userPrompt">This will be the prompt displayed to the user.</param>
        /// <returns>The input from the user, after it's confirmed to be valid</returns>
        /// <exception cref="ArgumentException">Thrown if the userPrompt is null or empty</exception>
        private static VersionToCall GetValidVersionInputFromUser(string userPrompt)
        {
            if (string.IsNullOrWhiteSpace(userPrompt))
            {
                throw new ArgumentException("userPrompt cannot be null, empty, or whitespace.", nameof(userPrompt));
            }

            var userInput = string.Empty;
            var versionToCall = VersionToCall.Unknown;
            var isRetry = false;

            do
            {
                if (isRetry)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                isRetry = true; // unless input is valid, then every subsequent attempt is a retry.

                Console.WriteLine(userPrompt);
                userInput = Console.ReadLine();
                
                versionToCall = ConvertUserInputToVersion(userInput);

            } while (versionToCall == VersionToCall.Unknown); 
            
            return versionToCall; 
        }

        private static void CallSpecifiedVersion(VersionToCall versionToCall)
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

            //// this is an if / else if / if statement. 
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

        /// <summary>
        /// unused. See the version of this method that uses a do/while loop instead of a while loop.
        /// </summary>
        /// <param name="userPrompt">This will be the prompt displayed to the user.</param>
        /// <returns>The input from the user, after it's confirmed to be valid</returns>
        /// <exception cref="ArgumentException"></exception>
        //private static VersionToCall GetValidVersionInputFromUserWithWhileInsteadOfDoWhile(string userPrompt)
        //{
        //    if (string.IsNullOrWhiteSpace(userPrompt))
        //    {
        //        throw new ArgumentException("userPrompt cannot be null, empty, or whitespace.", nameof(userPrompt));
        //    }

        //    var versionToCall = VersionToCall.Unknown; // this is the variable we'll return at the end of the method. We update it from within the while loop.
        //    var userInput = string.Empty;
        //    var loopCounter = 0;
        //    while (versionToCall == VersionToCall.Unknown)
        //    {
        //        if (loopCounter > 0)
        //        {
        //            Console.WriteLine("Invalid input. Please try again.");
        //        }
        //        Console.WriteLine(userPrompt);
        //        userInput = Console.ReadLine();
        //        versionToCall = ConvertUserInputToVersion(userInput);

        //        loopCounter++;
        //    } 

        //    return versionToCall; 
        //}
    }
}
