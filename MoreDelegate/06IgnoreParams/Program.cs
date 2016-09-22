/*
 * 使用忽略了参数的匿名方法来订阅事件
 */
using System;
using System.Windows.Forms;

namespace _06IgnoreParams
{
    class Program
    {
        static void Main(string[] args)
        {
            Button button = new Button();
            button.Text = "Click me";
            button.Click += delegate { Console.WriteLine("LogPlain"); };
            button.KeyPress += delegate { Console.WriteLine("LogKey"); };
            button.MouseClick += delegate { Console.WriteLine("LogMouse"); };

            Form form = new Form();
            form.AutoSize = true;
            form.Controls.Add(button);
            Application.Run(form);
        }
    }
}
