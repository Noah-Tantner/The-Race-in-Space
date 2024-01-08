//Noah Tantner
//January 8th, 2024
// It's a simple game where two player race against eachother while there are multiple different sized
// objects that the players have to dodged to make it to the other side of the screen. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace The_Race_in_Space
{

    public partial class Form1 : Form
    {
        int time = 870;
        int scoreP1 = 0;
        int scoreP2 = 0;
        int playerSpeed = 8;


        //The values for asteroid size and asteroid speed always have to be round numbers,
        //because they're ints and get halfed later. If you half a number like 5 for example, 
        //you get 2.5 as a result, which is incompatible for an int, because integers have to be whole 
        //numbers. This explanation is for me personally so I understand my code later down the line.
        int asteroidSize = 4;
        int asteroidSpeed = 4;

        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;

        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;

        Rectangle player1 = new Rectangle(500, 800, 20, 20);
        Rectangle player2 = new Rectangle(1000, 800, 20, 20);
        Rectangle timeLeftRectangle = new Rectangle(730, 0, 40, 870);

        List<Rectangle> asteroids = new List<Rectangle>();
        List<int> asteroidSpeeds = new List<int>();
        List<SolidBrush> asteroidBrushes = new List<SolidBrush>();
        List<int> asteroidSizes = new List<int>();

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush yellowBrush = new SolidBrush (Color.Yellow);
        SolidBrush orangeBrush = new SolidBrush (Color.Orange);

        System.Windows.Media.MediaPlayer rocketSound = new System.Windows.Media.MediaPlayer();
        SoundPlayer clang = new SoundPlayer(Properties.Resources.metal_Clang);


        PointF[] player1Rocketpoints = new PointF[3];
        PointF[] player2Rocketpoints = new PointF[3];


        Random randGen = new Random();
        int randValue = 0;

        string gameState = "waiting";
        public Form1()
        {
            InitializeComponent();

            rocketSound.Open(new Uri(Application.StartupPath + "/Recources/blip.wav"));
        }

        public void GameInitialize()
        {

            //Labels were covering up the player, so I've decided to make them invisible
            //when initializing
            galaxyLabel.Visible = false;
            titleLabel.Visible = false;
            subtitleLabel.Visible = false;

            gameTimer.Enabled = true;
            scoreP1 = 0;
            scoreP2 = 0;
            time = 800;

            asteroids.Clear();
            asteroidSpeeds.Clear();
            //ballBrushes.Clear();

            //hero.X = this.Width / 2 - hero.Width / 2;
            //hero.Y = this.Height - hero.Height;

            gameState = "running";
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //soundplayer declarations
            SoundPlayer explosion = new SoundPlayer(Properties.Resources.Explosion);

            
 

            //move player 1
            movePlayer(wDown, sDown, ref player1);
            //move player 2 
            movePlayer(upArrowDown, downArrowDown, ref player2);


            //when players reach top, move 'em back down and update score accordingly
            if (player1.Y < 0)
            {
                player1.Y = this.Height;
                scoreP1++;
                clang.Play();
            }
            if (player2.Y < 0)
            {
                player2.Y = this.Height;
                scoreP2++;
                clang.Play();
            }


            //is it time to make a new asteroid?
            randValue = randGen.Next(1, 401);


            //this is where you would add a new type of asteroid, if you wanted to
            if (randValue < 51) // 50% chance of a white ball. White balls are always normal size and normal speed
            {
                createAsteroid(2, 2, whiteBrush);
            }
            if (randValue > 50 && randValue < 76) // 25% chance of a red ball. Red balls are always half size and double speed
            {
                createAsteroid(3, 1, redBrush);
            }
            if (randValue > 75 && randValue < 101) // 25% chance of a green ball. Green balls are always double size and half speed
            {
                createAsteroid(1, 4, greenBrush);
            }
            if (randValue > 100 && randValue < 126)
            {
                createAsteroid(1, 6, yellowBrush);
            }

            //move asteroids
            for (int i = 0; i < asteroids.Count(); i++)
            {
                //get the new position of y based on speed
                int x = asteroids[i].X + asteroidSpeeds[i];

                //replace the rectangle in the list with updated one
                asteroids[i] = new Rectangle(x, asteroids[i].Y, asteroidSizes[i], asteroidSizes[i]);
            }


            //check for collision between asteroids and players
            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (asteroids[i].IntersectsWith(player1))
                {
                    player1.Y = this.Height;
                    explosion.Play();
                }
            }
            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (asteroids[i].IntersectsWith(player2))
                {
                    player2.Y = this.Height;
                    explosion.Play();
                }
            }


            //remove asteroids if they go beyond the play area
            for (int i = 0; i < asteroids.Count(); i++)
            {
                if (asteroids[i].X > this.Width + 40)
                {
                    asteroids.RemoveAt(i);
                    asteroidSpeeds.RemoveAt(i);
                    asteroidBrushes.RemoveAt(i);
                    asteroidSizes.RemoveAt(i);
                    
                }
            }

            
            time--;
            timeLeftRectangle.Height = time;
            if(time < 0)
            {
                gameState = "gameover";
            }

            Refresh();

        }



        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "gameover")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "gameover")
                    {
                        this.Close();
                    }
                    break;

                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;

                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            if (gameState == "waiting")
            {
                scoreLabelp1.Text = "";
                scoreLabelp2.Text = "";
                galaxyLabel.Text = "A long time ago, in a galaxy far far away...";
                titleLabel.Text = "SPACE RACE";
                subtitleLabel.Text = "Press Space to start or Esc to exit";
            }
            else if (gameState == "gameover")
            {
                titleLabel.Visible = true;
                subtitleLabel.Visible = true;
                titleLabel.Text = "GAME OVER";
                subtitleLabel.Text = "Press Space to play again or Esc to exit";
            }
            
            else if (gameState == "running")
            {
                //update labels
                scoreLabelp1.Text = scoreP1.ToString();
                scoreLabelp2.Text = scoreP2.ToString();
                
                //draw players
                e.Graphics.FillRectangle(whiteBrush, player1);
                e.Graphics.FillRectangle(whiteBrush, player2);
                e.Graphics.FillRectangle(whiteBrush, 750, this.Height - time, 40, time);

                //draw asteroids
                for (int i = 0; i < asteroids.Count(); i++)
                {
                    e.Graphics.FillEllipse(asteroidBrushes[i], asteroids[i]);
                }

            }

            //polygons for rocket thrusters
            if (wDown)
            {
                e.Graphics.FillPolygon(orangeBrush, player1Rocketpoints);
            }
            if(upArrowDown)
            {
                e.Graphics.FillPolygon(orangeBrush, player2Rocketpoints);
            }

            player1Rocketpoints[0] = new Point(player1.X, player1.Y + 20);
            player1Rocketpoints[1] = new Point(player1.X + 10, player1.Y + 70);
            player1Rocketpoints[2] = new Point(player1.X + 20, player1.Y + 20);

            player2Rocketpoints[0] = new Point(player2.X, player2.Y + 20);
            player2Rocketpoints[1] = new Point(player2.X + 10, player2.Y + 70);
            player2Rocketpoints[2] = new Point(player2.X + 20, player2.Y + 20);
        }

        public void createAsteroid(int speedFactor, int SizeFactor, SolidBrush asteroidColor)
        {
             y = randGen.Next(10, this.Height - player1.Height - 20);
             x = 0;
             random = randGen.Next(1, 3);
            if (random == 1)
            {
                x = 0;
            }
            else 
            {
                speedFactor = -speedFactor; 
                x = this.Width; 
            }

            newAsteroid = new Rectangle(x, y, asteroidSize / 2, asteroidSize / 2);
            
            asteroids.Add(newAsteroid);
            asteroidBrushes.Add(asteroidColor);
            asteroidSpeeds.Add(asteroidSpeed * speedFactor);
            asteroidSizes.Add(asteroidSize * SizeFactor);
        }

        public void movePlayer(bool upButton, bool downButton, ref Rectangle player)
        {

            if (upButton == true)
            {
                player.Y -= playerSpeed;
            }
            if (downButton == true)
            {
                 player.Y += playerSpeed;
            }
        }

        int x, y, random;




        Rectangle newAsteroid;

    }

   
}
