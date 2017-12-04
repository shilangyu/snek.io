using MaterialSkin;
using MaterialSkin.Controls;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Menu : MaterialForm
    {
        // properties
        int s;
        Color snake, back, food;
        Snake model;
        Game g;
        Food f;

        // constructor
        public Menu()
        {
            InitializeComponent();

            string curDir = Directory.GetCurrentDirectory();
            webBrowser.Url = new Uri($"file:///{ curDir }/help.html");

            this.ActiveControl = sketch;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            s = speed.Value;
            snake = Color.Beige;
            back = Color.DarkCyan;
            food = Color.Cyan;
            update.Interval = 1000 / s;

            // prepare the preview
            g = new Game(0, FitScreen(), sketch.Width, sketch.Height);
            model = new Snake(snake, g, s, "");
            f = new Food(Color.Black, food, g, model);

            model.setDirection("right");
            model.Position.Add(new Point(model.Position.Last().X, model.Position.Last().Y));
            model.Position.Add(new Point(model.Position.Last().X, model.Position.Last().Y));


            sketch.BackColor = back;
            update.Start();

            LoadLeaderboards();

            ResizeListViewColumns(lbView);
        }

        // events 
        private void sketch_Paint(object sender, PaintEventArgs e)
        {
            Graphics graf = e.Graphics;

            f.Draw(graf);
            model.Draw(graf);
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
        private void name_Enter(object sender, EventArgs e)
        {
            if(name.Text == "Your name")
                name.Text = "";
        }
        private void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Your name";
            }
        }
        private void foodColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                food = colorDialog.Color;
                f.Color[1] = new SolidBrush(food);
            }
        }
        private void startSingle_Click(object sender, EventArgs e)
        {
            singlePlayer SP = new singlePlayer(s, snake, back, food, name.Text);
            this.Hide();
            SP.ShowDialog();
            this.Close();
        }
        private void multiHost_Click(object sender, EventArgs e)
        {
            try
            {
                WaitingRoom r = new WaitingRoom("host", multiName.Text, Convert.ToInt32(portNumber.Text));
                    r.ShowDialog();
                r.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void multiJoin_Click(object sender, EventArgs e)
        {
            try
            {
                WaitingRoom r = new WaitingRoom("client", multiName.Text, Convert.ToInt32(portNumber.Text));
                    r.ShowDialog();
                r.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void portNumber_Leave(object sender, EventArgs e)
        {
            if (portNumber.Text == "")
                portNumber.Text = "Port number";
        }
        private void portNumber_Enter(object sender, EventArgs e)
        {
            if (portNumber.Text == "Port number")
                portNumber.Text = "";
        }
        private void portNumber_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(portNumber.Text, out var res))
            {
                multiHost.Enabled = true;
                multiJoin.Enabled = true;
                multiHost.Text = "START HOSTING";
                multiJoin.Text = "JOIN GAME";
            }
            else
            {
                multiHost.Enabled = false;
                multiJoin.Enabled = false;
                multiHost.Text = "PORT INCORRECT";
                multiJoin.Text = "PORT INCORRECT";
            }
        }
        private void multiName_Enter(object sender, EventArgs e)
        {
            if (multiName.Text == "Your name")
                multiName.Text = "";
        }
        private void multiName_Leave(object sender, EventArgs e)
        {
            if (multiName.Text == "")
                multiName.Text = "Your name";
        }

        // functions
        private int FitScreen()
        {
            int gw = 9;
            int gh = 11;
            int scl = 0;

            // count the highest scale
            for (int i = sketch.Width; i > 0; i--)
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

            return scl;
        }
        private void ResizeListViewColumns(MaterialListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }
        private void LoadLeaderboards()
        {
            try
            {
                MySQL query = new MySQL("select * from records order by score desc;");
                    MySqlDataReader result = query.Exec(new object[] { });
                    while (result.Read())
                    {
                        var i = new[] { result.GetString(1), Convert.ToString(result.GetInt32(2)), Convert.ToString(result.GetInt32(3)), Convert.ToString(result.GetInt32(4)) };
                        var item = new ListViewItem(i);
                        lbView.Items.Add(item);
                    }
                query.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ticks
        private void update_Tick(object sender, EventArgs e)
        {
            if (g.R.Next(5) == 4)
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
