using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Hanoi
    {
        public static void Move1(int TopCount, int start, int end, StringBuilder sb)
        {
            if (TopCount == 1)
            {
                int Mono = stick[start].Pop();
                stick[end].Push(Mono);
                sb.AppendLine($"{start}을 {end}로");
                return;     // void 반환형이기에 return만 가능
            }
            int Middle = 3 - start - end;
            Move1(TopCount - 1, start, Middle, sb);
            Move1(1, start, end, sb);
            Move1(TopCount - 1, Middle, end, sb);
        }

        public static Stack<int>[] stick;

        

        static void Main(string[] args)
        {
            Console.Write("하노이탑의 개수를 적으세요 : ");
            int TopCount = int.Parse(Console.ReadLine());
            stick = new Stack<int>[3];

            // 막대기안에 스택을 만들어서 값이 쌓일 수 있도록
            for (int i = 0; i < stick.Length; i++)
            {
                stick[i] = new Stack<int>();
            }
            // 스택의 첫번째 스택에 받은 수 만큼 큰수부터 넣어준다
            for (int i = TopCount; 0 < i; i--)
            {
                stick[0].Push(i);
            }

            StringBuilder sb = new StringBuilder();
            Move1(TopCount, 0, 2, sb);

            Console.WriteLine(sb.ToString());
        }
    }
}
