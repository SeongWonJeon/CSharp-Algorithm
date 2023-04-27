using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HomeWork
{
    /*자연수 N과 M이 주어졌을 때, 아래 조건을 만족하는 길이가 M인 수열을 모두 구하는 프로그램을 작성하시오.
     * 1부터 N까지 자연수 중에서 M개를 고른 수열 같은 수를 여러 번 골라도 된다.*/
    
    public class N_And_M
    {
        static bool[] istrue;
        static string[] input_line;
        static int[] result;
        static StringBuilder sb;
        

        static void BackTracking(int N)
        {
            if (N == int.Parse(input_line[1]))
            {
                for(int write = 0; write < N; write++)
                {
                    sb.Append(result[write] + " ");
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            for(int i = 0; i < int.Parse(input_line[0]); i++)
            {
                if (!istrue[i])
                {
                    istrue[i] = true;
                    result[N] = i;
                    BackTracking(N + 1);
                    istrue[i] = false;
                }
            }
        }
        static void Main(string[] args)
        {
            sb = new StringBuilder();
            input_line = Console.ReadLine().Split();
            istrue = new bool[int.Parse(input_line[0]) + 1];
            result = new int[int.Parse(input_line[0])];

            BackTracking(0);
        }
    }
}
