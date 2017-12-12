using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class singlePlayer : Form
    {
        // properties
        Game game;
        Food food;
        Snake snake;
        bool moveDone = false;
        MySQL query;

        // constructor
        public singlePlayer(int s, Color snakeColor, Color backColor, Color foodColor, string name)
        {
            InitializeComponent();
            snakeUpdate.Interval = 1000 / s;
            sketch.BackColor = backColor;
            
            // take care of screen sizes and canvas // return scale of this screen 32x18
            int scl = FitScreen();

            // score, scale, sketch width and height, speed
            game = new Game(0, scl, sketch.Width, sketch.Height);
            // color, game properties
            snake = new Snake(snakeColor, game, s, name);
            snakeUpdate.Start();
            // color, game properties
            food = new Food(Color.Black, foodColor, game, snake);

            // labels
            labelScore = MakeItTrans(labelScore, sketch);
            labelScore.Font = new Font("Comic Sans MS", 20);
            RefreshLabel("score", "");

            labelGameover = MakeItTrans(labelGameover, sketch);
            labelGameover.Font = new Font("Comic Sans MS", 100);
        }

        // events
        private void sketch_Paint(object sender, PaintEventArgs e)
        {
            Graphics graf = e.Graphics;

            // snake
            snake.Draw(graf);

            // food
            food.Draw(graf);
        }
        private void formSnake_KeyDown(object sender, KeyEventArgs e)
        {
            if (!moveDone)
            {
                if (e.KeyCode == Keys.Up || e.KeyValue == 87)
                {
                    snake.setDirection("up");
                }
                else if (e.KeyCode == Keys.Down || e.KeyValue == 83)
                {
                    snake.setDirection("down");
                }
                else if (e.KeyCode == Keys.Left || e.KeyValue == 65)
                {
                    snake.setDirection("left");
                }
                else if (e.KeyCode == Keys.Right || e.KeyValue == 68)
                {
                    snake.setDirection("right");
                }
                moveDone = true;
            }
            if(e.KeyValue == 82 && game.T.Enabled)
            {
                singlePlayer newGame = new singlePlayer(snake.Speed, snake.Color.Color, sketch.BackColor, food.Color[1].Color, snake.Name);
                this.Hide();
                newGame.ShowDialog();
                this.Close();
            }
            else if (e.KeyValue == 27 || e.KeyValue == 81)
            {
                snakeUpdate.Enabled = false;
                DateTime stop = DateTime.Now;

                if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    this.Close();

                snakeUpdate.Enabled = true;
                food.Time = food.Time + (DateTime.Now - stop);
            }

        }

        // functions
        private void saveGame()
        {
            // save score
            try
            {
                query = new MySQL($"INSERT INTO records(name, score, length, speed) VALUES(?param0, ?param1, ?param2, ?param3)");
                    query.NonExec(new object[] { snake.Name, game.Score, snake.Position.Count, snake.Speed });
                query.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // check highscore
            try
            {
                query = new MySQL("select max(score) from records;");
                    MySqlDataReader result = query.Exec(new object[] { });
                    result.Read();
                    int highscore = result.GetInt32(0);
                query.Close();

                // timer for blinking text
                game.T = new Timer();
                game.T.Interval = 500;
                bool ani = true;
                game.T.Tick += (object sender, EventArgs e) => { if (ani) { RefreshLabel("gameover", $"GAME OVER\nHighscore: {highscore}\nPress r to restart\nPress q or ESC to quit"); ani = false; } else { RefreshLabel("gameover", ""); ani = true; } };
                game.T.Start();
                return;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private Label MakeItTrans(Label l, PictureBox p)
        {
            var pos = this.PointToScreen(l.Location);
            pos = p.PointToClient(pos);
            l.Parent = p;
            l.Location = pos;
            l.BackColor = Color.Transparent;
            return l;
        }
        private void RefreshLabel(string which, string what)
        {
            switch(which)
            {
                case "score":
                    labelScore.Text = $"Score: {game.Score}";
                    break;
                case "gameover":
                    labelGameover.Text = what;
                    break;
                default:
                    labelError.Text = $"ERROR: label '{which}' not found.";
                    break;
            }
        }
        private int FitScreen()
        {
            int gw = 32;
            int gh = 18;
            int scl = 0;
            Point size = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            
            // count the highest scale
            for(int i = size.X; i > 0; i--)
            {
                if(i % gw == 0)
                {
                    scl = i / gw;
                    break;
                }
            }

            // set the size
            sketch.Width = scl * gw;
            sketch.Height = scl * gh;

            // fullscreen
            this.WindowState = FormWindowState.Maximized;

            // reposition the canvas to be on the middle
            sketch.Location = new Point(size.X/2-sketch.Width/2, size.Y/2-sketch.Height/2);

            // reposition the score label
            labelScore.Location = new Point(sketch.Location.X, sketch.Location.Y);

            return scl;
        }

        // ticks
        private void snakeUpdate_Tick(object sender, EventArgs e)
        {
            snake.Teleport();
            if (DateTime.Now >= food.Time + food.Lifespan)
            {
                food.SpecialFood = new Point(-1, -1);
            }

            if (snake.Eat(food.NormalFood))
            {
                snake.Position.Add(new Point(snake.Position.Last().X, snake.Position.Last().Y));
                food.generateFood("normal", snake);
                game.Score += snake.Speed;
                RefreshLabel("score", "");
                if (food.SpecialFood.X == -1 && game.R.Next(10000) % 6 == 0 )
                {
                    food.generateFood("special", snake);
                }
            }
            else if (snake.Eat(food.SpecialFood))
            {
                snake.Position.Add(new Point(snake.Position.Last().X, snake.Position.Last().Y));
                game.Score = game.Score + snake.Speed * 10;
                food.SpecialFood = new Point(-1, -1);
                food.Bases.T.Stop();
                RefreshLabel("score", "");
            }
            else if (snake.Dead())
            {
                snakeUpdate.Stop();
                saveGame();
            }

            moveDone = false;
            sketch.Invalidate();
        }
    }
}
