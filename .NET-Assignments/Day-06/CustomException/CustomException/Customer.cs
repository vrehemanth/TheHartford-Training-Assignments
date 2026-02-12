using System;

namespace CustomException
{
    internal class Customer
    {
        private string name;
        private int AccountNumber;
        private int Balance;

        public Customer(string v1, int v2, int v3)
        {
            this.name = v1;
            this.AccountNumber = v2;
            this.Balance = v3;
        }
        public void withdraw(int amt)
        {
            if (Balance - amt <= 100)
                throw new BankException(AccountNumber, Balance);
            Balance -= amt;
        }
        public int getbalance() { return Balance; }
    }
}