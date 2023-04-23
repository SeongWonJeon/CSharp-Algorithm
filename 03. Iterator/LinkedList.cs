using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class LinkedListNumbers<T> 
    {
        // 노드가 속해있는 리스트를 담는 변수
        internal LinkedList<T> list;
        // 이전 노드를 담고있는 변수
        internal LinkedListNumbers<T> previos;
        // 다음 노드를 담고있는 변수
        internal LinkedListNumbers<T> next;
        // 노드에 저장될 데이터를 저장하 변수
        T item;

        /// <summary>
        /// 매개변수로 value를 받아 저장하고, 첫번째 노드를 생성하는데 사용됩니다.
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNumbers(T value)       // 오버로딩을 통한 생성자 3개를 생성
        {
            this.list = null;
            this.previos = null;
            this.next = null;
            this.item = value;
        }
        /// <summary>
        /// LinkedList<T>형식의 list와 T 형식의 value를 받아 저장하고, 노드를 생성하며 인스턴스를 가리키는 list 필드와, 노드의 값을 나타내는 item 을 초기화한다.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="value"></param>
        public LinkedListNumbers(LinkedList<T> list, T value)
        {
            this.list = list;
            this.previos = null;
            this.next = null;
            this.item = value;
        }
        /// <summary>
        /// LinkedList<T>형식의 list와 LinkedListNumbers<T>형식의 previos, next 그리고 T형식의 item을 받아와 저장한다.이전노드와 다음노드도 가져와 초기화하는 형식이다
        /// </summary>
        /// <param name="list"></param>
        /// <param name="previos"></param>
        /// <param name="next"></param>
        /// <param name="item"></param>
        public LinkedListNumbers(LinkedList<T> list, LinkedListNumbers<T> previos, LinkedListNumbers<T> next, T item)
        {
            this.list = list;
            this.previos = previos;
            this.next = next;
            this.item = item;
        }
        // LinkedList 타입의 List 프로퍼티를 가져옵니다 다른 클래스나 매소드에서 접근할 수 있게 해줍니다.
        public LinkedList<T> List { get { return list; } }
        // LinkedListNumbers 타입의 previods 프로퍼티를 가져옵니다 다른 클래스나 매소드에서 접근할 수 있게 해줍니다.
        public LinkedListNumbers<T> Previods { get { return previos; } }
        // LinkedListNumbers 타입의 Next 프로퍼티를 가져옵니다 다른 클래스나 매소드에서 접근할 수 있게 해줍니다.
        public LinkedListNumbers<T> Next { get { return next; } }
        // T Generic Item 프로퍼티를 가져옵니다. 다른클래스나 매소드에서 접근할 수 있으며 값을 (초기화)set할 수 있습니다
        public T Item { get { return item; } set { item = value; } }

        public T? Value { get; internal set; }

        
    }
    /// <summary>
    /// 데이터를 연속된 노드형태로 저장할 수 있는 구조이다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        private LinkedListNumbers<T> head;
        private LinkedListNumbers<T> tail;
        private int count;

        // 값을 초기화
        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
        // LinkedListNumbers 타입의 FirstHead 프로퍼티를 get가져옵니다. 다른 클래스나 매소드에서 접근할 수 있게 해줍니다.
        public LinkedListNumbers<T> FirstHead { get { return head; } }
        // LinkedListNumbers 타입의 LastTail 프로퍼티를 get가져옵니다.다른 클래스나 매소드에서 접근할 수 있게 해줍니다.
        public LinkedListNumbers<T> LastTail { get { return tail; } }
        // int 타입의 Count는 외부에서 설정할 수 없고 읽기 전용입니다. 접근자를 통해 현재 연결 리스트 내의 노드 개수를 반환합니다.
        public int Count { get { return count; } }


        /// <summary>
        /// 리스트의 안에 첫번째에 노드를 추가합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LinkedListNumbers<T> AddFirst(T value)
        {
            // 새로운 노드를 생성합니다.
            LinkedListNumbers<T> newNumbers = new LinkedListNumbers<T>(value);

            if (head != null)
            {
                // 새로운 노드 다음이 머리가 되고 새로운 노드는 헤드 전이 되도록 연결구조를 바꾼다
                newNumbers.next = head;
                head.previos = newNumbers;
            }
            else
            {
                // 헤드가 없다면 새로운 노드가 머리꼬리 다해먹기
                head = newNumbers;
                tail = newNumbers;
            }
            // 넣었으니 하나 증가
            count++;
            return newNumbers;
        }
        /// <summary>
        /// 리스트의 안에 마지막부분에 노드를 추가합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LinkedListNumbers<T> AddLast(T value)
        {
            // 새로운 노드를 생성합니다.
            LinkedListNumbers<T> newNumbers = new LinkedListNumbers<T>(value);
            // 만약 head가 null이 아닐경우
            if (head != null)
            {
                // 새로운 노드 다음을 head로
                newNumbers.next = head;
                // head의 이전을 새로운 노드로
                head.previos = newNumbers;
            }
            else
            {
                // head를 새로운 노드로하고 마지막인 꼬리도 새로운 노드로 합니다.
                head = newNumbers;
                tail = newNumbers;
            }
            // 갯수 증가
            count++;
            return newNumbers;
        }

        /// <summary>
        /// 기존의 노드 앞에 노드를 추가한다.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public LinkedListNumbers<T> AddBefore(LinkedListNumbers<T> node, T value)
        {
            // 노드가 연결리스트에 포함된 노드가 아닌경우 오류를 발생시켜 프로그램이 터지는 걸 막습니다.
            if (node.list != this)
                throw new InvalidCastException();
            // 노드가 없는경우
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            // 새로운 노드 생성
            LinkedListNumbers<T> newNumbers = new LinkedListNumbers<T>(this, value);

            // 새로운 노드 다음노드는 새로운 노드의 다음노드?
            newNumbers.next = node;
            // 새로운 노드의 전 노드는 새로운 노드의 전 노드?
            newNumbers.previos = node.previos;
            // 노드 전의 다음 노드는 새로운 노드
            node.previos.next = newNumbers;
            // 만약 노드가 널이면
            if (node.previos != null)
            {
                node.previos.next = newNumbers;
            }
            else
            {
                head = newNumbers;
            }
            // 갯수를 증가시킵니다.
            count++;
            return newNumbers;
        }
        /// <summary>
        /// 기존의 노드 뒤에다가 새로운 노드를 하나 추가합니다.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public LinkedListNumbers<T> AddAfter(LinkedListNumbers<T> node, T value)
        {
            // 노드가 연결리스트에 포함된 노드가 아닌경우 오류를 발생시켜 프로그램이 터지는 걸 막습니다.
            if (node.list != this)
                throw new InvalidCastException();
            // 노드가 없는경우
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            // 새로운 노드를 생성
            LinkedListNumbers<T> newNumbers = new LinkedListNumbers<T>(this, value);
            // 새로운 노드의 이전을 노드의 이전으로
            newNumbers.previos = node.previos;
            // 새로운 노드의 다음을 노드의 다음으로
            newNumbers.next = node.next;
            // 노드의 다음을 새로운 노드로
            node.next = newNumbers;
            // 만약 노드의 다음이 null이 아니면
            if (node.next != null)
            {
                // 새로운 노드의 다음의 이전을 새로운 노드로
                newNumbers.next.previos = newNumbers;
            }
            else
            {
                // 마지막 꼬리를 새로운 노드로
                tail = newNumbers;
            }
            // 갯수 추가후 새로운 노드를 반환
            count++;
            return newNumbers;
        }
        /// <summary>
        /// 받은 값을 노드에서 확인하고 삭제하는 작업을 역할을 합니다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            // remove할 노드를 입력해 Null이 아닌 값이 반환되었다면 저장하여
            LinkedListNumbers<T> findNode = Find(value);
            //만약 findNode가 null이 아니라면
            if (findNode != null)
            {
                // remove매서드를 불러 삭제를 진행하고 true를 반환합니다.
                Remove(findNode);
                return false;
            }
            else
            {
                // null을 반환하면 삭제할 것이 없으니 false를 반환합니다.
                return true;
            }
        }
        /// <summary>
        /// 리스트의 노드중에 하나를 없앤다.
        /// </summary>
        /// <param name="node"></param>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void Remove(LinkedListNumbers<T> node)
        {
            // 노드가 연결리스트에 포함된 노드가 아닌경우 오류를 발생시켜 프로그램이 터지는 걸 막습니다.
            if (node.list != this)
                throw new InvalidCastException();
            // 노드가 없는경우
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            // 없앤 노드가 첫번째부분인 머리일 경우 없어진 노드의 다음을 머리로
            if (head == node)
                head = node.next;
            // 없앤 노드가 마지막부분인 꼬리일 경우 없어진 노드의 이전을 꼬리로
            if (tail == node)
                tail = node.previos;

            if (node.previos != null)
                // node 이전의 다음을 node의 다음으로 연결 
                node.previos.next = node.next;
            if (node.next != null)
                // node 다음의 이전은 노드의 이전으로 연결
                node.next.previos = node.previos;
        }

        /// <summary>
        /// 리스트에서 특정 노드를 찾을 때 사용합니다
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LinkedListNumbers<T> Find(T value)
        {
            // targetNum을 리스트의 첫번째인 head를 넣어준다
            LinkedListNumbers<T> targetNum = head;
            // comparer 비교자를 넣어준다
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            // 반복문을 통해서 타겟넘버가 null이 아니면
            while (targetNum != null)
            {
                // Equals는 똑같냐고 물어보는 것이며, 비교후 같다면 타겟넘버를 반환한다.
                if (comparer.Equals(value, targetNum.Value))
                    return targetNum;
                // 아니라면 타겟넘버를 다음 리스트의 노드로 넘겨서 반복
                else
                    targetNum = targetNum.Next;
            }

            return null;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
        // 반복기같은 경우에는 구조체로 해주는게 좋읗 거 같다고 하셨다
        public struct Enumerator : IEnumerator<T>
        {
            private LinkedList<T> linkedList;
            private LinkedListNode<T> node;
            private int index;
            private T current;

            public Enumerator(LinkedList<T> list)
            {
                this.linkedList = list;
                this.node = linkedList.head;
                this.index = 0;
                this.current = default(T);
            }

            public T Current { get { return current; } }

            object IEnumerator.Current
            {
                get
                {
                    if (index < 0 || index >= linkedList.Count)
                        throw new InvalidOperationException();
                    return Current;
                }
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (index < linkedList.Count)
                {
                    current = node.Value;
                    node = node.Next;
                    return true;
                }
                else
                {
                    current = default(T);
                    return false;
                }
            }

            public void Reset()
            {
                node = null;
                index = 0;
                current = default(T);
            }

        }
    }
}
