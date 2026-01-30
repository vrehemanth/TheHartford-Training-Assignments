using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Basic_C_Sharp_Programs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            do
            {
                Console.WriteLine("Choose an option from below, Enter -1 to exit\n");
                Console.WriteLine("1. Add Two Numbers");
                Console.WriteLine("2. Swap Two Numbers");
                Console.WriteLine("3. Multiplication Table");
                Console.WriteLine("4. Celsius to Kelvin and Fahrenheit");
                Console.WriteLine("5. Average of 4 numbers");
                Console.WriteLine("6. Sum of first n Prime numbers");
                Console.WriteLine("7. Swap First and Last Characters");
                Console.WriteLine("8. Sum of Digits in Integer");
                Console.WriteLine("9. File Size in Bytes");
                Console.WriteLine("10. Hexadecimal to Decimal\n");
                Console.Write("Option: ");
                option=int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1: AddTwoNumbers(); break;
                    case 2: SwapTwoNumbers(); break;
                    case 3: MultiplicationTable(); break;
                    case 4: CelsiusToKelANDFah(); break;
                    case 5: Average4(); break;
                    case 6: PrimeSum(); break;
                    case 7: SwapChars(); break;
                    case 8: SumOfDigits(); break;
                    case 9: FileSize(); break;
                    case 10: HexaToDeci(); break;
                    case -1: Console.WriteLine("Exiting Program"); break;
                    default: Console.WriteLine("Enter Valid Option\n"); break;
                }
            } while (option != -1);
        }
        static void AddTwoNumbers()
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(a+" + "+b+ " = "+ (a + b)+"\n");
        }
        static void SwapTwoNumbers()
        {
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            a=a^b;
            b=b^a;
            a=a^b;
            Console.WriteLine("Numbers after swapping\na = " + a + " and b = " + b + "\n");
        }
        static void MultiplicationTable()
        {
            Console.Write("Enter a number: ");
            int n= int.Parse(Console.ReadLine());
            Console.WriteLine("Multiplication Table of "+n+" is: \n");
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(n + " * " + i + " = " + (n * i));
            }
            Console.WriteLine();
        }
        static void CelsiusToKelANDFah()
        {
            Console.Write("Enter the amount of Celsius: "); 
            int celsius = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Kelvin = {0}", celsius + 273);
            Console.WriteLine("Fahrenheit = {0}", celsius * 18 / 10 + 32);
            Console.WriteLine();
        }
        static void Average4()
        {
            Console.Write("Enter first number: ");
            int n1= int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int n2= int.Parse(Console.ReadLine());
            Console.Write("Enter third number: ");
            int n3= int.Parse(Console.ReadLine());
            Console.Write("Enter fourth number: ");
            int n4= int.Parse(Console.ReadLine());
            double avg =(double) (n1 + n2 + n3 + n4) / 4;
            Console.WriteLine("Average = "+avg+"\n");
        }
        static void PrimeSum()
        {
            Console.Write("Enter a number: ");
            int n=int.Parse(Console.ReadLine());
            int s = 0;
            for(int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                for(int j=2;j<=Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    s += i;
                }
            }
            Console.WriteLine("Prime Numbers Sum = "+s+"\n");
        }
        static void SwapChars()
        {
            Console.Write("Enter a string: ");
            string s= Console.ReadLine();
            int n = s.Length;
            if (n > 1)
            {
                s=s.Substring(n - 1) + s.Substring(1, n - 2) + s.Substring(0, 1);
            }
            Console.WriteLine("String after replacement: " + s+"\n");
        }
        static void SumOfDigits()
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            int s = 0;
            while (n > 0)
            {
                s += n % 10;
                n /= 10;
            }
            Console.WriteLine("Sum = " + s+"\n");
        }
        static void FileSize()
        {
            FileInfo f = new FileInfo(@"F:\final\insurance-app-ang-21\db.json");
            Console.WriteLine("Size of a file: " + f.Length.ToString()+"\n");
        }
        static void HexaToDeci()
        {
            Console.Write("Enter a Hexadecimal number");
            string s=Console.ReadLine();
            int decValue = int.Parse(s, System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine("Decimal number: " + decValue+"\n");
        }
    }
}
