using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public class List<T>
    {

        private const int CountCapacity = 5;

        private T[] items;
        private int size;

        public List()
        {
            this.items = new T[CountCapacity];
            this.size = 0;
        }

        public int Capacity { get { return this.items.Length; } }

        // List의 배열이 가지고있는 길이를 나타낸다.
        public int Count { get { return size; } }

        /// <summary>
        /// 배열의 요소에 수를 넣습니다.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            // 만약에 items의 길이가 size보다 넓으면
            if (size < items.Length)
            {
                // items에 size를 하나 늘리고 item의 수를 하나 추가한다
                items[size++] = item;
            }
            else
            {
                // 그게 아니면 (길이가 부족하면) Grow를 통해서 items의 Length를 2배 늘려주고 수를 넣는다
                Grow();
                items[size++] = item;
            }
        }

        /// <summary>
        /// List 배열에 수를 추가하려고하는데 할당한 배열의 개수가 전부 지정되어서 자리가 없을 때 사용한다
        /// </summary>
        public void Grow()
        {
            // 새로운 배열의 길이를 정수로 정해놓는다
            int newCountCapacity = items.Length * 2;
            // 원래 items의 배열의 2배 길이인 배열을 만든다
            T[] newitems = new T[newCountCapacity];
            // 전에있던 items의 배열을 복사하여 새로운 newitems배열에 복사하여 넣는다
            Array.Copy(items, 0, newitems, 0, size);
            // 복사한 배열을 원래의 배열에 넣는다
            items = newitems;
        }
        /// <summary>
        /// 삭제할 값을 받아와서 값이 있다면 값이있는 위치를 없애고 뒤의값을 앞으로 당겨옵니다.
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            // 만약에 index의 값이 0보다 작거나 값이 size보다 작다면
            if (index < 0 || index >= size)
                // 예외를 호출하는 방법으로 예외를 호출해 처리하지않으면 오류가 발생해 프로그램이 비정상적으로 종료되기 때문에 예외를 호출합니다.
                throw new IndexOutOfRangeException();
            // size를 후위연산자로 -1합니다.
            size--;
            // index번째를 삭제하기위해 Array.Copy를 items 배열에서 index + 1번째 요소부터 size - index개의 요소를 items 배열의 index번째 위치부터 복사
            Array.Copy(items, index + 1, items, index, size - index);
        }
        /// <summary>
        /// 배열안에 수를 찾아서 있다면 배열에서 그 수를 없애고 그 뒤에 수가 있다면 빈칸을 채워옵니다. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            // item을 받아와 IndexOf에 넣고 나온 결과값을 index에 저장합니다
            int index = IndexOf(item);
            // 만약 index의 값이 0보다 크거나 같으면
            if (index >= 0)
            {
                // RemoveAt를 통해 삭제후 위치를 복사하여 당겨오고
                RemoveAt(index);
                // 결과를 true로 반환합니다.
                return true;
            }
            else
            {
                // 못 찾은 경우 false를 반환
                return false;
            }
        }
        /// <summary>
        /// 매개변수를 받아 배열에서 처음나타나는 인덱스를 반환한다.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            // Array.IndexOf매소드를 사용하여 배열에서 item를 검색합니다. 3번째에 있는 매개변수는 검색할 인덱스이고, size는 검색할 요소의 수입니다.
            return Array.IndexOf(items, item, 0, size);
        }
        /// <summary>
        /// 조건에 만족하는 요소의 인덱스를 반환합니다.
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public int FindIndex(Predicate<T> match)
        {
            // for문을 반복해 배열의 size만큼 반복하고
            for (int i = 0; i < size; i++)
            {
                // 만약 조건과 배열의 값과 일치하다면 그 배열의 값을 리턴합니다.
                if (match(items[i]))
                    return i;
            }
            // 아닐경우 -1을 반환
            return -1;
        }
        /// <summary>
        /// 배열에 접근해 특정한 값이 있는지 찾아봐줍니다.
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T? Find(Predicate<T> match)
        {
            // 만약 매개변수가 null일 경우 예외를 호출해서 오류를 미리 막아 프로그램이 종료되는 것을 막습니다.
            if (match == null)
                throw new ArgumentNullException("match");
            // for문으로 반복하여
            for (int i = 0; i < size; i++)
            {
                // 만약에 매개변수가 items의 배열안에 있다면 
                if (match(items[i]))
                    // 그 배열의 값을 리턴
                    return items[i];
            }
            // 없다면 default반환
            return default(T);
        }

    }
}
