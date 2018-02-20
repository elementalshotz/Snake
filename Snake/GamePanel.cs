using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class GamePanel : UserControl
    {
        public GamePanel() : base()
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Size = new System.Drawing.Size(800, 600);
            
            Controls.Add(flow);
        }
    }
}
