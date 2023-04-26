using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 어떤 키값이 들어와도 문제없게끔(TKey), 어떤 변수가 들어와도 문제없게(TVlaue)
    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey>     // 같은 키끼리 비교할 수 있게
    {
        // 테이블의 크기를 크게 잡아둬야 용량을 포기하고 성능을 좋게 사용가능
        private const int DefaultCapacity = 1000;

        // 키와 데이터를 같이 저장할 값을 지정
        private struct Entry
        {
            
            public enum State { None, Using, Delected}

            public State state;

            public int hashCode;
            // 키
            public TKey key;
            // 데이터
            public TValue value;
        }
        // 엔트리는 테이블의 크기만큼
        private Entry[] table;

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }
        /// <summary>
        /// 
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
                // 2. key가 일치하는 데이터가 나올떄까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 동일한 key 값으로 이미 다른 value가 저장되어 있는 경우 중복된 key를 추가하려고 하면
                    if (key.Equals(table[index].key))
                    {
                        // 찾은 그 위치에 저장
                        return table[index].value;
                    }
                    // 열심히 찾아갔는데 없으면 사용중이 아닌것이기에
                    if (table[index].state != Entry.State.Using)
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
                // 2. key가 일치하는 데이터가 나올떄까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    // 동일한 key 값으로 이미 다른 value가 저장되어 있는 경우 중복된 key를 추가하려고 하면
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                        return;
                    }   
                    // 열심히 찾아갔는데 없으면 사용중이 아닌것이기에
                    if (table[index].state != Entry.State.Using)
                    {
                        break;
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
            int index = Math.Abs(key.GetHashCode() % table.Length);      // Math.Abs - 절댓값
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
                    // 그 위치가 사용중이라면 다음으로 넘어가면서 비어있는 인덱스를 찾아서 그곳에 저장
                    index = index < table.Length ? index + 1 : 0; // == index = ++index % table.Length; 왼쪽과 동일
                }
            }

            // 3. 사용중이 아닌 index를 발견한 경우 그 위치에 저장
            table[index].hashCode = key.GetHashCode();
            table[index].key = key;
            table[index].value = value;
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

        internal bool ContainsKey(string v)
        {
            throw new NotImplementedException();
        }

        internal bool TryGetValue(string v, out string output)
        {
            throw new NotImplementedException();
        }
    }
}
