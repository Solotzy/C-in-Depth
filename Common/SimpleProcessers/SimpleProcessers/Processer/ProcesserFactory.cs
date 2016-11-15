using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace SimpleProcessers.Processer
{
    /// <summary>
    /// 定义用于延时处理一些逻辑的处理器工厂
    /// </summary>
    public class ProcesserFactory
    {
        private readonly ConcurrentDictionary<string, ProcesserBase> procTable = new ConcurrentDictionary<string, ProcesserBase>();

        public event EventHandler TaskFinished;

        /// <summary>
        /// 将待处理对象添加到工厂中的指定处理器中
        /// </summary>
        /// <param name="procName">处理器名称</param>
        /// <param name="obj">待处理对象</param>
        public void Add(string procName, object obj)
        {
            procTable[procName]?.Add(obj);
        }

        public void Start(string procName)
        {
            procTable[procName]?.Start();
        }

        public void Stop(string procName)
        {
            procTable[procName]?.Stop();
        }

        public IList<ProcesserBase> GetAllProcessers()
        {
            return procTable.Values.ToList();
        }

        public void ClearAll()
        {
            procTable.Clear();
        }

        /// <summary>
        /// 在工厂中立即处理待处理对象
        /// </summary>
        /// <param name="procName">处理器名称</param>
        /// <param name="obj">待处理对象</param>
        public void Process(string procName, object obj)
        {
            procTable[procName]?.Process(obj);
        }

        void ProcesserFactory_TaskFinished(Object sender, EventArgs e)
        {
            ProcesserBase processer = (ProcesserBase) sender;
            ProcesserBase value = null;

            procTable.TryRemove(processer.Name, out value);
            //使用Null条件成员访问来简化委托调用
            TaskFinished?.Invoke(sender, e);
        }

        public virtual void Register(string processerName, ProcesserBase processer)
        {
            processer.Name = processerName;
            processer.TaskInstanceId = DateTime.Now.ToString("yyyyMMdd") + Guid.NewGuid();
            procTable[processer.Name] = processer;
            procTable[processer.Name].TaskFinished += ProcesserFactory_TaskFinished;
            AfterRegister(processer);
        }

        protected virtual void AfterRegister(ProcesserBase processer)
        { }
    }
}
