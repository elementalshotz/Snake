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
        Collider collider;

        private Timer foodSpawnTimer;
        Timer _timer;

        Dictionary<int, int> scoreDictionary = new Dictionary<int, int>();

        public static readonly Random rnd = new Random(DateTime.MaxValue.Millisecond);

        public ref Timer DrawTimer => ref _timer;

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

            collider = new Collider(playerList, foodList);
            collider.GameOverEvent += Collider_GameOverEvent;
        }

        private void FoodSpawnTimer_Tick(object sender, EventArgs e)
        {
            Food food = Food.Create();
            SpawnPoint(food);

            if (foodList.Count < 100) foodList.Add(food);
        }

        private void Collider_GameOverEvent(int id)
        {
            int high = 0;
            int ID = 0;

            foreach (var item in scoreDictionary)
            {
                if (item.Value > high)
                {
                    high = item.Value;
                    ID = item.Key;
                }
            }

            MessageBox.Show($"Player {id} has survived the longest time.\nPlayer {ID} has won with a score of {high} points.");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Settings.Width = panel2.Width;
            //Settings.Height = panel2.Height;
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
                scoreDictionary[i + 1] = 0;
            }

            foreach (var player in playerList)
            {
                player.scoreChangeEvent += Player_scoreChangeEvent;
                player.Score = 0;
            }

            Text = $"Snek - Players: {this.playerList.Count}";
        }

        private void Player_scoreChangeEvent(int id, int score)
        {
            scoreDictionary[id] = score;

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

                if (player.snakeBody.Count < 8) player.snakeBody.Add(new MatrixPoint(player.snakeBody.Last().X-1, player.snakeBody.Last().Y));

                //collider.Collide(player);
                //collider.CollideWithPlayers(player);
            }

            /*Food[] foods = new Food[foodList.Count];
            foodList.CopyTo(foods);

            foreach (var food in foods)
            {
                food.Hit(collider);
            }*/

            Refresh();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (var food in foodList)
            {
                food.Draw(e.Graphics);
            }

            foreach (var player in playerList)
            {
                player.Draw(e.Graphics);
            }
        }

        public void SpawnPoint(Food food)
        {
            int x = rnd.Next(Settings.Width - Settings.size);
            int y = rnd.Next(Settings.Height - Settings.size);

            while (x % 15 != 0)
                x = rnd.Next(Settings.Width - Settings.size);

            while (y % 15 != 0)
                y = rnd.Next(Settings.Height - Settings.size);

            food.Update(new Point(x / 15, y / 15));
        }
    }
}
