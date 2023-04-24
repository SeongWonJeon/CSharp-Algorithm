using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 완전이진트리기반에서 자식, 부모 찾는 계산
    // 왼쪽자식 : index * 2 + 1
    // 오른쪽자식 : index * 2 + 2
    // 부모 : (index - 1) / 2

    // 우선순위Queue는 힙을 이용해서 만들 수 있다
    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            // 힙의경우에는 연산가지고만 할테니
            public TElement element;
            public int priority;
        }
        private List<Node> nodes;
        
        public PriorityQueue() 
        { 
            this.nodes = new List<Node>();
        }
        public int Count { get {  return nodes.Count; } }

        public void Enqueue(TElement element, int priority)
        {
            
            Node newNode = new Node() { element = element, priority = priority };

            // 1. 가장 뒤에 데이터 추가
            nodes.Add(newNode);
            int newNodeIndex = nodes.Count - 1;

            // 2. 새로운 노드를 힙상태가 유지되도록 승격 작업 반복
            while (newNodeIndex > 0)
            {
                // 부모노드를 찾아가서 매개변수에 저장
                int parentIndex = GetParentIndex(newNodeIndex);
                Node parentNode = nodes[parentIndex];
                // 숫자가 작은경우, 자식 노드가 부모 노드보다 우선순위가 높으면 교체
                if (newNode.priority < parentNode.priority)
                {
                    nodes[newNodeIndex] = parentNode;
                    nodes[parentIndex] = newNode;
                    newNodeIndex = parentIndex;
                }
                else
                {
                    break;
                }
            }

        }
        // 뺐을 때
        public TElement Dequeue()
        {
            Node rootNode = nodes[0];

            // 1. 가장 마지막 노드를 최상단으로 위치
            Node lastNode = nodes[nodes.Count - 1];
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            // 자식 노드들과 비교하여 더 작은 자식과 교체반복
            while (index < nodes.Count)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                // 자식이 둘다 있는 경우
                if (rightChildIndex < nodes.Count)
                {
                    // 왼쪽 자식과 오른쪽 자식을 비교하여 더 우선순위가 높은 자식을 선정
                    int lessChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority 
                        ? leftChildIndex : rightChildIndex;

                    // 더 우선순위가 높은 자식과 부모 노드를 비교하여
                    // 부모가 우선순위가 더 낮은 경우 바꾸기
                    if (nodes[lessChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[lessChildIndex];
                        nodes[lessChildIndex] = lastNode;
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
                    if (nodes[leftChildIndex].priority < nodes[index].priority)
                    {
                        nodes[index] = nodes[leftChildIndex];
                        nodes[leftChildIndex] = lastNode;
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

            return rootNode.element;
        }

        public TElement peek()
        {
            return nodes[0].element;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return parentIndex * 2 + 2;
        }
    }
}
