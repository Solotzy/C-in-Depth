using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
