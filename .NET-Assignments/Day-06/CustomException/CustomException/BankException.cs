
namespace CustomException
{
    [Serializable]
    internal class BankException : Exception
    {
        int AccountNumber;
        int Balance;
        public BankException(int acc, int bal)
        {
            this.AccountNumber = acc;
            this.Balance = bal;
        }
        public void inform()
        {
            Console.WriteLine($"Account number: {AccountNumber} Balance left: {Balance}");
        }

    }
}