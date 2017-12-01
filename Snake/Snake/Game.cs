using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Game
    {
        // properties
        private int score;
        private int scale;
        private int width, height;
        Random r = new Random();
        Timer t = new Timer();

        // constructor
        public Game(int score, int scale, int w, int h)
        {
            Score = score;
            Scale = scale;
            Width = w / scale;
            Height = h / scale;
        }

        // functions
        

        // setters, getters
        public int Score { get => score; set => score = value; }
        public int Scale { get => scale; set => scale = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Random R { get => r; set => r = value; }
        public Timer T { get => t; set => t = value; }
    }
}
