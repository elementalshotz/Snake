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
        private Label label1;
        private Label playerOneScore;
        private Label label2;
        private Label label3;
        private Label playerTwoScore;
        private Label label4;
        private Label label5;
        private Label playerThreeScore;
        private Label label6;

        Font font = new Font("Verdana", 10);
        Brush brush = new SolidBrush(Color.GhostWhite);

        List<Food> foodList = new List<Food>();
        List<Player> playerList = new List<Player>();
        List<FlowLayoutPanel> flowPanels = new List<FlowLayoutPanel>();
        Collider collider;

        System.Windows.Forms.Timer timer;
        Random random = new Random();

        public ref System.Windows.Forms.Timer DrawTimer
        {
            get => ref timer;
        }

        public Form1() : base()
        {
            foodList.Clear();
            playerList.Clear();
            Invalidate();

            Text = $"Snek - Players: {this.playerList.Count}";
            AutoSize = true;
            DoubleBuffered = true;
            InitializeComponent();

            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            Resize += Form1_Resize;

            Settings.Width = panel2.Width;
            Settings.Height = panel2.Height;

            flowPanels.Add(flowLayoutPanel3);
            flowPanels.Add(flowLayoutPanel4);
            flowPanels.Add(flowLayoutPanel5);
            //collider = new Collider(foodList, playerList);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Settings.Width = panel2.Width;
            Settings.Height = panel2.Height;
        }

        internal Form1 ResetComponents()
        {
            return new Form1();
        }

        internal void activatePlayers(int v)
        {
            for (int i = 0; i < v; i++)
            {
                playerList.Add(new Player(Settings.playerKeys[i], Settings.playerColor[i], Settings.startLocations[i], i));
                flowPanels[i].Visible = true;
            }

            foreach (var player in playerList)
            {
                player.scoreChangeEvent += Player_scoreChangeEvent;
            }

            Text = $"Snek - Players: {this.playerList.Count}";
        }

        private void Player_scoreChangeEvent()
        {
            playerOneScore.Text = "Score: " + playerList.First().Score;
            
            if (playerList.Count > 1)
            {
                playerTwoScore.Text = "Score: " + playerList.ElementAt(1).Score;
                playerThreeScore.Text = "Score: " + playerList.ElementAt(2).Score;
            }
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

            foreach (var player in playerList)
            {
                player.MoveSnake();

                if (player.snakeBody.Count < 8) player.snakeBody.Add(new BodyPart(player.snakeBody.Last().PartPoint));

                //collider.Collide(player);
            }

            /*foreach (var food in foodList)
            {
                food.Hit(collider);
            }*/

            Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (var player in playerList)
            {
                player.Draw(e.Graphics);
            }

            foreach (var food in foodList)
            {
                food.Draw(e.Graphics);
            }
        }
    }
}
