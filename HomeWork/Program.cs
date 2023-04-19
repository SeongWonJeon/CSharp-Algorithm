using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List 동적배열에 int만을 받아 정해지지않은 배열을 만들어줍니다.
            List<int> list = new List<int>();

            // list.Add를 통해 list에 0번째부터 어떤 int를 담을지 정하는 방법입니다.
            list.Add(1);
            // [0]번째 배열에 1
            list.Add(4);
            // [1]번째 배열에 4
            list.Add(7);
            // [2]번쨰 배열에 7
            list.Add(10);
            // [3]번째 배열에 10
            list.Add(5);
            // [4]번째 배열에 5


            list.IndexOf(1);
        }
    }
}