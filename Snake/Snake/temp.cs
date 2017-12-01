using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class temp : MaterialForm
    {
        // properties
        int s;
        bool withBonuses;
        Color snake, back;
        Snake model;
        Game g;
        Food f;

        //constructor
        public temp()
        {
            InitializeComponent();
            this.ActiveControl = name;
            s = speed.Value;
            snake = Color.Beige;
            back = Color.DarkCyan;
            update.Interval = 1000 / s;

            // prepare the preview
            g = new Game(0, 34, sketch.Width, sketch.Height);
            model = new Snake(snake, g, s, "");
            f = new Food(Color.Black, Color.Cyan, g, model);

            model.setDirection("right");
            model.Position.Add(new Point(model.Position.Last().X, model.Position.Last().Y));
            model.Position.Add(new Point(model.Position.Last().X, model.Position.Last().Y));


            sketch.BackColor = back;
            update.Start();
        }

        // events
        private void sketch_Paint(object sender, PaintEventArgs e)
        {
            Graphics graf = e.Graphics;

            model.Draw(graf);
            f.Draw(graf);
        }
        private void snakeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                snake = colorDialog.Color;
                model.Color = new SolidBrush(snake);
            }
        }
        private void backColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                back = colorDialog.Color;
                sketch.BackColor = back;
            }
        }
        private void speed_ValueChanged(object sender, EventArgs e)
        {
            s = speed.Value;
            update.Interval = 1000 / s;
        }
        private void startSingle_Click(object sender, EventArgs e)
        {
            singlePlayer SP = new singlePlayer(s, snake, back, name.Text);
            this.Hide();
            SP.ShowDialog();
            this.Close();
        }
        private void name_Enter(object sender, EventArgs e)
        {
            name.Text = "";
        }
        private void name_Leave(object sender, EventArgs e)
        {
            if(name.Text == "")
            {
                name.Text = "Your name";
            }
        }


        // ticks
        private void update_Tick(object sender, EventArgs e)
        {
           if(g.R.Next(5) == 4)
           {
                switch (g.R.Next(4))
                {
                    case 0:
                        model.setDirection("right");
                        break;
                    case 1:
                        model.setDirection("left");
                        break;
                    case 2:
                        model.setDirection("up");
                        break;
                    case 3:
                        model.setDirection("down");
                        break;
                }
            }
            
           
            model.Teleport();
            sketch.Invalidate();
        }

    }
}
