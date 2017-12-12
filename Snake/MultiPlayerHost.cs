using SimpleTCP;
using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class MultiPlayerHost : Form
    {
        // properties
        Game g;
        Snake s, s1;
        Food f;
        SimpleTcpServer server;
        bool moveDone = false;

        // constructors
        public MultiPlayerHost(IPAddress ip)
        {
            InitializeComponent();

            int sp = 15;
            snakeUpdate.Interval = 1000 / sp;

            try
            {
                server = new SimpleTcpServer();
                    server.Delimiter = 0x13;
                    server.StringEncoder = Encoding.UTF8;
                    server.DataReceived += GetServer;
                    server.ClientConnected += Connected ;
                    server.Start(ip, 8000);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


            g = new Game(0, FitScreen(), sketch.Width, sketch.Height);
            s = new Snake(Color.Beige, g, sp, "test");
            s1 = new Snake(Color.LightYellow, g, sp, "test");
            f = new Food(Color.Black, Color.White, g, s);

        }

        // events
        private void sketch_Paint(object sender, PaintEventArgs e)
        {
            Graphics graf = e.Graphics;

            // snake
            s.Draw(graf);
            s1.Draw(graf);

            // food
            f.Draw(graf);
        }
        private void MultiPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (!moveDone)
            {
                if (e.KeyCode == Keys.Up || e.KeyValue == 87)
                {
                    s.setDirection("up");
                }
                else if (e.KeyCode == Keys.Down || e.KeyValue == 83)
                {
                    s.setDirection("down");
                }
                else if (e.KeyCode == Keys.Left || e.KeyValue == 65)
                {
                    s.setDirection("left");
                }
                else if (e.KeyCode == Keys.Right || e.KeyValue == 68)
                {
                    s.setDirection("right");
                }
                moveDone = true;
            }
        }

        // functions
        private int FitScreen()
        {
            int gw = 32;
            int gh = 18;
            int scl = 0;
            Point size = new Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // count the highest scale
            for (int i = size.X; i > 0; i--)
            {
                if (i % gw == 0)
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
            sketch.Location = new Point(size.X / 2 - sketch.Width / 2, size.Y / 2 - sketch.Height / 2);

            // reposition the score label
            //labelScore.Location = new Point(sketch.Location.X, sketch.Location.Y);

            return scl;
        }
        private void GetServer(object sender, SimpleTCP.Message e)
        {
            string recieved = Regex.Replace(e.MessageString, @"\u0013", String.Empty);

            string[] ps = recieved.Split('|');
            List<Point> ls = new List<Point>();
            foreach (string p in ps)
            {
                string[] coords = p.Split(',');
                ls.Add(new Point(int.Parse(coords[0]), int.Parse(coords[1])));
            }
            s1.Position = ls;


        }
        private void Connected(object sender, System.Net.Sockets.TcpClient e)
        {
            server.BroadcastLine($"{f.NormalFood.X},{f.NormalFood.Y}");
            snakeUpdate.Start();
        }
        private string Compress(List<Point> ls)
        {
            string res = "";
            foreach(Point p in ls)
            {
                res += $"{p.X},{p.Y}|";  
            }
            return res;
        }

        // ticks
        private void snakeUpdate_Tick(object sender, EventArgs e)
        {
            s.Teleport();
            if (DateTime.Now >= f.Time + f.Lifespan)
            {
                f.SpecialFood = new Point(-1, -1);
            }

            if (s.Eat(f.NormalFood))
            {
                s.Position.Add(new Point(s.Position.Last().X, s.Position.Last().Y));
                f.generateFood("normal", s);
                g.Score += s.Speed;
                //RefreshLabel("score", "");
                if (f.SpecialFood.X == -1 && g.R.Next(10000) % 6 == 0)
                {
                    f.generateFood("special", s);
                }
            }
            else if (s.Eat(f.SpecialFood))
            {
                s.Position.Add(new Point(s.Position.Last().X, s.Position.Last().Y));
                g.Score = g.Score + s.Speed * 10;
                f.SpecialFood = new Point(-1, -1);
                f.Bases.T.Stop();
                //RefreshLabel("score", "");
            }
            else if (s.Dead())
            {
                snakeUpdate.Stop();
                //saveGame();
            }

            moveDone = false;

            server.BroadcastLine(Compress(s.Position));

            sketch.Invalidate();
        }
    }
}
