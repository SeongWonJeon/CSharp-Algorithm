using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    // where T : IComparable<T> - T자체가 비교가 가능한 데이터다 라는것
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        // 최상단에 위치한 노드
        private Node root;
        // 초기화
        public BinarySearchTree()
        {
            // rootNode가 없는 상태에서 시작해야하니까 null로
            this.root = null;
        }
        /// <summary>
        /// 추가하는 것의 구조구현 - 추가가 가능하거나 가능하지 않다는걸로 반환
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(T item)
        {
            // Node사용 배열 생성
            Node newNode = new Node(item, null, null, null);
            // 맨처음에 시작할떄 루트가 널인상태에서 시작하니까
            // 루트에다가 새로운 노드적용
            if (root == null)
            {
                // 새로운노드를 루트에 적용
                root = newNode;
                return true;
            }
            // 루트노드랑 비교
            Node current = root;
            while (current != null)
            {
                // 지금아이템과 비교해서 더 작은 경우 왼쪽으로
                if (item.CompareTo(current.Item) < 0)
                {
                    // 현재노드의 왼쪽이 널이 아닌경우에는
                    // 왼쪽이 없지 않은경우
                    if (current.Left != null)
                    {
                        // 왼쪽가지고 반복을 해본다
                        // 왼쪽 자식과 또 비교하기 위해 current 왼쪽자식으로 설정
                        current = current.Left;
                    }
                    // 비교 노드가 왼쪽 자식이 없는경우
                    else
                    {
                        // 그자리가 새로운 데이터가 추가 될 자리
                        // 왼쪽의 노드가 새로운 노드가 되고
                        current.Left = newNode;
                        // 새로운 노드의 부모가 현재 비교하고있는 노드가 된다
                        newNode.Parent = current;
                        break;
                    }
                }
                // 비교했을 때 더 큰경우 오른쪽으로
                else if (item.CompareTo(current.Item) > 0)
                {
                    // 비교노드가 오른쪽 자ㄱ식이 있는경우
                    if (current.Right != null)
                    {
                        // 오른쪽 자식과 또 비교하기 위해 current 오른쪽자식으로 설정
                        current = current.Right;
                    }
                    // 그자리가 비어있었다면
                    else
                    {
                        // 그자리가 지금 추가가 될 자리
                        // 오른쪽 자리에 새로운 노드 넣기
                        current.Right = newNode;
                        // 새로운 노드의 부모가 현재 비교하고있는 노드가 된다
                        newNode.Parent = current;
                        break;
                    }
                }
                // 똑같은 테이터가 들어온 경우
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 노드를 제거할 때 사용 - 반환형이 bool이고 제거가 되면 true
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (root == null)
                return false;

            // 제거를 하기위한 노드를 찾아야되기 때문에
            Node findNode = FindNode(item);
            // 제거할 대상이 없으면
            if (findNode == null)
            {
                return false;
            }
            // 제거할 대상이 있으면
            else
            {
                EraseNode(findNode);
                return true;
            }
        }
        /// <summary>
        /// 값을 전부 초기화시킨다.
        /// </summary>
        public void Clear()
        {
            root = null;
        }

        /* ㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲㄲ꼭 다시 봐야함*/
        public bool TryGetValue(T item, out T outValue)
        {
            if (root == null)
            {
                outValue = default(T);
                return false;
            }

            Node findNode = FindNode(item);
            if (findNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.Item;
                return true;
            }
        }
        // 탐색 
        // 이진탐색트리에서 없는 경우가 있으니 bool로하여 찾았다면 true
        public bool TryGetValue1(T item, out T outValue) // 데이터, 키
        {
            // 만약 root가 널이면 트리가 비어있는 경우이니까
            if (root == null)
            {
                // 의미없는 값인 default값 넣기
                outValue = default(T);
                return false;
            }
            // 루트가 있으면 
            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.Item) < 0)
                {
                    // 왼쪽자식부터 다시 찾기 시작
                    current = current.Left;
                }
                //현재 노드의 값이 찾고자하는 값보다 큰경우
                else if (item.CompareTo(current.Item) > 0)
                {
                    // 오른쪽 자식부터 다시 찾기 시작
                    current = current.Right;
                }
                // 현재 노드의 값이 찾고자 하는 값이랑 같은경우
                else
                {
                    // 찾음
                    outValue = current.Item;
                    return true;
                }
            }
            outValue = default(T);
            return false;
        }
        // 노드를 찾을 때
        private Node FindNode(T item)
        {
            // 만약에 root == null 이면 못찾으니까
            if (root == null)
                return null;
            // 루트가 있으면 
            Node current = root;
            while (current != null)
            {
                // 현재의 노드의 값이 찾고자 하는 값보다 작은 경우
                if (item.CompareTo(current.Item) < 0)
                {
                    // 왼쪽자식부터 다시 찾기 시작
                    current = current.Left;
                }
                //현재 노드의 값이 찾고자하는 값보다 큰경우
                else if (item.CompareTo(current.Item) > 0)
                {
                    // 오른쪽 자식부터 다시 찾기 시작
                    current = current.Right;
                }
                // 현재 노드의 값이 찾고자 하는 값이랑 같은경우
                else
                {
                    // 찾음
                    return current;
                }
            }

            return null;
        }
        /// <summary>
        /// 노드를 지우는데 사용
        /// </summary>
        /// <param name="node"></param>
        private void EraseNode(Node node)
        {
            // 0. 자식 노드가 없는 노드일 경우
            if (node == null)
            {

            }
            // 1. 그 노드가 자식이 없는 노드일 경우
            if (node.HasNoChild)
            {
                // 내가 왼쪽자식인 경우
                if (node.IsLeftChild)
                    // 부모의 왼쪽노드를 널로하면 없는상황이된다
                    node.Parent.Left = null;
                // 만약에 노드가 오른쪽 자식일 경우
                else if (node.IsRightChild)
                    // 부모의 오른쪽노드를 널로하면 없는상황이된다
                    node.Parent.Right = null;
                // 노드가 root인 경우
                else
                    root = null;
            }
            // 2. 지우려는 노드가 자식노드가 1개인 경우
            else if (node.HasLeftChild || node.HasRightChild)
            {
                // 부모노드를 가져오고 
                Node parent = node.Parent;
                // 자식노드를 가져올 때 노드가 만약에 왼쪽자식을 가지고 있으면 왼쪽노드를 아니면 오른쪽 노드를
                Node child = node.HasLeftChild ? node.Left : node.Right;
                // 노드가 왼쪽자식이였을 경우
                if (node.IsLeftChild)
                {
                    // 부모의 왼쪽노드를 자식노드로 생각하고
                    parent.Left = child;
                    // 부모노드를 부모노드로
                    child.Parent = parent;
                }
                // 노드가 오른쪽 자식이였을 경우
                else if (node.IsRightChild)
                {
                    // 부모의 오른쪽 노드를 자식노드로 생각을하고
                    parent.Right = child;
                    // 부모노드를 부모 노드로
                    child.Parent = parent;
                }
                // root노드일경우 if (node.IsRootNode)
                else
                {
                    // 자식을 루트 노드로 만든다
                    //root 노드를 자신으로 
                    root = child;
                    // 부모노드를 null로해서 부모가 없는걸로 만든다
                    child.Parent = null;
                }
            }
            // 3. 지우려는 노드가 자식노드가 2개인 노드일 경우
            // 왼쪽 자식중 가장 큰값과 데이터를 교환한 후, 그 노드를 지워주는 방식으로 대체
            else // if (node.HasBothChild)
            {
                // 노드의 왼쪽노드를 넣고
                Node nextNode = node.Left;
                // 왼쪽노드의 오른쪽 노드가 null이 아닐때까지
                while (nextNode.Right != null)
                {
                    // 널이 아닐 때 까지한 노드가 왼쪽노드중 가장 큰 노드일테니 그 노드를 저장
                    nextNode = nextNode.Left;
                }
                // 노드의 아이템을 바꾸려는 노드아이템으로 바꾸고
                node.Item = nextNode.Item;
                // 옮긴 노드를 지워준다
                EraseNode(nextNode);
            }
        }
        // 노드기반 값 초기화
        private class Node
        {
            private T item;
            private Node parent;
            private Node left;
            private Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public T Item { get { return item; } set { item = value; } }
            public Node Parent { get { return parent; } set { parent = value; } }
            public Node Left { get { return left; } set { left = value; } }
            public Node Right { get { return right; } set { right = value; } }

            // 내가 root인가 체크하는 방법은 부모가 없는 경우는 root노드
            public bool IsRootNode { get { return parent == null; } }
            // 부모가 널이 아닌면서 내가 laft인 경우 래프트
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            // 부모가 널이 아니면서 내가 right인 경우 라이트
            public bool IsRightChild { get { return parent != null && parent.right == this; } }

            // 자식이 없는 경우
            public bool HasNoChild { get { return left == null && right == null; } }
            // 왼쪽자식이 있는 경우
            public bool HasLeftChild { get { return left != null && right == null; } }
            // 오른쪽자식이 있는 경우
            public bool HasRightChild { get { return left == null && right != null; } }
            // 양쪽다 자식이 있는 경우
            public bool HasBothChild { get { return left != null && right != null; } }
        }
        /// <summary>
        /// 콘솔출력
        /// </summary>
        public void Print()
        {
            Print(root);
        }
        // 중위순회
        private void Print(Node node)
        {
            // 왼쪽자식 출력하고
            if (node.Left != null) Print(node.Left); // print는 출력
            Console.WriteLine(node.Item);       // 가운데 출력을 놨기에 중위순회
            // 오른쪽자식 출력
            if (node.Right != null) Print(node.Right);

        }
    }
}
