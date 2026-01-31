/*
    Boxing is a marƟal art and combat sport in which two people throw punches at each other, usually
    with gloved hands. Historically, the goals have been to weaken and knock down the opponent. In
    December 2025, the World Boxing Council, World Boxing AssociaƟon and the InternaƟonal Boxing
    FederaƟon reached an agreement to standardize the names for January 2026 onwards, of the different
    weight categories under which Boxing matches are conducted.

    John is a good boxer and he wants to know under what category he should enrol his name.
    Can you please help him out?

    Input Format :
    Input consists of an integer that corresponds to John's weight.

    Output Format :
    Output consists of a string that corresponds to any of the category names listed above or “Invalid Input”.
    Print Invalid Input if the weight is negative or if the weight is greater than 120. 
*/

namespace Exercise_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("John's Weight Classification\n");
            Console.Write("Enter John's Weight: ");
            string s=Console.ReadLine();
            int.TryParse(s, out int weight);

            if (weight < 0 || weight > 120)
            {
                Console.WriteLine("Invalid Input");
            }
            else if (weight <= 48)
            {
                Console.WriteLine("Light Fly");
            }
            else if (weight <= 51)
            {
                Console.WriteLine("Fly");
            }
            else if (weight <= 54)
            {
                Console.WriteLine("Bantam");
            }
            else if (weight <= 57)
            {
                Console.WriteLine("Feather");
            }
            else if (weight <= 60)
            {
                Console.WriteLine("Light");
            }
            else if (weight <= 64)
            {
                Console.WriteLine("Light Welter");
            }
            else if (weight <= 69)
            {
                Console.WriteLine("Welter");
            }
            else if (weight <= 75)
            {
                Console.WriteLine("Light Middle");
            }
            else if (weight <= 81)
            {
                Console.WriteLine("Middle");
            }
            else if (weight <= 91)
            {
                Console.WriteLine("Light Heavy");
            }
            else
            {
                Console.WriteLine("Heavy");
            }
        }
    }
}
