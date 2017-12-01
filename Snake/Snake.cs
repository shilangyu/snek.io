using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        // properties
        private List<Point> position = new List<Point>();
        private int size;
        private int speed;
        private string name;
        private SolidBrush color;
        private Point direction;
        Game bases;

        // constructor
        public Snake(Color color, Game b, int s, string na)
        {
            Speed = s;
            Name = na;

            bases = b;
            Position.Add(new Point(bases.R.Next(bases.Width), bases.R.Next(bases.Height)));

            Size = bases.Scale;
            chooseStartingDirection(bases.Width, bases.Height);
            Color = new SolidBrush(color);

        }

        // functions
        public void Teleport()
        {
            if (this.Position.Last().X + this.Direction.X > bases.Width - 1)
                this.Position.Add(new Point(0, this.Position.Last().Y));
            else if (this.Position.Last().X + this.Direction.X < 0)
                this.Position.Add(new Point(bases.Width - 1, this.Position.Last().Y));
            else if (this.Position.Last().Y + this.Direction.Y > bases.Height - 1)
                this.Position.Add(new Point(this.Position.Last().X, 0));
            else if (this.Position.Last().Y + this.Direction.Y < 0)
                this.Position.Add(new Point(this.Position.Last().X, bases.Height - 1));
            else
                this.Position.Add(new Point(this.Position.Last().X + this.Direction.X, this.Position.Last().Y + this.Direction.Y));
            this.Position.RemoveAt(0);
        }
        public void Draw(Graphics g)
        {
            foreach (Point p in position)
            {
                g.FillRectangle(color, p.X * size, p.Y * size, size, size);
            }

        }
        public void chooseStartingDirection(int w, int h)
        {
            int[] futher = { w - Position.Last().X, 1, 0 };
            if (futher[0] < Position.Last().X)
            {
                futher[1] = -1;
                futher[2] = 0;
            }
            this.Direction = new Point(futher[1], futher[2]);
        }
        public void setDirection(string dir)
        {
            switch (dir)
            {
                case "left":
                    if (Direction.X != 1)
                        Direction = new Point(-1, 0);
                    break;
                case "right":
                    if (Direction.X != -1)
                        Direction = new Point(1, 0);
                    break;
                case "up":
                    if (Direction.Y != 1)
                        Direction = new Point(0, -1);
                    break;
                case "down":
                    if (Direction.Y != -1)
                        Direction = new Point(0, 1);
                    break;
            }
        }
        public bool Eat(Point food)
        {
            if (this.Position.Last().X == food.X && this.Position.Last().Y == food.Y)
                return true;
            return false;
        }
        public bool Dead()
        {
            for (int i = 0; i < Position.Count - 1; i++)
            {
                Point p = Position[i];
                if (p.X == Position.Last().X && p.Y == Position.Last().Y)
                    return true;
            }
            return false;
        }

        // setters, getters
        public List<Point> Position { get => position; set => position = value; }
        public int Size { get => size; set => size = value; }
        public SolidBrush Color { get => color; set => color = value; }
        public Point Direction { get => direction; set => direction = value; }
        public int Speed { get => speed; set => speed = value; }
        public string Name { get => name; set => name = value; }
    }
}
