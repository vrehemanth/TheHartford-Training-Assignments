/*
    Exercise 2:

    Mahi has learnt about the different properties of circles like radius, centre, diameter, circumference ...
    To make the tutorial class on circles more interesƟng, her teacher organises a game.
    The players will be given 2 circles --- One circle A with radius ra and with central coordinate (xa, ya)
    and second circle B with radius rb and with central coordinate (xb, yb).
    The player needs to say
    • B is in A
    • A is in B
    • A and B intersect
    • A and B do not intersect
    You may assume that A and B are not idenƟcal. Can you please help Mahi in solving this game?
*/

using System;
using System.Runtime.InteropServices;
namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Properties of Circles\n");

            Console.WriteLine("Enter Circle-1 Properties");
            Console.Write("Enter radius of Circle-1: ");
            string sra= Console.ReadLine();
            double.TryParse(sra, out double ra);
            Console.Write("Enter the x-coordinate of Circle-1: ");
            string sxa = Console.ReadLine();
            double.TryParse(sxa, out double xa);
            Console.Write("Enter the y-coordinate of Circle-1: ");
            string sya = Console.ReadLine();
            double.TryParse(sya, out double ya);

            Console.WriteLine("Enter Circle-2 Properties");
            Console.Write("Enter radius of Circle-2: ");
            string srb = Console.ReadLine();
            double.TryParse(srb, out double rb);
            Console.Write("Enter the x-coordinate of Circle-1: ");
            string sxb = Console.ReadLine();
            double.TryParse(sxb, out double xb);
            Console.Write("Enter the y-coordinate of Circle-1: ");
            string syb = Console.ReadLine();
            double.TryParse(syb, out double yb);

            double dis=Math.Sqrt(Math.Pow(xb-xa, 2)+Math.Pow(yb-ya, 2));

            Console.WriteLine();
            if (dis + rb <= ra)
                Console.WriteLine("B is in A");
            else if (dis + ra <= rb)
                Console.WriteLine("A is in B");
            else if (dis <= ra + rb)
                Console.WriteLine("A and B intersect");
            else
                Console.WriteLine("A and B do not intersect");
            Console.WriteLine();
        }
    }
}
