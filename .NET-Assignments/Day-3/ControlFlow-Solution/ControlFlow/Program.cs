namespace ControlFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s= Console.ReadLine();
            int.TryParse(s, out int n);
            int[] arr=new int [n];
            string[] v = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++) {
                int.TryParse(v[i], out arr[i]);
                Console.Write(arr[i]+" ");
            }
        }
    }
}
