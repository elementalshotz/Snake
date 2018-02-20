using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public class Form1 : Form
    {
        public Form1() : base()
        {
            Text = "";
            AutoSize = true;
            DoubleBuffered = true;
            BackColor = System.Drawing.Color.White;

            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Size = new Size(this.Size.Width, this.Size.Height);
            flow.AutoSize = true;
            flow.BackColor = System.Drawing.Color.Blue;
            Controls.Add(flow);
        }
    }
}
