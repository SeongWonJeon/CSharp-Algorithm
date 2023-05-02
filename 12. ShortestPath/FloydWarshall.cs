using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    internal class FloydWarshall
    {
        /******************************************************
		 * 플로이드-워셜 알고리즘 (Floyd-Warshall Algorithm)
		 * 
		 * 모든 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 모든 노드를 거쳐가며 최단 거리가 갱신되는 조합이 있을 경우 갱신
		 ******************************************************/

        const int INF = 99999;

        // [,]시작정점부터 끝정점까지
        public static void ShortestPath(in int[,] graph, out int[,] costTable, out int[,] pathTable)
        {
            // 사이즈를 저장
            int count = graph.GetLength(0);
            costTable = new int[count, count];
            pathTable = new int[count, count];

            // 전체 배열을 모두 확인하면서
            for (int y = 0; y < count; y++)
            {
                for (int x = 0; x < count; x++)
                {
                    // 
                    costTable[y, x] = graph[y, x];
                    // 아직 진행 전이니까 -1 로 둔다
                    pathTable[y, x] = (graph[y, x] > INF) ? y : -1;
                }
            }

            // 중간을 거쳐서 가는 경우
            for (int middle = 0; middle < count; middle++)
            {
                // 시작부터 거쳐서 가는 경우
                for (int start = 0; start < count; start++)
                {
                    // 끝을 가는 경우
                    for (int end = 0; end < count; end++)
                    {
                        // 만약 시작지점에서 끝까지 가는경우보다 시작에서 중간을 거쳐 끝으로 가는 경우가 더 짧다면
                        if (costTable[start, end] > costTable[start, middle] + costTable[middle, end])
                        {
                            // 그 경우를 시작에서 끝까지 가는 경우로 변경
                            costTable[start, end] = costTable[start, middle] + costTable[middle, end];
                            pathTable[start, end] = middle;
                        }
                    }
                }
            }
        }
    }
}
