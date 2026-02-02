namespace Distance
{
    internal class Program
    {
        static void convertKm(double km, out double meters, out double cm)
        {
            meters = km * 1000;
            cm = km * 100000;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter distance in KM: ");
            double.TryParse(Console.ReadLine(), out double km);

            convertKm(km, out double m, out double c);

            Console.WriteLine($"Meters: {m}, Centimeters: {c}");
        }
    }
}
