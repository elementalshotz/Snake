using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;

        Font font = new Font("Verdana", 10);
        Brush brush = new SolidBrush(Color.GhostWhite);

        List<Food> foodList = new List<Food>();
        List<Player> playerList = new List<Player>();

        System.Windows.Forms.Timer timer;
        Random random = new Random();

        public Form1() : base()
        {
            Text = $"Snek - Players: {this.playerList.Count}";
            AutoSize = true;
            DoubleBuffered = true;
            InitializeComponent();

            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            foodList.Add(new MagicMushroom(new Point(50, 50)));
        }
        
        internal void ResetComponents()
        {
            foodList.Clear();
            playerList.Clear();
            Invalidate();
            timer.Stop();

            Text = $"Snek - Players: {this.playerList.Count}";
            AutoSize = true;
            DoubleBuffered = true;
            InitializeComponent();

            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            foodList.Add(new MagicMushroom(new Point(50, 50)));
        }

        internal void activatePlayers(int v)
        {
            for (int i = 0; i < v; i++)
            {
                playerList.Add(new Player(Settings.playerKeys[i], Settings.playerColor[i]));
            }

            Text = $"Snek - Players: {this.playerList.Count}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var player in playerList)
            {
                player.Player_KeyDown(sender, e);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (foodList.Count < 5) foodList.Add(Food.Create());

            foreach (var food in foodList)
            {
                food.Position = new Point(random.Next(447), random.Next(389));
            }
            Refresh();
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString($"Player 1: \nScore: {playerList[0].Score}\nControls: W, A, S, D", font, brush, new PointF(0, 0));
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            if (playerList.Count > 1)
                e.Graphics.DrawString($"Player 2: \nScore: {playerList[1].Score}\nControls: Up, Down\nLeft, Right", font, brush, new PointF(0, 0));
        }

        private void flowLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {
            if (playerList.Count > 2)
                e.Graphics.DrawString($"Player 3: \nScore: {playerList[2].Score}\nControls: I, J, K, L", font, brush, new PointF(0, 0));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (var food in foodList)
            {
                food.Draw(e.Graphics, food);
            }
        }
    }
}
