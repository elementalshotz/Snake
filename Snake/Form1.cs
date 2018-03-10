using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

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

        List<Food> foodList;
        List<Player> playerList;
        List<FlowLayoutPanel> flowPanels = new List<FlowLayoutPanel>();
        Collider collider;

        private Timer foodSpawnTimer;
        Timer _timer;

        public ref System.Windows.Forms.Timer DrawTimer => ref _timer;

        public Form1() : base()
        {
            Invalidate();
            playerList = new List<Player>();
            foodList = new List<Food>();

            playerList.Clear();
            foodList.Clear();

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

            collider = new Collider(playerList, foodList);
            collider.GameOverEvent += Collider_GameOverEvent;

            foodSpawnTimer = new Timer();
            foodSpawnTimer.Interval = 2500;
            foodSpawnTimer.Tick += FoodSpawnTimer_Tick;
        }

        private void FoodSpawnTimer_Tick(object sender, EventArgs e)
        {
            foodList.Add(Food.Create());
        }

        private void Collider_GameOverEvent(int id)
        {
            foodSpawnTimer?.Stop();
            MessageBox.Show($"Player {id} has survived the longest time.\nCheck the score to see who won!");
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
            playerList.Clear();
            foodList.Clear();

            for (int i = 0; i < v; i++)
            {
                playerList.Add(new Player(Settings.playerKeys[i], Settings.playerColor[i], Settings.startLocations[i], i+1));
            }

            foreach (var player in playerList)
            {
                player.scoreChangeEvent += Player_scoreChangeEvent;
            }

            Text = $"Snek - Players: {this.playerList.Count}";
        }

        private void Player_scoreChangeEvent(int id, int score)
        {
            if (id == 1)
                playerOneScore.Text = "Score: " + score;
            else if (id == 2)
                playerTwoScore.Text = "Score: " + score;
            else if (id == 3)
                playerThreeScore.Text = "Score: " + score;
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
            if (!foodSpawnTimer.Enabled) foodSpawnTimer.Start();

            Player[] players = new Player[playerList.Count];
            playerList.CopyTo(players);

            foreach (var player in players)
            {
                player.MoveSnake();

                if (player.snakeBody.Count < 8) player.snakeBody.Add(new BodyPart(player.snakeBody.Last().PartPoint));

                collider.Collide(player);
                collider.CollideWithPlayers(player);
            }

            Food[] foods = new Food[foodList.Count];
            foodList.CopyTo(foods);

            foreach (var food in foods)
            {
                food.Hit(collider);
            }

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
