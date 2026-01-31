namespace SalaryCalculator
{
    public class SalaryCalculation
    {
        public static double CalculateNetSalary(double basicSalary)
        {
            double hra = 0.20 * basicSalary;
            double da = 0.10 * basicSalary;
            double pf = basicSalary < 15000 ? 0 : 0.12 * basicSalary;

            return basicSalary + hra + da - pf;
        }
    }
}
