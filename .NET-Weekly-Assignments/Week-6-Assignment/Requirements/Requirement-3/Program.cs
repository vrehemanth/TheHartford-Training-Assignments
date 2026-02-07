using System.Text.RegularExpressions;

namespace Requirement_3
{
    internal class Program
    {
        static bool ValidateRegistrationNo(string registrationNo)
        {
            // Regex 
            string pattern = @"^[A-Z]{2}\s\d{1,2}(\s[A-Z]{1,2})?\s\d{1,4}$";

            return Regex.IsMatch(registrationNo, pattern);
        }
        static void Main(string[] args)
        {
            try
            {
                // Enter Registration number
                Console.Write("Enter the registration no. to be validated: ");
                string registrationNo = Console.ReadLine();

                bool isValid = ValidateRegistrationNo(registrationNo);

                if (isValid)
                    Console.WriteLine("Registration No. is valid");
                else
                    Console.WriteLine("Registration No. is invalid");
            }
            // Handles empty or invalid input safely
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occurred");
            }
        }
    }
}
