﻿using System;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace AsyncForm
{
    public class AsyncForm : Form
    {
        Label label;
        Button button;

        public AsyncForm()
        {
            label = new Label
            {
                Location = new Point(10, 20),
                Text = "Length"
            };
            button = new Button
            {
                Location = new Point(10, 50),
                Text = "Click"
            };
            button.Click += DisplayWebSiteLength;
            AutoSize = true;
            Controls.Add(label);
            Controls.Add(button);
        }

        async void DisplayWebSiteLength(object sender, EventArgs e)
        {
            label.Text = "Fetching...";
            using (HttpClient client = new HttpClient())
            {
                string text =
                    await client.GetStringAsync("http://csharpindepth.com");
                label.Text = text.Length.ToString();
            }
        }
    }
}