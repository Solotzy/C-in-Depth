using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEvent
{
    //Define a class to hold custom event info
    public class CustomEventArgs : EventArgs
    {
        public string Message { get; set; }

        public CustomEventArgs(string s)
        {
            Message = s;
        }
    }

    //Class that publishes an event
    class Publisher
    {
        //Declare the event using EventHandler<T>
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void DoSomething()
        {
            OnRaiseCustomEvent(new CustomEventArgs("Did something"));
        }
        //在一个受保护的虚方法包装事件调用
        //允许派生类重写事件调用行为
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            //制造一个的临时副本以避免可能的竞态条件,
            //在最后一个用户取消订阅后立即 触发事件事件前检查是否为空
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;
            //如果没有订阅者，事件为空
            if (handler != null)
            {
                e.Message += String.Format("at {0}", DateTime.Now.ToString());
                //使用()操作来触发事件
                handler(this, e);
            }
        }
    }

    class Subscriber
    {
        private string id;

        public Subscriber(string ID, Publisher pub)
        {
            id = ID;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }
        //定义事件触发时的操作
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine(id + " received this message:{0}", e.Message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Publisher pub = new Publisher();
            Subscriber sub1 = new Subscriber("sub1", pub);
            Subscriber sub2 = new Subscriber("sub2", pub);

            //调用方法触发事件
            pub.DoSomething();

            Console.WriteLine("Press Enter to close this window.");
            Console.ReadLine();
        }
    }
}
