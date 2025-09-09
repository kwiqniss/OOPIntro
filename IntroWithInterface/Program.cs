namespace IntroWithInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IAmAPerson bob = new Person("Robert", "Smith", 180, "Bob");
            bob.Speak();

            Console.WriteLine("What do you want to tell bob?");
            bob.Listen();

            Console.WriteLine("Thanks Bob");

            Console.WriteLine();
            Console.Write("press any key to exit...");
            Console.Read();
        }
    }
}
