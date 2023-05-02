using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{
    internal class Searching
    {
        // <순차 탐색>
        //SequentialSearch 어떤자료라도 찾을 수 있는 탐색기
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IEquatable<T>
        {
            // 전부 순차적으로 탐색했을 때
            for (int i = 0; i < list.Count; i++)
            {
                // 동일한 자료를 찾았다면
                if (item.Equals(list[i]))
                    return i;
            }
            return -1;
        }
        // in 은 입력전용 안쪽에서 수정이 불가능하다  / out은 출력전용
        /*public static int BinarySearch<T>(in IList<T> list, in T item, int index, int count) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;
            while (low <= high)
            {
                // 중간위치를 찾고
                int middle = (int)((low + high) * 0.5f);
                // 지금있는 아이템과 비교해본다
                int compare = list[middle].CompareTo(item);
                // 지금있는 값이 더 크다면
                if (compare < 0)
                {
                    // 뒤에값들과 비교를 해야하니까
                    low = middle + 1;
                }
                // 지금있는 아이템이 더 작으면
                else if (compare > 0)
                {
                    // 앞에값들과 비교를 해야하니까
                    high = middle - 1;
                }
                else // 찾다가 중간값을 찾게 되면 미드값을 반환
                {
                    return middle;
                }
                return -1;
            }
        }*/
        // <이진 탐색> (BinarySearch)
        // List에도 이진탐색을 허용
        public static int BinarySearch1<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            return BinarySearch2(list, item, 0, list.Count);
        }

        public static int BinarySearch2<T>(in IList<T> list, in T item, int index, int count) where T : IComparable<T>
        {
            if (index < 0)
                throw new IndexOutOfRangeException();
            if (count < 0)
                throw new ArgumentOutOfRangeException();
            if (index + count > list.Count)
                throw new ArgumentOutOfRangeException();

            int low = index;
            int high = index + count - 1;
            while (low <= high)
            {
                int middle = low + (high - low) / 2;
                int compare = list[middle].CompareTo(item);

                if (compare < 0)
                    low = middle + 1;
                else if (compare > 0)
                    high = middle - 1;
                else
                    return middle;
            }

            return -1;
        }

        // <깊이 우선 탐색 (Depth-First Search)>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
        // 이방식은 백트래킹(분할정복)방식이다.
        public static void DFS(bool[,] graph, int start, bool[] visited, int[] parents) //visited갈 수 있는지, parents어떤 경로로 갈건지
        {
            // 정점을 알려줘야하니 한쪽 배열의 길이를 담아주고
            visited = new bool[graph.GetLength(0)];
            parents = new int[graph.GetLength(0)];

            // 그래프의 길이만큼 돌아가고
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                // 한번도 안방문한것과
                visited[i] = false;
                // 경로가 없다는 표시로 -1로 시작
                parents[i] = -1;
            }
            // 분할정복을 해야하니 분할정복용 SearchNode하나 만들기
            SearchNode(graph, start, visited, parents);
        }

        // 재귀를 통해 분할정복을 한다.
        private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] parents)
        {
            // 시작지점을 지정
            visited[start] = true;
            // 전체 정점들을 방문하면서 확인한다
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                // 스타트의 i번째 정점이
                if (graph[start, i] &&      // 연결되어 있는 정점이며,
                    !visited[i])            // 방문한적 없는 정점
                {
                    // 탐색된 정점이 시작지점에서 탐색이 되었다. 내 정점이 어떤 정점에서 왔는지.
                    parents[i] = start;
                    // 재귀함수로 
                    SearchNode(graph, i, visited, parents);
                }
            }
        }

        // <너비 우선 탐색 (Breadth-First Search)>
        // 그래프의 분기를 만났을 때 모든 분기를 저장한 뒤,
        // 저장한 분기를 하나씩 거치면서 탐색
        // 균등하게 분기마다 한칸씩 다 가보는 방식인 (동적계획법과 비슷하다)
        public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            // 크기
            visited = new bool[graph.GetLength(0)];
            // 크기
            parents = new int[graph.GetLength(0)];
            // 돌아가면서 없다면 -1로 저장
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>();

            // 처음에 탐색될 정점을 담아두고
            bfsQueue.Enqueue(start);
            // Queue가 비어있을 때까지 반복
            while (bfsQueue.Count > 0)
            {
                // 다음으로 탐색할 지점
                int next = bfsQueue.Dequeue();
                // 방문했다
                visited[next] = true;
                // 모든 정점들을 모두 돌면서
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[next, i] &&       // 연결되어 있는 정점이며,
                        !visited[i])            // 방문한적 없는 정점
                    {
                        //
                        parents[i] = next;
                        // 다음으로 찾을 값을 저장?
                        bfsQueue.Enqueue(i);
                    }
                }
            }
        }
    }
}
