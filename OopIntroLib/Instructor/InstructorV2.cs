using OopIntroLib.PersonComponents;
using OopIntroLib.Student;

namespace OopIntroLib.Instructor
{
    public class InstructorV2 : Person, IInstruct
    {
        //private readonly ICollection<IReceiveInstruction> _students;
        private ICollection<IReceiveInstruction> _students; // we could make a private property that returns the students, but unless either the getter or setter is exposed, that's unusual. Instead, we'll use a class level private variable.

        public InstructorV2(string firstName, string lastName, int heightInCm, Eye[] eyes, ICollection<IReceiveInstruction> students, string nickName = "") : base(firstName, lastName, heightInCm, eyes, nickName) 
        {
            _students = students;
        }

        public override string FullName => $"{FirstName} {LastName}";

        public override void Listen(string? message)
        {
            Console.WriteLine("Instructor is listening carefully...");
        }
        
        public void UpdatePresentStudents(ICollection<IReceiveInstruction> students) // ICollection is the interface for arrays and various other types of collctions.
        {
            _students = students;

            //// _students was readonly. The following code is less performant than simply re-assigning the collection, but it would have worked if we kept _students as readonly.
            //_students.Clear(); // That means we can't re-assign a new collection to it, but we can modify the contents of the existing collection; so we clear it first, then add the new students to it. In this case, I'd rather replace it, so I'm removing readonly.
            //// Other than from Clear(), another option might be to try to Merge the lists together, updating the ones that changed, deleting any that were removed, and adding any new ones. But that's more complex than we need for this example.
            //foreach (var student in students)
            //{
            //    _students.Add(student);
            //}
        }

        public void Instruct(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Instruction message cannot be null or empty.", nameof(message)); // No message to give. We can't instruct without a message, so throw an exception.
            }

            // this is similar to comparing if the length is greater than 0, but .Any is more clear. With some collection types, Length is a method, instead of a property.
            // Length is a property that's updated as the length changes, for the collection types that have a .Length property.
            // Calling .Length() method causes the program to loop over the entire collection to count the items, whereas .Any() can determine if there are any items without needing to count them all.
            if (_students == null || !_students.Any())
            {
                return; // No students to instruct, so exit early.
            }

            GiveIntroduction();

            Console.WriteLine("Instructor is allowing the students warning to prepare for receiving instruction...");
            foreach (var student in _students)
            {
                student.InstructionStarting();
            }

            Console.WriteLine("Instructor is instructing the class...");
            
            this.Speak(message);
            Console.WriteLine(); //blank line for console output

            foreach (var student in _students)
            {
                student.InstructionInProgress(message);
            }

            Console.WriteLine("Instructor has finished instructing the class.");
            Console.WriteLine();
            foreach (var student in _students)
            {
                student.InstructionComplete();
            }
            
            Console.WriteLine(string.Empty); // string.Empty is equivalent to "" Using it here to add a blank line in the console output after the instruction is complete.
        }
    }
}
