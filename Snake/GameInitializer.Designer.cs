namespace Snake
{
    partial class GameInitializer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.threePlayers = new System.Windows.Forms.Button();
            this.twoPlayers = new System.Windows.Forms.Button();
            this.onePlayer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Coral;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.threePlayers);
            this.panel1.Controls.Add(this.twoPlayers);
            this.panel1.Controls.Add(this.onePlayer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 261);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.Location = new System.Drawing.Point(96, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // threePlayers
            // 
            this.threePlayers.BackColor = System.Drawing.Color.Aqua;
            this.threePlayers.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.threePlayers.Location = new System.Drawing.Point(67, 118);
            this.threePlayers.Name = "threePlayers";
            this.threePlayers.Size = new System.Drawing.Size(145, 47);
            this.threePlayers.TabIndex = 2;
            this.threePlayers.Text = "3 Player(s)";
            this.threePlayers.UseVisualStyleBackColor = false;
            this.threePlayers.Click += new System.EventHandler(this.threePlayers_Click);
            // 
            // twoPlayers
            // 
            this.twoPlayers.BackColor = System.Drawing.Color.Aqua;
            this.twoPlayers.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayers.Location = new System.Drawing.Point(67, 65);
            this.twoPlayers.Name = "twoPlayers";
            this.twoPlayers.Size = new System.Drawing.Size(145, 47);
            this.twoPlayers.TabIndex = 1;
            this.twoPlayers.Text = "2 Player(s)";
            this.twoPlayers.UseVisualStyleBackColor = false;
            this.twoPlayers.Click += new System.EventHandler(this.twoPlayers_Click);
            // 
            // onePlayer
            // 
            this.onePlayer.BackColor = System.Drawing.Color.Aqua;
            this.onePlayer.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayer.Location = new System.Drawing.Point(67, 12);
            this.onePlayer.Name = "onePlayer";
            this.onePlayer.Size = new System.Drawing.Size(145, 47);
            this.onePlayer.TabIndex = 0;
            this.onePlayer.Text = "1 Player(s)";
            this.onePlayer.UseVisualStyleBackColor = false;
            this.onePlayer.Click += new System.EventHandler(this.onePlayer_Click);
            // 
            // GameInitializer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Name = "GameInitializer";
            this.Text = "GameInitializer";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button threePlayers;
        private System.Windows.Forms.Button twoPlayers;
        private System.Windows.Forms.Button onePlayer;
        private System.Windows.Forms.Button button1;
    }
}