using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02ContravarianceOfParams
{
    class Program
    {
        //演示方法组转换和委托逆变性
        static void LogPlainEvent(object sender, EventArgs e)
        {
            Console.WriteLine("An event occurred");
        }
        static void Main(string[] args)
        {
            Button button = new Button();
            button.Text = "Click Me";
            button.Click += LogPlainEvent;
            button.KeyPress += LogPlainEvent;
            button.MouseClick += LogPlainEvent;

            Form form = new Form();
            form.AutoSize = true;
            form.Controls.Add(button);
            Application.Run(form);
        }
    }
}
