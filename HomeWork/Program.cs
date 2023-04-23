using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HomeWork.List<int> list = new HomeWork.List<int>();
            for (int i = 0; i < 5; i++) list.Add(i);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }



            HomeWork.LinkedList<int> lists = new HomeWork.LinkedList<int>();
            for (int u = 0; u < 5; u++) list.Add(u);

            foreach (int u in lists)
            {
                Console.WriteLine(u);
            }



            HomeWork.Stack<int> stack = new HomeWork.Stack<int>();
            for (int i = 0; i < 5; i++) { stack.Push(i); }

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            stack.Clear();
            Console.WriteLine(stack.Peek());
        }
    }
}