using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace SimpleProcessers
{
    /// <summary>
    /// 定义可以排队处理一些业务操作的基类
    /// </summary>
    public abstract class ProcesserBase
    {
        ConcurrentQueue<object> _itemQueue = new ConcurrentQueue<object>();
        private int _processed = 0;

        public bool Enabled { get; set; }

        /// <summary>
        /// 任务实例标示符
        /// </summary>
        public string  TaskInstanceId { get; set; }

        /// <summary>
        /// 处理器名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 已经处理的项数目    
        /// </summary>
        public int Processed { get { return _processed; } }

        /// <summary>
        /// 所有项数目
        /// </summary>
        public int Total { get { return _processed + _itemQueue.Count; } }

        /// <summary>
        /// 剩余的项数目
        /// </summary>
        public int Remain { get { return _itemQueue.Count; } }

        /// <summary>
        /// 其他信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 完成百分比
        /// </summary>
        public int ProcessedPercent { get { return Total == 0 ? 0 : Processed*100/Total; } }

        /// <summary>
        /// 任务开始执行的委托
        /// </summary>
        public event EventHandler TaskStart;

        /// <summary>
        /// 报告进度的委托
        /// </summary>
        public event EventHandler ProgressChanged;

        /// <summary>
        /// 任务结束执行的委托
        /// </summary>
        public event EventHandler TaskFinished;

        public void Add(object item)
        {
            _itemQueue.Enqueue(item);
            if (!_inProcess && Enabled)
            {
                _inProcess = true;
                Start();
            }
        }

        ~ProcesserBase()
        {
            if (!_inProcess)
            {
                ProcessCall(null);
            }
        }

        /// <summary>
        /// 待处理资讯出队
        /// </summary>
        /// <returns></returns>
        Object DeQueue()
        {
            object item = default(object);
            _itemQueue.TryDequeue(out item);
            return item;
        }

        bool _inProcess = false;

        void ProcessCall(Object stateInfo)
        {
            object item = default(object);
            try
            {
                while (!EqualityComparer<object>.Default.Equals(item = DeQueue(), default(object)) && Enabled)
                {
                    if (Processed == 0 && TaskStart != null)
                    {
                        ProgressChanged(this, EventArgs.Empty);
                    }

                    Process(item);

                    _processed++;

                    if (ProgressChanged != null)
                    {
                        ProgressChanged(this, EventArgs.Empty);
                    }

                    if (Remain == 0 && TaskFinished != null)
                    {
                        TaskFinished(this, EventArgs.Empty);
                    }

                }
            }
            finally
            {
                _inProcess = false;
            }
        }

        /// <summary>
        /// 实际用于处理item的方法
        /// </summary>
        /// <param name="item"></param>
        public abstract void Process(object item);

        internal void Start()
        {
            Enabled = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessCall));
        }

        internal void Stop()
        {
            Enabled = false;
        }
    }
}
