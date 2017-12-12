using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class MultiPlayerClient : Form
    {
        // properties
        Game g;
        Snake s, s1;
        Food f;
        SimpleTcpClient client;
        bool moveDone = false;
        bool firstTime;

        // constructors
        public MultiPlayerClient(string ip)
        {
            InitializeComponent();

            int sp = 15;

            try
            {
                client = new SimpleTcpClient();
                    client.StringEncoder = Encoding.UTF8;
                    client.DataReceived += GetClient;
                    client.Connect(ip, 8000);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


            g = new Game(0, FitScreen(), sketch.Width, sketch.Height);
            s = new Snake(Color.Beige, g, sp, "test");
            s1 = new Snake(Color.LightYellow, g, sp, "test");
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
        private string Compress(List<Point> ls)
        {
            string res = "";
            foreach (Point p in ls)
            {
                res += $"{p.X},{p.Y}|";
            }
            return res;
        }
        private void GetClient(object sender, SimpleTCP.Message e)
        {
            string recieved = Regex.Replace(e.MessageString, @"\u0013", String.Empty);

            if (firstTime)
            {
                string[] coords = recieved.Split(',');

                Point p = new Point(int.Parse(coords[0]), int.Parse(coords[1]));

                f = new Food(Color.Black, Color.White, g, s, p);

                firstTime = false;
            }

            if (true)
            {
                string[] ps = recieved.Split('|');
                List<Point> ls = new List<Point>();
                foreach (string p in ps)
                {
                    string[] coords = p.Split(',');
                    ls.Add(new Point(int.Parse(coords[0]), int.Parse(coords[1])));
                }
                s1.Position = ls;
                client.WriteLine(Compress(s.Position));
            }
            
            sketch.Invalidate();
        }
        
    }
}
