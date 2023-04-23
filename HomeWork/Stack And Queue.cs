using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    /* Stack의 어뎁터Adepter 만들고
     * Queue의 순환배열 구현
     */
    public class Stack<T>
    {
        private const int DefaultCapacity = 5;
        private T[] array;
        private int top;
        private int Count;
        // 초기화를 진행
        public Stack() 
        {
            array = new T[DefaultCapacity];
            top = 0;
            Count = 0;
        }
        /// <summary>
        /// 모든값을 초기값으로 돌려줌
        /// </summary>
        public void Clear()
        {
            array = new T[DefaultCapacity];
            top = 0;
            Count = 0;
        }
        /// <summary>
        /// 배열에 값을 넣어준다.
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            // 만약에 top의 값이 배열의 길이의-1과 같다면 배열의 크기를 증가
            if (top == array.Length - 1)
            {
                Grow();
            }
            array[top++] = item;
            Count++;
        }
        /// <summary>
        /// 값을 출력하고 제거
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Pop()
        {
            if (top == 0)
            {
                throw new InvalidOperationException();
            }
            return array[--top];
        }
        /// <summary>
        /// 값을 출력만하고 제거하진않음
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek()
        {

            if (top == 0)
            {
                throw new InvalidOperationException();
            }
            return array[top - 1];
        }
        public void Grow()
        {
            int newarray = array.Length * 2;
            // 늘린 새로운 배열을 원래의 배열에 저장
            T[] newArray = new T[newarray];
            // 원래배열을 카피해서 새로운배열에 저장
            Array.Copy(array, 0, newArray, 0, top);
            // 저장후 새로운 배열을 원래배열에 저장
            array = newArray;
            top = Count;
        }
        
    }

































    /// <summary>
    /// 일반화 Queue 클래스
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        // DefaultCapacity는 기본용량이라는 뜻 (메모메모);
        private const int DefaultCapacity = 5;
        // 배열을 만든다
        private T[] array;
        // 배열의 시작부분 head
        private int head;
        // 배열의 끝부분 tail
        private int tail;
        
        /// <summary>
        /// 배열의 값들을 초기화를 해준다
        /// </summary>
        public Queue()
        {
            // 배열에 + 1 을 해주는 이유는 tail과 head가 만났을 때 비워진 한칸을 알림으로 쓰기 위해서이다.
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }
        /// <summary>
        /// 배열에 몇개가 있는지 저장하는 Count
        /// </summary>
        public int Count
        {
            get
            {
                // 만약 head가 tail보다 작거나 같다면 
                if (head <= tail)
                    // tail - head를 return
                    return tail - head;
                // 그게 아니라면 tail이 앞에있는 경우일테니
                else
                    // tail에 배열의길이(array.Length)에 head의 위치를 뺀 값을 더한 후 return
                    return tail + (array.Length - head);
            }
        }
        /// <summary>
        /// Queue의 배열을 초기화시킨다
        /// </summary>
        public void Clear()
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }
        /// <summary>
        /// 배열의 tail에 값을 넣는다
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            // 만약 넣으려는데 가득 차있다면
            if (IsFull())
            {
                // Grow를 통해 크기를 키운다
                Grow();
            }
            // 배열의 테일에 지정된 값을 넣는다
            array[tail] = item;
            // 값을 넣고 MoveNext
            MoveNext(ref tail);
        }
        /// <summary>
        /// 배열의 head의 값을 뺀다
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            // result의 뜻은 결과이다
            T result = array[head];
            MoveNext(ref head);
        }
        /// <summary>
        /// 내용일 비어있을 경우
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return head == tail;
        }
        /// <summary>
        /// 값을 넣을 때 조건을 확인시킨다.
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            // 만약 head가 tail보다 큰경우
            if (head > tail)
            {
                // head와 tail + 1 같다는 연산은 반환
                return head == tail + 1;
            }
            else
            {
                // head의 위치가 0이고, tail의 위치가 배열의 길이 - 1이면을 반환
                return head == 0 && tail == array.Length - 1;
            }
        }
        /// <summary>
        /// 값을 넣고 tail이 한칸 뒤로간다
        /// </summary>
        public void MoveNext(ref int index)
        {
            // index가 array.Length -1과 같다면 0, 아니면 index의 + 1 만큼 간다.
            index = (index == array.Length - 1) ? 0 : index + 1;
        }
        /// <summary>
        /// 배열의 길이를 2배로 늘린다
        /// </summary>
        public void Grow()
        {
            // 배열의 길이를 2배로 늘리고
            int newarray = array.Length * 2;
            // 늘린 새로운 배열을 원래의 배열에 저장
            T[] newArray = new T[newarray];

            if(head < tail)
            {
                // 원래있던 배열의 머리부분부터, newArray의 0번째에 넣는데 어디까지 넣냐 원래 배열의 tail까지 넣는다
                Array.Copy(array, head, newArray, 0, tail);
            }
            else
            {
                // 복사를 원래있던 array의 head 부분부터, newArray의 0번째에 넣는데, array의 길이에서 head의 위치를 뺀값만큼을 원래의 배열에 넣고
                Array.Copy(array, head, newArray, 0, array.Length - head);
                // 배열을 복사하는데 원래있던 array의 0번째부터, newArray의 array.Length - head번째에서부터 tail까지를 복사한다
                Array.Copy(array, 0, newArray, array.Length - head, tail);
                // head는 시작지점에 올려주고
                head = 0;
                // tail은 들어간 값 Count만큼의 자리에 넣어준다 ***Count는 0부터 오르기때문에 들어간 값의 빈자리에 안착할 수 있기때문에 + 1을 안해도 됨
                tail = Count;
            }
            array = newArray;
        }
    }
}
