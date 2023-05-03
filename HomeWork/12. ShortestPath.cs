using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class _12
    {
        // 현재 비어있는 곳을 표현하기 위해 지역의 값을 INF로 구현
        const int INF = 99999;

        static void Main(string[] args)
        {
            int[,] graph = new int[8, 8]
            {
                {0  , 7  , INF, INF, 5  , INF, INF, INF },
                {7  , 0  , 6  , 3  , INF, 4  , INF, INF },
                {INF, 6  , 0  , INF, INF, INF, INF, INF },
                {INF, 3  , INF, 0  , INF, INF, INF, INF },
                {5  , INF, INF, INF, 0  , INF, 4  , INF },
                {INF, 4  , INF, INF, INF, 0  , 1  , 3   },
                {INF, INF, INF, INF, 4  , 1  , 0  , INF },
                {INF, INF, INF, INF, INF, 3  , INF, 0   }
            };
            // 각 노드까지의 거리
            int[] distance;
            int[] path;
            ShortestPath(in graph, 0, out distance, out path);
        }


        /// <summary>
        /// 입력으로 2차원 배열 graph와 시작노드 start를 받고 출력으로 distance와 path를 받습니다.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <param name="distance"></param>
        /// <param name="path"></param>
        private static void ShortestPath(in int[,] graph, int start, out int[] distance, out int[] path)
        {
            // 그래프의 크기를 size로
            int size = graph.GetLength(0);
            // 방문여부를 체크하기 위해 그래프에 크기만큼의 배열 생성
            bool[] visited = new bool[size];

            // 각 노드까지의 거리를 저장하는 distance를 초기화
            distance = new int[size];
            // 최단경로를 저장하는 path를 초기화
            path = new int[size];
            // 그래프의 배열의 크기만큼 반복
            for (int i = 0; i < size; i++)
            {
                // start에서 i노드까지의 초기거리를 graph의 값으로설정
                distance[i] = graph[start, i];
                // 방문할 곳이 연결이 되어있다면 시작지점을 반환 그렇지 않으면 INF반환
                path[i] = graph[start, i] < INF ? start : INF;
            }
            // for문 2개를 하나로 봐서 (start, (0, 1, 2, 3, 4, 5, 6, 7))을 시작으로 다 돌다보면서
            // 방문하지 않은 노드들 중에서 가장 가까운 노드를 찾는다.
            for(int i = 0; i < size; i++)
            {   
                // 찾은 다음 노드를 저장하기 위해서 노드가 없음을 나타내는 -1로 초기화
                int next = -1;
                // 다음 노드까지의 거리의 최소값을 저장하기 위해 최대값으로 설정
                int minCost = INF;
                for(int j = 0; j < size; j++)
                {
                    // 만약 정점 j visited[j]에 방문하지 않았거나, 정점j까지의 거리가 기존거리보다 짧다면
                    if (!visited[j] && distance[j] < minCost)
                    {
                        // 다음j 노드를 next로 저장
                        next = j;
                        // j까지의 거리를 최소값으로 저장
                        minCost = distance[j];
                    }
                }

                // 찾은 노드보다 더 짧은 거리가 있다면, 기존거리에 더 짧은 거리를 저장
                for (int j = 0; j < size; j++)
                {
                    // 만약 기존의 찾은 거리보다 더 짧다면
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        // j까지의 거리를 다음 노드까지의 최소값으로 초기화
                        distance[j] = distance[next] + graph[next, j];
                        // 최단 거리를 다음 노드로 초기화
                        path[j] = next;
                    }
                }
                // 다음 노드j에는 길이있고 거리를 구했으니 true로 저장
                visited[next] = true;
            }
        }
    }
}
