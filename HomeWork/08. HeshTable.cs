using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    // 어떤 키값이 들어와도 문제없게끔(TKey), 어떤 변수가 들어와도 문제없게(TVlaue)
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>     // 같은 키끼리 비교할 수 있게
    {
        // 테이블의 크기를 크게 잡아둬야 용량을 포기하고 성능을 좋게 사용가능
        private const int DefaultCapacity = 1000;

        // 키와 데이터를 같이 저장할 값을 지정
        private struct Entry
        {
            // 필요한 것들을 사용하기위해 열거형enum으로 지정
            public enum State { None, Using, Delected }
            /* 열거형 타입은 기본적으로 0 값으로 초기화되기 때문에
            * state 필드를 선언할 때 별도의 초기화를 지정하지 않으면,
            * state 필드는 기본적으로 State.None 값으로 초기화된다*/
            public State state;
            // key를 해싱한 값을 저장하기위해
            public int hashCode;
            // 지정받은 값 key
            public TKey key;
            // 입력받은 값의타입(int, string, double등등)을 받아와 저장한다.
            public TValue value;
        }
        // 엔트리는 테이블의 크기만큼
        private Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }
        /// <summary>
        /// get과 set을 이용해서 그 값의 호출과 초기화를 할 수 있다
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public TValue this[TKey key]
        {
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);
                // 2. table의 index.state가 None이 아니면
                while (table[index].state != Entry.State.None)
                {
                    // 동일한 key 값으로 이미 다른 value가 저장되어 있는 경우 중복된 key를 추가하려고 하면
                    if (key.Equals(table[index].key))
                    {
                        // 찾은 그 위치의 값을 반환
                        return table[index].value;
                    }
                    // 열심히 찾아갔는데 없으면 비어있는 곳이기 때문에 더이상 해볼 필요가 없으니
                    if (table[index].state == Entry.State.None)
                    {
                        break;
                    }
                    // 그 위치가 사용중이라면 다음으로 넘어가면서 비어있는 인덱스를 찾아서 그곳에 저장
                    index = index < table.Length ? index + 1 : 0;
                }
                throw new KeyNotFoundException();
            }
            set// 아직 안했음
            {
                int index = Math.Abs(key.GetHashCode() % table.Length);
                // table의 index.state가 None이 아니면 반복
                while (table[index].state != Entry.State.None)
                {
                    // 입력받은 key와 table의 index.key의 값이 같다면
                    if (key.Equals(table[index].key))
                    {
                        // table의 index.value에 value를 저장
                        table[index].value = value;
                        return;         // return을 하면 예외처리가 되지않고 종료
                    }
                    // 열심히 찾아갔는데 없으면 사용중이 아니라면
                    if (table[index].state != Entry.State.Using)
                    {
                        break;          // break를 하면 예외처리를 내보냄
                    }
                    // 그 위치가 사용중이라면 다음으로 넘어가면서 비어있는 인덱스를 찾아서 그곳에 저장
                    index = index < table.Length ? index + 1 : 0;
                }
                throw new KeyNotFoundException();
            }
        }
        /// <summary>
        /// 사용안하는 인덱스를 찾아서 그곳에 저장한다
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(TKey key, TValue value)
        {
            // 1. key를 index로 해싱  // 어떤형태가 들어와도 해쉬코드를 사용해 변환
            int index = Math.Abs(key.GetHashCode() % table.Length);      // Math.Abs - 절댓값으로 음수가된 값을 양수로바꿔서 사용하기위해
            // 2. 그 위치가 사용중이 아닐 때 까지
            while (table[index].state == Entry.State.Using)
            {
                // 동일한 key 값으로 이미 다른 value가 저장되어 있는 경우 중복된 key를 추가하려고 하면
                if (key.Equals(table[index].key))
                {
                    // 예외 상황 발생
                    throw new ArgumentException();
                }
                else
                {
                    // 그 위치가 사용중이라면 다음으로 + 1씩 넘어가면서 비어있는 인덱스를 찾아서 그곳에 저장
                    index = index < table.Length ? index + 1 : 0; // == index = ++index % table.Length; 왼쪽과 동일
                }
            }

            // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 저장
            // hashCode에 입력한 key의 해싱한 값을 넣는다.
            table[index].hashCode = key.GetHashCode();
            // table의 index에 key는 입력한 key값으로
            table[index].key = key;
            // table의 index에 value는 넣은 value의 값으로
            table[index].value = value;
            // table의 index에 state를 Using으로 초기화
            table[index].state = Entry.State.Using;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Remove(TKey key)
        {
            // 1. key를 index로 해싱
            int index = Math.Abs(key.GetHashCode() % table.Length);

            while (table[index].state == Entry.State.Using)
            {
                // 동일한 key 값으로 이미 다른 value가 저장되어 있는 경우 중복된 key를 추가하려고 하면
                if (key.Equals(table[index].key))
                {
                    // 동일한 키값을 찾았으면 지우기
                    table[index].state = Entry.State.Delected;
                }
                // 찾아봤는데 그자리가 비어있어서 지우지 못하면 예외처리
                if (table[index].state != Entry.State.None)
                {
                    break;
                }
                index = index < table.Length ? index + 1 : 0;
            }

            throw new InvalidOperationException();
        }

        /*internal bool ContainsKey(string v)
        {
            throw new NotImplementedException();
        }

        internal bool TryGetValue(string v, out string output)
        {
            throw new NotImplementedException();
        }*/
    }
}
