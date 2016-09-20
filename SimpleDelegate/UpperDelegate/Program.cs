using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpperDelegate
{
    class Program
    {
        static void HandleDemoEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Handled by HandleDemoEvent");
        }
        static void Main(string[] args)
        {
            EventHandler handler;
            handler = new EventHandler(HandleDemoEvent);
            handler(null, EventArgs.Empty);

            //方法组转换
            handler = HandleDemoEvent;
            handler(null, EventArgs.Empty);

            //匿名方法
            handler = delegate(object sender, EventArgs e)
            {
                Console.WriteLine("Handled anonymously");
            };
            handler(null, EventArgs.Empty);

            //匿名方法简写形式
            handler = delegate
            {
                Console.WriteLine("Handled anonymously again");
            };
            handler(null, EventArgs.Empty);

            //使用委托逆变性
            MouseEventHandler mouseEventHandler = HandleDemoEvent;
            mouseEventHandler(null, new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));

            //Func委托类型以及Lambda表达式
            Func<int, int, string> func = (x, y) => (x*y).ToString();
            Console.WriteLine(func(5, 20));

            Console.Read();
        }
    }
}
