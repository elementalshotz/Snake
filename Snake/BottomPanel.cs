using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class BottomPanel : UserControl
    {
        public BottomPanel() : base()
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.FlowDirection = FlowDirection.LeftToRight;
            flow.AutoSize = true;
            flow.BackColor = System.Drawing.Color.LightGray;

            FlowLayoutPanel p1 = new FlowLayoutPanel();
            p1.Size = new System.Drawing.Size(150, 60);
            p1.FlowDirection = FlowDirection.TopDown;
            p1.BackColor = System.Drawing.Color.Black;
            flow.Controls.Add(p1);

            FlowLayoutPanel p2 = new FlowLayoutPanel();
            p2.Size = new System.Drawing.Size(150, 60);
            p2.FlowDirection = FlowDirection.TopDown;
            p2.BackColor = System.Drawing.Color.Black;
            flow.Controls.Add(p2);

            FlowLayoutPanel p3 = new FlowLayoutPanel();
            p3.Size = new System.Drawing.Size(150, 60);
            p3.FlowDirection = FlowDirection.TopDown;
            p3.BackColor = System.Drawing.Color.Black;
            flow.Controls.Add(p3);

            Controls.Add(flow);
            flow.Dock = DockStyle.Bottom;
            Dock = DockStyle.Bottom;
        }
    }
}
