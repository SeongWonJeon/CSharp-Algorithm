using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._PathFinding
{
    internal class Astar
    {
        /******************************************************
		 * A* 알고리즘
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 ******************************************************/

        const int CostStraight = 10;        // 직선코스트는 10
        const int CostDiagonal = 14;        // 대각선코스트는 14로 초기화
        
        
        static Point[] Direction =          // Direction포인트 배열
        {
            // 4방향
            new Point(  0, +1 ),			// 상
			new Point(  0, -1 ),			// 하
			new Point( -1,  0 ),			// 좌
			new Point( +1,  0 ),			// 우
            // 8방향
			new Point( -1, +1 ),		    // 좌상
			new Point( -1, -1 ),		    // 좌하
			new Point( +1, +1 ),		    // 우상
			new Point( +1, -1 )		        // 우하
		};

        // 만든 타일맵, 플레이어의 시작위치, 끝위치인 나가는 지점좌표를 받아오고 지나갈 수 있는 경로를 반환한다.
        public static bool PathFinding(in bool[,] tileMap, in Point start, in Point end, out List<Point> path)
        {
            int ySize = tileMap.GetLength(0);       // y의 좌표길이를 많이 사용할 거 같으니 받아오고
            int xSize = tileMap.GetLength(1);       // x의 좌표길이도 받아온다

            ASNode[,] nodes = new ASNode[ySize, xSize];         // 노드(정점들을 담을 수 있는 배열)을 만든다.
            bool[,] visited = new bool[ySize, xSize];           // 그 좌표가 탐색이 되어있는지 안되어있는지 알아보기위한 bool형으로 초기화
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();      // 우선순위Queue를 사용해서 정점과 f값을 넣어서 사용하기위해 만든다.

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));   // 시작위치로부터 부모노드가 없고, g값은 0이고, h값은 Heuristic함수를 이용해서 계산
            nodes[startNode.point.y, startNode.point.x] = startNode;                // 정점들의 배열
            nextPointPQ.Enqueue(startNode, startNode.f);            // 우선순위 queue에 startNode, startNode.f를 넣어주고

            // nextPointPQ가 비어있을 때 까지
            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();    // 다음으로 탐색할 정점을 꺼내서 담아준다

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;     // 방문표시를 해준다

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x && nextNode.point.y == end.y) // 탐색할 경우 탐색할 지점이 도착지점인 경우 탐색이 완료되었으니 끝내주기위해서
                {
                    Point? pathPoint = end;
                    path = new List<Point>();

                    while (pathPoint != null)   // 출발정점 노드일때 까지
                    {
                        Point point = pathPoint.GetValueOrDefault();    // pathPoint가 null일수도 있어서GetValueOrDefault넣어줘야함
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();     // 끝지점부터 넣었으니 Reverse를 통해서 넣은 경로를 역순으로 바꿔줘야한다.
                    return true;
                }

                // 4. AStar 탐색을 진행
                // 방향 탐색
                for (int i = 0; i < Direction.Length; i++)      // 도착지가 아니라면 탐색을 진행
                {
                    int x = nextNode.point.x + Direction[i].x;      // 탐색해야할 x,y좌표
                    int y = nextNode.point.y + Direction[i].y;

                    // 4-1. 탐색하면 안되는 경우 - 제외의 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == false)    // 벽같은 경우
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])             // 이미 방문 했다면, 이미 탐색을 했다면
                        continue;

                    // 4-2. 탐색한 정점 만들기              // 탐색하기 (f값을 결정해준다고 볼 수 있다.)
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Point(x, y), end);
                    ASNode newNode = new ASNode(new Point(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            // 경로를 못찿았다면 경로가 없었다로 반환
            path = null;
            return false;
        }

        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristic(Point start, Point end)        // 시작위치에서 끝위치를 넣어주면 h의 값을 구해주는 함수
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        // 정점
        private class ASNode             // AStarNode
        {
            public Point point;          // 현재 정점의 위치
            public Point? parent;        // 이 정점을 탐색한 정점 - 어떤 정점에 의해서 탐색이 되었는지
                     // ? 는 부모노드가 없을 수도 있다.의 의미를                  
            public int f;                // f(x) = g(x) + h(x);
            public int g;                // 현재까지의 거리, 즉 지금까지 경로 가중치
            public int h;                // (휴리스틱)앞으로 예상되는 거리, 목표까지 추정 경로 가중치

            // 초기화 작업
            public ASNode(Point point, Point? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }
    }

    // 위치에 대한 정보가 필요하기때문에 좌표의 값 구조체를 하나 만들어준다
    public struct Point
    {
        public int x;
        public int y;

        // 좌표 초기화
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
