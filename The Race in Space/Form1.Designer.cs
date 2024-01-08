namespace The_Race_in_Space
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.galaxyLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabelp2 = new System.Windows.Forms.Label();
            this.scoreLabelp1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // galaxyLabel
            // 
            this.galaxyLabel.BackColor = System.Drawing.Color.Transparent;
            this.galaxyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.galaxyLabel.Location = new System.Drawing.Point(32, 9);
            this.galaxyLabel.Name = "galaxyLabel";
            this.galaxyLabel.Size = new System.Drawing.Size(509, 32);
            this.galaxyLabel.TabIndex = 0;
            this.galaxyLabel.Text = "A long time ago, in a galaxy far far away...";
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Gold;
            this.titleLabel.Location = new System.Drawing.Point(86, 152);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(1616, 542);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "SPACE RACE";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.Location = new System.Drawing.Point(678, 505);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(455, 52);
            this.subtitleLabel.TabIndex = 2;
            this.subtitleLabel.Text = "subtitle";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tag = "20";
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // scoreLabelp2
            // 
            this.scoreLabelp2.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabelp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabelp2.Location = new System.Drawing.Point(1413, 950);
            this.scoreLabelp2.Name = "scoreLabelp2";
            this.scoreLabelp2.Size = new System.Drawing.Size(47, 61);
            this.scoreLabelp2.TabIndex = 3;
            this.scoreLabelp2.Text = "1";
            // 
            // scoreLabelp1
            // 
            this.scoreLabelp1.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabelp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabelp1.Location = new System.Drawing.Point(538, 950);
            this.scoreLabelp1.Name = "scoreLabelp1";
            this.scoreLabelp1.Size = new System.Drawing.Size(47, 61);
            this.scoreLabelp1.TabIndex = 4;
            this.scoreLabelp1.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1522, 1020);
            this.Controls.Add(this.scoreLabelp1);
            this.Controls.Add(this.scoreLabelp2);
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.galaxyLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label galaxyLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label scoreLabelp2;
        private System.Windows.Forms.Label scoreLabelp1;
    }
}

