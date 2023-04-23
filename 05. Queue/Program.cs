namespace _05._Queue
{
    internal class Program
    {
        /******************************************************
		 * 큐 (Queue)
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

        void Queue()
        {
            Queue<int> queue = new Queue<int>();

            // Queue같은 경우는 Enqueue로 넣을 수 있다
            for (int i = 0; i < 10; i++) queue.Enqueue(i);                   // 입력순서 : 0, 1, 2, 3, 4, 5, 6, 7, 8, 9

            // 가장앞에 뭐가 있는지는 Peek으로
            Console.WriteLine(queue.Peek());                                // 최전방 : 0

            // 출력으로는 Dequeue로 진행할 수 있다
            while (queue.Count > 0) Console.WriteLine(queue.Dequeue());     // 출력순서 : 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        }
        static void Main(string[] args)
        {
            
        }
    }
}