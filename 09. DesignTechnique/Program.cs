using System.Text;

namespace _09._DesignTechnique
{
    internal class Program
    {
        /******************************************************
		 * 알고리즘 설계기법 (Algorithm Design Technique)
		 * 
		 * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
		 * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
		 * 문제의 성질과 조건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용
		 ******************************************************/

        public static void Move(int count, int start, int end) // 7, 0, 2
        {
            if (count == 1)
            {
                // 이동
                int node = stick[start].Pop();
                stick[end].Push(node);
                Console.WriteLine($"{0} 에서 {1} 로 {2} 을(를) 움직여라");
                return;
            }
            // 3개의 배열중에 0번배열의start와 2번배열인 end를 뺀걸 => other로 저장
            int other = 3 - start - end;
            Move(count - 1, start, other);
            Move(1, start, end);
            Move(count - 1, other, end);
        }
        
        public static Stack<int>[] stick;

        // public static int CountTime(params int[] task) { return }

        static void Main(string[] args)
        {
            // 몇개의 탑인지
            int nodeCount = 7;
            // 옮겨질 수 있는 막대기의 수
            stick = new Stack<int>[3];
            // 
            for (int i = 0; i < stick.Length; i++)
            {
                stick[i] = new Stack<int>();
            }

            // 큰것부터 담아야하니
            for (int i = nodeCount; i > 0; i--)
            {
                stick[0].Push(i);
            }

            Move(nodeCount, 0, 2);

        }

    }
}