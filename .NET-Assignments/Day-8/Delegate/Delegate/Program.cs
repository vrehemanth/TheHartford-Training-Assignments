namespace Delegate
{
    delegate void Print();
    class Money
    {
        protected int notes;
        protected int coins;
        public Money(int n,int c)
        {
            this.notes = n;
            this.coins = c;
        }
    }
    class Rupees : Money
    {
        public Rupees(int rupee,int paise) : base(rupee, paise) { }
        public void Display()
        {
            Console.WriteLine($"Rs. {notes}.{coins}");
        }
    }
    class Dollar : Money
    {
        public Dollar (int dollars,int cent):base(dollars, cent) { }
        public void Display()
        {
            Console.WriteLine($"$ {notes}.{coins}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rupees m1 = new Rupees(1000, 55);
            Dollar m2 = new Dollar(100, 75);
            Print GP=m1.Display;
            GP();
            GP =m2.Display;
            GP();
        }
    }
}
