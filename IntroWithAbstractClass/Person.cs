namespace IntroWithAbstractClass
{
    public interface IAmAPerson
    {
        string FirstName { get; }
        string LastName { get; }
        string FullName { get; }
        int HeightInCm { get; set; }
        string? NickName { get; set; }
        void Speak();
        void Listen(string? message);
    }
    public abstract class Person : IAmAPerson
    {
        public static string Genus => "Homous";
        public static string Species => "Sapien";

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public abstract string FullName { get; } // this must be implemented by derived classes

        public string? NickName { get; set; }

        public int HeightInCm { get; set; }

        public Person(string firstName, string lastName, int heightInCm, string? nickName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HeightInCm = heightInCm;
            this.NickName = nickName;
        }

        public virtual void Speak()
        {
            Console.WriteLine($"Hello, my name is {this.FullName} and I am {this.HeightInCm} cm tall.");
        }

        public virtual void Listen(string? message)
        {
            if (isImportant(message))
            {
                this.writeNote(message);
            }
        }

        // no one outside of this class should care how I take my notes, or that I do. They tell us to listen, then we decide what to do with that information.
        private void writeNote(string message)
        {
            Console.WriteLine($"Writing a note... {message}.");
        }

        // no one else needs to know whether we think what they're saying is important, unless we decide to tell them.
        private bool isImportant(string message)
        {
            return !string.IsNullOrWhiteSpace(message);
        }
    }
}
