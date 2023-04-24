using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            // element는 요소, 성분, 구성의 뜻을 가짐
            public TElement element;
            // 우선순위값
            public int priority;
        }
        // List형식의 nodes를 생성
        private List<Node> nodes;

        // List<Node> nodes를 초기화.
        public PriorityQueue()
        {
            this.nodes = new List<Node>();
        }
        // node의 Count개수를 반환
        public int Count { get { return nodes.Count; } }

        public void Clear()
        {
            this.nodes = new List<Node>();
        }
        /// <summary>
        /// 들어갈 요소와 우선순위 값을 받아와서 배열에 넣는다.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="priority"></param>
        public void EnQueue(TElement element, int priority)
        {
            // 들어갈 요소element와 우선순위priority를 받아와서 새로운배열에 저장
            Node newNode = new Node() { element = element, priority = priority };
            // 배열의 요소를 nodes에 추가하기
            nodes.Add(newNode);
            // 노드의 개수를 반환
            int newNodeIndex = nodes.Count - 1;
            // 노드의 개수사 0보다 많으면 반복
            while (newNodeIndex > 0)
            {
                // 부모의 인덱스를 찾아서 매개변수에 저장
                int parentIndex = GetParentIndex(newNodeIndex);
                // 부모의 인덱스안에 있는 부모노드를 가져와 변수에 저장
                Node parentNode = nodes[parentIndex];
                // 만약 새로온 노드의 값이 부모의 값보다 (숫자가 낮을수록 높은것이니)높으면
                if (newNode.priority < parentNode.priority)
                {
                    // 새로운노드의 인덱스자리에 부모의 노드를 넣고
                    nodes[newNodeIndex] = parentNode;
                    // 원래있던 부모노드 인덱스자리에 새로운 노드 넣어주고
                    nodes[parentIndex] = newNode;
                    // 인덱스의 개수는 부모의 인덱스 수
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 리스트에서 노드를 뺀다
        /// </summary>
        public void DeQueue()
        {
            // 노드의 0번째 가장큰수를 저장
            Node rootNode = nodes[0];

            // 노드의 가장 마지막값을 저장
            Node lastNode = nodes[nodes.Count - 1];
            // 노드의 마지막 값을 노드의 0번째에 넣고
            nodes[0] = lastNode;
            // 가장 뒤에들어가있던 노드를 첫번째에 넣었으니 뒤에있는 노드를 제거
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            
            // index가 노드의 수보다 작으면 반복
            while (index < nodes.Count)
            {
                // 왼쪽에있는 자식 노드의 인덱스를 저장
                int leftChildIndex = GetLeftChildIndex(index);
                // 오른쪽에있는 자식 노드의 인덱스를 저장
                int rightChildIndex = GetRightChildIndex(index);

                // 자식이 둘다 있는 경우
                if (rightChildIndex < nodes.Count)
                {
                    // 왼쪽 자식과 오른쪽 자식을 비교하여 더 우선순위가 높은 자식을 선정
                    int lessChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority
                        ? leftChildIndex : rightChildIndex;

                    // 더 우선순위가 높은 자식과 부모 노드를 비교하여
                    // 부모가 우선순위가 더 낮은 경우 바꾸기를 진행
                    // 만약 자식의 값이 부모의 값보다 우선순위가 높으면
                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        // 자식의 값을 부모의 인덱스에 넣고
                        nodes[index] = nodes[lessChildIndex];
                        // 부모의 값을 자식의 인덱스에 넣는다
                        nodes[lessChildIndex] = lastNode;
                        // 인덱스에 자식의 값을 넣어둔다
                        index = lessChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 자식이 하나만 있는 경우 == 왼쪽 자식만 있는 경우
                else if (leftChildIndex < nodes.Count)
                {
                    // 만약 왼쪽자식의 값이 부모의 값보다 우선순위가 높으면
                    if (nodes[leftChildIndex].priority < nodes[index].priority)
                    {
                        // 자식의 값을 부모의 인덱스에 넣고
                        nodes[index] = nodes[leftChildIndex];
                        // 부모의 값을 자식의 인덱스에 넣고
                        nodes[leftChildIndex] = lastNode;
                        // 인덱스에 자식의 값을 넣어둔다
                        index = leftChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 자식이 없는 경우
                else
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 부모 노드의 인덱스를 찾는다
        /// </summary>
        /// <param name="childIndex"></param>
        /// <returns></returns>
        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        /// <summary>
        /// 오른쪽 자식 노드값을 가져온다
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
        /// <summary>
        /// 왼쪽 자식 노드값을 가져온다
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }
        /// <summary>
        /// 우선순위가 가장 높은 값을 출력
        /// </summary>
        /// <returns></returns>
        public TElement peek()
        {
            return nodes[0].element;
        }
    }
}
