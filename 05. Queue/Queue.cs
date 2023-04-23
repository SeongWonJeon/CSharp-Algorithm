using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._Queue
{
    public class Queue<T>
    {
        private const int DefaultCapacity = 4;

        // 배열을 만들기
        private T[] array;
        // 전단
        private int head;
        // 후단
        private int tail;

        public Queue()
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }
        // 몇개 들어있는지 보는것
        public int Count
        {
            get
            {
                // 헤드가 앞에있있거나 같을 때 테일은 
                if (head <= tail)
                    // 테일 - 헤드해서 반환
                    return tail - head;
                // 아닌경우에는 tail + array.Length - head 로 계산
                else
                    // tail + (배열의 길이 - head)해서 반환
                    return tail + (array.Length - head);
            }
        }
        // 처음으로 초기화
        public void Clear()
        {
            array = new T[DefaultCapacity + 1];
            head = 0;
            tail = 0;
        }
        /// <summary>
        /// 테일자리에 하나 추가하고 테일을 증가시킨다.
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            // 배열이 다찼다면 배열의 크기를 키워주자, 허용량을 더 늘리자.
            if (IsFull())
            {
                Grow();
            }

            // tail을 ++ 해주는 방식이 아니라 tail이 꽉차면 처음으로 가는 경우를 만들어야하기때문에 ++대신 MoveNext를 구현
            array[tail] = item;
            MoveNext(ref tail);         // 테일이 끝에있을때는 가장앞으로
        }
        /// <summary>
        /// 배열에서 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Dequeue()
        {
            // 만약에 비어있는데 꺼내려고하면 예외처리를 한다
            if (IsEmpty())
                throw new InvalidOperationException();

            // 꺼낼 데이터 헤드의 데이터
            T result = array[head];
            // 헤드를 다음칸으로 이동
            MoveNext(ref head);
            // return으로 꺼내준다
            return result;
        }

        public bool TryDequeue(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }

            result = array[head];
            MoveNext(ref head);
            return true;
        }
        //
        public T Peek()
        {
            // 예외처리- Peek할 때 비어있으면 예외처리 해달라
            if (IsEmpty())
                throw new InvalidOperationException();
            // 헤드에 있는 자료를 반환하면 된다.
            return array[head];
        }

        public bool TryPeek(out T result)
        {
            if (IsEmpty())
            {
                result = default(T);
                return false;
            }

            result = array[head];
            return true;
        }
        // 배열의 크기를 늘린다.
        private void Grow()
        {
            // 새로만들 배열의 크기는 2배로
            int newCapacity = array.Length * 2;
            // 새로운 배열을 지정
            T[] newArray = new T[newCapacity + 1];

            if (!IsEmpty())
            {
                // 헤드가 테일보다 앞에있을때는 그대로 복사
                if (head < tail)
                {
                    
                    Array.Copy(array, head, newArray, 0, tail);
                }
                else        // 그 경우가 아니라면
                {   
                    // 배열에서 헤드부터 새로운배열의 0번에 배열의 크기에 헤드만큼 복사
                    Array.Copy(array, head, newArray, 0, array.Length - head);
                    // 배열에서 0 번부터 새로운 배열에다가 어레이랭스에 - 헤드에서 테일만큼
                    Array.Copy(array, 0, newArray, array.Length - head, tail);
                    tail = Count;
                    head = 0;
                }

            }

            array = newArray;
           
        }

        private bool IsFull()
        {
            if (head > tail)
            {
                return head == tail + 1;
            }
            else
            {
                return head == 0 && tail == array.Length - 1;     // -1을 한 이유는 0, 1, 2, 3, 4) 5이기 때문에 -1을하고 계산을 해야한다      
            }
        }

        private bool IsEmpty()
        {
            return head == tail;
        }

        // 이동하는 매서드
        private void MoveNext(ref int index)
        {
            // 끝에있을때는 0으로가고 끝이아니면 index의 + 1 만큼 간다.
            index = (index == array.Length - 1) ? 0 : index + 1;
        }
    }
}
