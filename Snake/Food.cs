using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        // properties
        private Point normalFood;
        private Point specialFood = new Point(-1, -1);
        private DateTime time;
        private TimeSpan lifespan;
        Game bases;
        private List<SolidBrush> color = new List<SolidBrush>();

        // constructor
        public Food(Color backColor, Color foreColor, Game b, Snake s)
        {
            Bases = b;
            this.Color.Add(new SolidBrush(backColor));
            this.Color.Add(new SolidBrush(foreColor));
            generateFood("normal", s);
            Lifespan = new TimeSpan(0,0,35 - s.Speed);
        }

        // functions
        public void generateFood(string which, Snake s)
        {
            if (which == "normal")
            {
                do
                {
                    NormalFood = new Point(Bases.R.Next(Bases.Width), Bases.R.Next(Bases.Height));
                } while (IsOnSnake(NormalFood, s));

            }
            else if (which == "special")
            {
                do
                {
                    SpecialFood = new Point(Bases.R.Next(Bases.Width), Bases.R.Next(Bases.Height));
                } while (IsOnSnake(SpecialFood, s));
                Time = DateTime.Now;
            }

        }
        public bool IsOnSnake(Point p, Snake s)
        {
            foreach (Point a in s.Position)
            {
                if (p.X == a.X && p.Y == a.Y)
                    return true;
            }
            return false;
        }
        public void Draw(Graphics g)
        {
            // normal
            int extra = Bases.Scale / 4;
            g.FillRectangle(Color[0], NormalFood.X * Bases.Scale + extra, NormalFood.Y * Bases.Scale + extra, Bases.Scale / 2, Bases.Scale / 2);
            extra = Bases.Scale / 6;
            g.FillRectangle(Color[1], NormalFood.X * Bases.Scale + extra, NormalFood.Y * Bases.Scale + extra, Bases.Scale / 2, Bases.Scale / 2);

            // special
            extra = Bases.Scale / 4;
            g.FillRectangle(Color[1], SpecialFood.X * Bases.Scale + extra, SpecialFood.Y * Bases.Scale + extra, Bases.Scale / 2, Bases.Scale / 2);
            extra = Bases.Scale / 6;
            g.FillRectangle(Color[0], SpecialFood.X * Bases.Scale + extra, SpecialFood.Y * Bases.Scale + extra, Bases.Scale / 2, Bases.Scale / 2);

            // lifespan bar
            if(SpecialFood != new Point(-1,-1))
                g.FillRectangle(new SolidBrush(System.Drawing.Color.Yellow),0,(bases.Height*bases.Scale)-10,(float)((bases.Width*bases.Scale)/Lifespan.TotalSeconds)*(float)(DateTime.Now.Subtract(Time)).TotalSeconds,10);
        }

        // setters, getters
        public Point NormalFood { get => normalFood; set => normalFood = value; }
        public Point SpecialFood { get => specialFood; set => specialFood = value; }
        public List<SolidBrush> Color { get => color; set => color = value; }
        internal Game Bases { get => bases; set => bases = value; }
        public TimeSpan Lifespan { get => lifespan; set => lifespan = value; }
        public DateTime Time { get => time; set => time = value; }
    }
}
