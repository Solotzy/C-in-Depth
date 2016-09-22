/*
 * 嵌套类实现集合迭代器
 */
using System;
using System.Collections;

namespace SimpleEnumerate
{
    class IterationSampleIterator : IEnumerator
    {
        //正在迭代的集合
        IterationSample parent;
        //指出遍历到的位置
        int position;

        internal IterationSampleIterator(IterationSample parent)
        {
            this.parent = parent;
            //在第一个元素之前开始
            position = -1;
        }

        public object Current
        {
            get
            {
                //防止访问第一个元素之前和最后一个元素之后
                if (position == -1 || position == parent.values.Length)
                {
                    throw new InvalidOperationException();
                }
                //实现封装
                int index = position + parent.startingPoint;
                index = index%parent.values.Length;
                return parent.values[index];
            }
        }

        public bool MoveNext()
        {
            //如果仍要遍历，那么增加position的值
            if (position != parent.values.Length)
            {
                position++;
            }
            return position < parent.values.Length;
        }

        public void Reset()
        {
            //返回第一个元素之前
            position = -1;
        }
    }
}