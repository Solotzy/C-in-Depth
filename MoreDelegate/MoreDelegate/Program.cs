/*
 * 在选定按钮时按空格键，会触发Click和KeyPress事件
 * 按回车键只会触发Click事件
 * 用鼠标点击按钮，会触发Click和MouseClick事件
 */
using System;
using System.Windows.Forms;

namespace MoreDelegate
{
    class Program
    {
        static void LogPlainEvent(object sender, EventArgs e)
        {
            Console.WriteLine("LogPlain");
        }

        static void LogKeyEvent(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("LogKey");
        }

        static void LogMouseEvent(object sender, MouseEventArgs e)
        {
            Console.WriteLine("LogMouse");
        }
        static void Main(string[] args)
        {
            Button button = new Button();
            button.Text = "Click me";
            button.Click += new EventHandler(LogPlainEvent);
            button.KeyPress += new KeyPressEventHandler(LogKeyEvent);
            button.MouseClick += new MouseEventHandler(LogMouseEvent);

            Form form = new Form();
            form.AutoSize = true;
            form.Controls.Add(button);
            Application.Run(form);

            Console.Read();
        }
    }
}
