using OopIntroLib.Logger;

namespace OopIntroLib.PersonComponents
{
    public interface IAmAPerson
    {
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }
        int HeightInCm { get; set; }
        string? NickName { get; set; }
        void GiveIntroduction();
        void Listen(string? message);
    }

    public abstract class Person : IAmAPerson
    {
        public static string Genus => "Homo";

        public static string Species => "Sapien";

        private ILogger? _logger { get; set; }

        private ILogger? _notebook { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public abstract string FullName { get; } // this must be implemented by derived classes

        public string? NickName { get; set; }

        public int HeightInCm { get; set; }

        // Here, our Person is actually comprised of many other objects. These can be thought of as components. The idea is that an object consists of a number of components. Each component is an object too. Note, that the Eye itself might consist of additional components.
        public Eye[] Eyes { get; }

        // The following bit of code has a parameter at the end of the signature that has a default value in case the caller doesn't provide one. It is an optional parameter. For the default to be null, the type must be nullable, hence the ? after string.
        public Person(
            string firstName,
            string lastName, 
            int heightInCm, 
            Eye[] eyes, 
            string? nickName = null, 
            ILogger? logger = null, 
            ILogger? notebook = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HeightInCm = heightInCm;
            this.Eyes = eyes;
            this.NickName = nickName;
            this._logger = logger;
            this._notebook = notebook;
        }

        public virtual void GiveIntroduction()
        {
            this.Speak($"Hello, my name is {FullName} and I am {HeightInCm} cm tall.");
        }

        protected virtual void Speak(string? message) // protected means that people that extend this class can use/override this property, but no one outside of this class or derived classes can use it.
        {
            this._logger?.WriteLine(message);
        }

        public virtual void Listen(string? message)
        {
            if (this.isImportant(message))
            {
                this.writeNote(message);
            }
        }

        // no one outside of this class should care how I take my notes, or that I do. They tell us to listen, then we decide what to do with that information.
        private void writeNote(string? note)
        {
            var messageForUserToWrite = $"I, {FullName}, am writing a note that says exactly what you told me... ";
            // Debug messages only occur when you're debugging.
            // If you run without debugging, these messages don't go anywhere; that's what logging is for, which is a topic for another date.
            // If you don't see the output, use visual studio's search, or the View category, to find "Output" and open the Output window. Then Show output from "Debug" in the dropdown of the output window, which by default will appear at the bottom of the editor. 
            // Also: the conditional operator (?:) is a ternary operator. It takes three operands. The first is a condition to evaluate. If that condition is true, the second operand is returned. If the condition is false, the third operand is returned.
            this._notebook?.WriteLine(
                string.IsNullOrWhiteSpace(note)
                    ? "You told me to write a note, but you didn't tell me what to write." // this is the if part
                    : $"{messageForUserToWrite} {note}."); // this is the else part
            this._notebook?.WriteLine(string.Empty);

            this._logger?.WriteLine($"{messageForUserToWrite} See debug output for notes."); // let's write a message to the logger to say the person took a note, but without including the note so as to keep the output in the logger itself more brief.

            /// Write a different message if it's empty or whitespace at the end of our string. Let's write notes in the Debug output instead of Console.
            //if (!string.IsNullOrWhiteSpace(message))
            //{
            //    Debug.WriteLine($"Writing a note... {message}.");
            //}
            //else
            //{
            //    Debug.WriteLine("You told me to write a note, but you didn't tell me what to write.");
            //}


            //string.IsNullOrWhiteSpace(message) ? Debug.WriteLine("You told me to write a note, but you didn't tell me what to write.") : Debug.WriteLine($"Writing a note... {message}.");

            /// This is the same as the previous line, but broken into two steps for clarity. It creates a variable unnecessarily though.
            //var messageToWrite = string.IsNullOrWhiteSpace(message)? "You told me to write a note, but you didn't tell me what to write." : $"Writing a note... {message}.";
            //Debug.WriteLine(messageToWrite);

            /// Really basic Do nothing if it's null. Write a message to the console otherwise, even if it's empty or whitespace at the end of our string.
            //if (message is null)
            //{
            //    return; // or log it, or throw exception, or set a default... etc.`
            //}
            //Console.WriteLine($"Writing a note... {message}.");
        }

        // no one else needs to know whether we think what they're saying is important, unless we decide to tell them.
        private bool isImportant(string? message)
        {
            return !string.IsNullOrWhiteSpace(message);
        }
    }
}
