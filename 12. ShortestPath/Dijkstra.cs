﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12._ShortestPath
{
    internal class Dijkstra
    {
        /******************************************************
		 * 다익스트라 알고리즘 (Dijkstra Algorithm)
		 * 
		 * 특정한 노드에서 출발하여 다른 노드로 가는 각각의 최단 경로를 구함
		 * 방문하지 않은 노드 중에서 최단 거리가 가장 짧은 노드를 선택 후,
		 * 해당 노드를 거쳐 다른 노드로 가는 비용 계산
		 ******************************************************/

        const int INF = 99999;

        public static void ShortestPath(int[,] graph, int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];

            distance = new int[size];
            path = new int[size];
            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start,i];
                path[i] = graph[start, i] < INF ? start : INF;
            }

            for (int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    // 정점j가 방문되지 않았거나, 정점 j와의 거리가 현재까지 구한 거리보다 짧으면
                    if (!visited[j] && distance[j] < minCost)
                    {
                        // 방문한 j의 거리가 방문한 정점과의 거리가 되고
                        next = j;
                        // 현재거리를 정점 j와의 거리로 지정
                        minCost = distance[j];
                    }
                }

                // 2. 직접 연결된 거리보다 거쳐서 더 짧아진다면 갱신
                for (int j = 0; j < size; ++j)
                {
                    // cost[j] : 목적지까지 직접 연결된 거리
                    // cost[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        // 
                        distance[j] = distance[next] + graph[next, j];
                        // 
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }







        public static void ShortestPath(in int[,] graph, in int start, out int[] distance, out int[] path)
        {
            int size = graph.GetLength(0);
            bool[] visited = new bool[size];

            distance = new int[size];
            path = new int[size];
            for (int i = 0; i < size; i++)
            {
                distance[i] = graph[start, i];
                path[i] = graph[start, i] < INF ? start : -1;
            }

            for (int i = 0; i < size; i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점부터 탐색
                int next = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    if (!visited[j] &&
                        distance[j] < minCost)
                    {
                        next = j;
                        minCost = distance[j];
                    }
                }
                if (next < 0)
                    break;

                // 2. 직접연결된 거리보다 거쳐서 더 짧아진다면 갱신.
                for (int j = 0; j < size; j++)
                {
                    // cost[j] : 목적지까지 직접 연결된 거리
                    // cost[next] : 탐색중인 정점까지 거리
                    // graph[next, j] : 탐색중인 정점부터 목적지의 거리
                    if (distance[j] > distance[next] + graph[next, j])
                    {
                        distance[j] = distance[next] + graph[next, j];
                        path[j] = next;
                    }
                }
                visited[next] = true;
            }
        }
    }
}
