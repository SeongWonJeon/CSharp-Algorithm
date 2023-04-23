namespace _03._Iterator
{
    internal class Program
    {
        /******************************************************
		 * 반복기 (Enumerator(Iterator))
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
		 ******************************************************/


        static void Main(string[] args)
        {
            // 대부분의 자료구조가 반복기를 지원함
            // 반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedList<int, int> sList = new SortedList<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();

            // 반복기를 이용한 순회
            // foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복
            // 즉, 반복기가 있다면 foreach 반복문으로 순회 가능
            foreach (int i in list) { }
            foreach (int i in linkedList) { }
            foreach (int i in stack) { }
            foreach (int i in queue) { }
            foreach (int i in set) { }
            foreach (KeyValuePair<int, int> i in sList) { }
            foreach (KeyValuePair<int, int> i in map) { }
            foreach (KeyValuePair<int, int> i in dic) { }
            foreach (int i in IterFunc()) { }

            // 반복기 직접조작
            List<string> strings = new List<string>();
            for (int i = 0; i < 5; i++) strings.Add(string.Format("{0}데이터", i));

            IEnumerator<string> iter = strings.GetEnumerator();
            // MoveNext는 다음으로 넘겨준다
            iter.MoveNext();
            // 옮겼으면 Current로 출력한다
            Console.WriteLine(iter.Current);    // output : 0데이터
            iter.MoveNext();
            Console.WriteLine(iter.Current);    // output : 1데이터




            // Reset은 반복기가 무조건 처음으로 간다
            iter.Reset();
            while (iter.MoveNext())         // 반복문을 통해서 끝까지 반복하게 만든다면 이런식으로 만든다
            {
                // 이 반복문은 다음으로 넘기고 콘솔로 주고 이걸 반복하기때문에 -1부터 시작해야한다
                Console.WriteLine(iter.Current);
            }

            Iterator.List<int> lists = new Iterator.List<int>();
            for (int i = 0; i < 5; i++) list.Add(i);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            
            IEnumerator<int> iters = lists.GetEnumerator();
            while (iters.MoveNext())
            {
                Console.WriteLine(iters.Current);
            }
            iters.Reset();


        }

        private static IEnumerable<int> IterFunc()
        {
            yield return 0;
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}