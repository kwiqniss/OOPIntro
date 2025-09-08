# OOPIntro
Code samples included. [Video demonstration](https://youtu.be/6cQaLeHo4CU)

Code sample was updated after the vid to 
- include info on using the public setter for NickName and displaying the updated introduction:

             student.NickName = "Janey"; 
             student.Speak();
 
- Also added another student and demonstrate a sample of foreach with an array:
  
             var students = new Student[]
             {
               new Student("Jane", "Doe", 170, GradeLevel.Sophomore, JanesEyes, "JD"),
               new Student("Samuel", "Winchester", 193, GradeLevel.Freshman, SamuelsEyes) // notice, we didn't provide a nickname. Because the Student constructor has a default value for the nickname parameter, we can choose to provide it or not.
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

- Added demonstration of components with custom types. Student now has a property for Eyes, which is a collection of Eye objects. Shows const and readonly variables too. 

             public Eye[] Eyes { get; }
  
Errata: optional parameters to a method seem to need a default value. The string? for optional works for variables/properties, but methods seem to require a default value for optional parameters. I'm surprised and need to test this further. For now, I showed the traditional approach to making a parameter optional by giving it a default value and moving it to the end of the method signature.

             public Person(string firstName, string lastName, int heightInCm, Eye[] eyes, string nickName = "")
 
             //…             
             public class Student : Person, IReceiveInstruction
             //…
             public Student(string firstName, string lastName, int heightInCm, GradeLevel gradeLevel, Eye[] eyes, string nickName = "") : base(firstName, lastName, heightInCm, eyes, nickName)
             
             //…
             new Student("Jane", "Doe", 170, GradeLevel.Sophomore, JanesEyes, "JD"),
             new Student("Samuel", "Winchester", 193, GradeLevel.Freshman, SamuelsEyes)
