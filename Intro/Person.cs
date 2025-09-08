namespace Intro
{
    public class Person
    {
        private string _firstName;
        public string GetFirstName()
        {
            return this._firstName;
        }
        public void SetFirstName(string firstName)
        {
            this._firstName = firstName;
        }

        public string LastName { get; private set; }

        //public string FullName => $"{this._firstName} {this.LastName}";
        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.NickName))
                {
                    //return this._firstName + this.LastName;
                    return $"{this._firstName} {this.LastName}";
                }

                return this._firstName + " '" + this.NickName + "' " + this.LastName;
                //return $"{this._firstName} '{this.NickName}' {this.LastName}";
            }
        }

        public string NickName { get; set; }

        public int HeightInCm { get; set; }

        public Person(string firstName, string lastName, int heightInCm, string? nickName)
        {
            this._firstName = firstName;
            this.LastName = lastName;
            this.HeightInCm = heightInCm;

            this.NickName = nickName;
        }

        public void Speak()
        {
            Console.WriteLine($"Hello, my name is {this.FullName} and I am {this.HeightInCm} cm tall.");
        }

        public void Listen()
        {
            var message = Console.ReadLine(); 
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
