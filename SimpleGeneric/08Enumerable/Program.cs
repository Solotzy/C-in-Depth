using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08Enumerable
{
    class CountingEnumerable : IEnumerable<int>
    {
        //隐式实现IEnumerable<T>
        public IEnumerator<int> GetEnumerator()
        {
            return new CountingEnumerator();
        }
        //显示实现IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class CountingEnumerator : IEnumerator<int>
    {
        int current = -1;
        //隐式实现IEnumerator<T>.Current
        public int Current { get { return current; } }
        //显示实现IEnumerator.Current
        object IEnumerator.Current { get { return Current; }}
        public bool MoveNext()
        {
            current++;
            return current < 10;
        }

        public void Reset()
        {
            current = -1;
        }
        public void Dispose() { }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //证明可枚举类型能正常工作
            CountingEnumerable counter = new CountingEnumerable();
            foreach (int i in counter)
            {
                Console.Out.WriteLine(i);
            }
            Console.Read();
        }
    }
}
