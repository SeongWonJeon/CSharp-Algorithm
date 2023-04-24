namespace _06._Heap
{
    internal class Program
    {
        /******************************************************
		 * 힙 (Heap)
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 ******************************************************/
        // 오름차순 (acsending)
        static void PriorityQueue()
        {
            // 기본 int 우선순위(오름차순) 적용
            PriorityQueue<string, int> acsendingPQ = new PriorityQueue<string, int>();

            acsendingPQ.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            acsendingPQ.Enqueue("데이터2", 3);
            acsendingPQ.Enqueue("데이터3", 5);
            acsendingPQ.Enqueue("데이터4", 2);
            acsendingPQ.Enqueue("데이터5", 4);

            while (acsendingPQ.Count > 0) Console.WriteLine(acsendingPQ.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력

            // 내림차순 desending
            // 수정 int 우선순위 적용
            PriorityQueue<string, int> desendingPQ = new PriorityQueue<string, int>(Comparer<int>.Create((a, b) => b - a));

            desendingPQ.Enqueue("데이터1", 1);     // 우선순위와 데이터를 추가
            desendingPQ.Enqueue("데이터2", 3);
            desendingPQ.Enqueue("데이터3", 5);
            desendingPQ.Enqueue("데이터4", 2);
            desendingPQ.Enqueue("데이터5", 4);

            while (desendingPQ.Count > 0) Console.WriteLine(desendingPQ.Dequeue()); // 우선순위가 높은 순서대로 데이터 출력

            
        }

        static void Main(string[] args)
        {
            
        }
    }
}