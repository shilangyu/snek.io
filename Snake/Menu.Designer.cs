using System.Drawing;

namespace Snake
{
    partial class Menu
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
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.singleplayer = new System.Windows.Forms.TabPage();
            this.startSingle = new MaterialSkin.Controls.MaterialRaisedButton();
            this.foodColor = new MaterialSkin.Controls.MaterialFlatButton();
            this.name = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.backColor = new MaterialSkin.Controls.MaterialFlatButton();
            this.snakeColor = new MaterialSkin.Controls.MaterialFlatButton();
            this.sketch = new System.Windows.Forms.PictureBox();
            this.speed = new System.Windows.Forms.TrackBar();
            this.multiplayer = new System.Windows.Forms.TabPage();
            this.joined = new MaterialSkin.Controls.MaterialLabel();
            this.multiName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.portNumber = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.multiJoin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.multiHost = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lb = new System.Windows.Forms.TabPage();
            this.lbView = new MaterialSkin.Controls.MaterialListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scoreColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lengthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.speedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.materialTabControl1.SuspendLayout();
            this.singleplayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            this.multiplayer.SuspendLayout();
            this.lb.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.singleplayer);
            this.materialTabControl1.Controls.Add(this.multiplayer);
            this.materialTabControl1.Controls.Add(this.lb);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(13, 103);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(760, 465);
            this.materialTabControl1.TabIndex = 0;
            // 
            // singleplayer
            // 
            this.singleplayer.Controls.Add(this.startSingle);
            this.singleplayer.Controls.Add(this.foodColor);
            this.singleplayer.Controls.Add(this.name);
            this.singleplayer.Controls.Add(this.backColor);
            this.singleplayer.Controls.Add(this.snakeColor);
            this.singleplayer.Controls.Add(this.sketch);
            this.singleplayer.Controls.Add(this.speed);
            this.singleplayer.Location = new System.Drawing.Point(4, 22);
            this.singleplayer.Name = "singleplayer";
            this.singleplayer.Padding = new System.Windows.Forms.Padding(3);
            this.singleplayer.Size = new System.Drawing.Size(752, 439);
            this.singleplayer.TabIndex = 0;
            this.singleplayer.Text = "Single player";
            // 
            // startSingle
            // 
            this.startSingle.AutoSize = true;
            this.startSingle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startSingle.Depth = 0;
            this.startSingle.Icon = null;
            this.startSingle.Location = new System.Drawing.Point(372, 308);
            this.startSingle.MinimumSize = new System.Drawing.Size(354, 125);
            this.startSingle.MouseState = MaterialSkin.MouseState.HOVER;
            this.startSingle.Name = "startSingle";
            this.startSingle.Primary = true;
            this.startSingle.Size = new System.Drawing.Size(354, 125);
            this.startSingle.TabIndex = 5;
            this.startSingle.Text = "play";
            this.startSingle.UseVisualStyleBackColor = true;
            this.startSingle.Click += new System.EventHandler(this.startSingle_Click);
            // 
            // foodColor
            // 
            this.foodColor.AutoSize = true;
            this.foodColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.foodColor.Depth = 0;
            this.foodColor.Icon = null;
            this.foodColor.Location = new System.Drawing.Point(586, 69);
            this.foodColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.foodColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.foodColor.Name = "foodColor";
            this.foodColor.Primary = false;
            this.foodColor.Size = new System.Drawing.Size(104, 36);
            this.foodColor.TabIndex = 4;
            this.foodColor.Text = "food color";
            this.foodColor.UseVisualStyleBackColor = true;
            this.foodColor.Click += new System.EventHandler(this.foodColor_Click);
            // 
            // name
            // 
            this.name.Depth = 0;
            this.name.Hint = "";
            this.name.Location = new System.Drawing.Point(372, 114);
            this.name.MaxLength = 32767;
            this.name.MouseState = MaterialSkin.MouseState.HOVER;
            this.name.Name = "name";
            this.name.PasswordChar = '\0';
            this.name.SelectedText = "";
            this.name.SelectionLength = 0;
            this.name.SelectionStart = 0;
            this.name.Size = new System.Drawing.Size(354, 23);
            this.name.TabIndex = 2;
            this.name.TabStop = false;
            this.name.Text = "Your name";
            this.name.UseSystemPasswordChar = false;
            this.name.Enter += new System.EventHandler(this.name_Enter);
            this.name.Leave += new System.EventHandler(this.name_Leave);
            // 
            // backColor
            // 
            this.backColor.AutoSize = true;
            this.backColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backColor.Depth = 0;
            this.backColor.Icon = null;
            this.backColor.Location = new System.Drawing.Point(483, 69);
            this.backColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.backColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.backColor.Name = "backColor";
            this.backColor.Primary = false;
            this.backColor.Size = new System.Drawing.Size(104, 36);
            this.backColor.TabIndex = 3;
            this.backColor.Text = "back color";
            this.backColor.UseVisualStyleBackColor = true;
            this.backColor.Click += new System.EventHandler(this.backColor_Click);
            // 
            // snakeColor
            // 
            this.snakeColor.AutoSize = true;
            this.snakeColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.snakeColor.BackColor = System.Drawing.Color.Turquoise;
            this.snakeColor.Depth = 0;
            this.snakeColor.ForeColor = System.Drawing.Color.Firebrick;
            this.snakeColor.Icon = null;
            this.snakeColor.Location = new System.Drawing.Point(372, 69);
            this.snakeColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.snakeColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.snakeColor.Name = "snakeColor";
            this.snakeColor.Primary = false;
            this.snakeColor.Size = new System.Drawing.Size(112, 36);
            this.snakeColor.TabIndex = 2;
            this.snakeColor.Text = "snake color";
            this.snakeColor.UseVisualStyleBackColor = false;
            this.snakeColor.Click += new System.EventHandler(this.snakeColor_Click);
            // 
            // sketch
            // 
            this.sketch.Location = new System.Drawing.Point(6, 15);
            this.sketch.Name = "sketch";
            this.sketch.Size = new System.Drawing.Size(347, 418);
            this.sketch.TabIndex = 1;
            this.sketch.TabStop = false;
            this.sketch.Paint += new System.Windows.Forms.PaintEventHandler(this.sketch_Paint);
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(372, 17);
            this.speed.Maximum = 30;
            this.speed.Minimum = 1;
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(354, 45);
            this.speed.TabIndex = 0;
            this.speed.Value = 15;
            this.speed.ValueChanged += new System.EventHandler(this.speed_ValueChanged);
            // 
            // multiplayer
            // 
            this.multiplayer.Controls.Add(this.joined);
            this.multiplayer.Controls.Add(this.multiName);
            this.multiplayer.Controls.Add(this.portNumber);
            this.multiplayer.Controls.Add(this.multiJoin);
            this.multiplayer.Controls.Add(this.multiHost);
            this.multiplayer.Location = new System.Drawing.Point(4, 22);
            this.multiplayer.Name = "multiplayer";
            this.multiplayer.Padding = new System.Windows.Forms.Padding(3);
            this.multiplayer.Size = new System.Drawing.Size(752, 439);
            this.multiplayer.TabIndex = 1;
            this.multiplayer.Text = "Multi player";
            // 
            // joined
            // 
            this.joined.AutoSize = true;
            this.joined.Depth = 0;
            this.joined.Font = new System.Drawing.Font("Roboto", 11F);
            this.joined.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.joined.Location = new System.Drawing.Point(7, 102);
            this.joined.MouseState = MaterialSkin.MouseState.HOVER;
            this.joined.Name = "joined";
            this.joined.Size = new System.Drawing.Size(0, 19);
            this.joined.TabIndex = 3;
            // 
            // multiName
            // 
            this.multiName.Depth = 0;
            this.multiName.Hint = "";
            this.multiName.Location = new System.Drawing.Point(6, 72);
            this.multiName.MaxLength = 32767;
            this.multiName.MouseState = MaterialSkin.MouseState.HOVER;
            this.multiName.Name = "multiName";
            this.multiName.PasswordChar = '\0';
            this.multiName.SelectedText = "";
            this.multiName.SelectionLength = 0;
            this.multiName.SelectionStart = 0;
            this.multiName.Size = new System.Drawing.Size(360, 23);
            this.multiName.TabIndex = 2;
            this.multiName.TabStop = false;
            this.multiName.Text = "Your name";
            this.multiName.UseSystemPasswordChar = false;
            this.multiName.Enter += new System.EventHandler(this.multiName_Enter);
            this.multiName.Leave += new System.EventHandler(this.multiName_Leave);
            // 
            // portNumber
            // 
            this.portNumber.BackColor = System.Drawing.Color.Salmon;
            this.portNumber.Depth = 0;
            this.portNumber.Hint = "";
            this.portNumber.Location = new System.Drawing.Point(386, 72);
            this.portNumber.MaxLength = 32767;
            this.portNumber.MouseState = MaterialSkin.MouseState.HOVER;
            this.portNumber.Name = "portNumber";
            this.portNumber.PasswordChar = '\0';
            this.portNumber.SelectedText = "";
            this.portNumber.SelectionLength = 0;
            this.portNumber.SelectionStart = 0;
            this.portNumber.Size = new System.Drawing.Size(360, 23);
            this.portNumber.TabIndex = 2;
            this.portNumber.TabStop = false;
            this.portNumber.Text = "Port number";
            this.portNumber.UseSystemPasswordChar = false;
            this.portNumber.Enter += new System.EventHandler(this.portNumber_Enter);
            this.portNumber.Leave += new System.EventHandler(this.portNumber_Leave);
            this.portNumber.TextChanged += new System.EventHandler(this.portNumber_TextChanged);
            // 
            // multiJoin
            // 
            this.multiJoin.AutoSize = true;
            this.multiJoin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.multiJoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.multiJoin.Depth = 0;
            this.multiJoin.Enabled = false;
            this.multiJoin.Icon = null;
            this.multiJoin.Location = new System.Drawing.Point(6, 228);
            this.multiJoin.MinimumSize = new System.Drawing.Size(360, 205);
            this.multiJoin.MouseState = MaterialSkin.MouseState.HOVER;
            this.multiJoin.Name = "multiJoin";
            this.multiJoin.Primary = true;
            this.multiJoin.Size = new System.Drawing.Size(360, 205);
            this.multiJoin.TabIndex = 1;
            this.multiJoin.Text = "PORT INCORRECT";
            this.multiJoin.Click += new System.EventHandler(this.multiJoin_Click);
            // 
            // multiHost
            // 
            this.multiHost.AutoSize = true;
            this.multiHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.multiHost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.multiHost.Depth = 0;
            this.multiHost.Enabled = false;
            this.multiHost.Icon = null;
            this.multiHost.Location = new System.Drawing.Point(386, 228);
            this.multiHost.MinimumSize = new System.Drawing.Size(360, 205);
            this.multiHost.MouseState = MaterialSkin.MouseState.HOVER;
            this.multiHost.Name = "multiHost";
            this.multiHost.Primary = true;
            this.multiHost.Size = new System.Drawing.Size(360, 205);
            this.multiHost.TabIndex = 0;
            this.multiHost.Text = "PORT INCORRECT";
            this.multiHost.Click += new System.EventHandler(this.multiHost_Click);
            // 
            // lb
            // 
            this.lb.Controls.Add(this.lbView);
            this.lb.Location = new System.Drawing.Point(4, 22);
            this.lb.Name = "lb";
            this.lb.Padding = new System.Windows.Forms.Padding(3);
            this.lb.Size = new System.Drawing.Size(752, 439);
            this.lb.TabIndex = 2;
            this.lb.Text = "leaderboards";
            // 
            // lbView
            // 
            this.lbView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.scoreColumn,
            this.lengthColumn,
            this.speedColumn});
            this.lbView.Depth = 0;
            this.lbView.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbView.FullRowSelect = true;
            this.lbView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lbView.Location = new System.Drawing.Point(4, 7);
            this.lbView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lbView.MouseState = MaterialSkin.MouseState.OUT;
            this.lbView.Name = "lbView";
            this.lbView.OwnerDraw = true;
            this.lbView.Size = new System.Drawing.Size(742, 429);
            this.lbView.TabIndex = 0;
            this.lbView.UseCompatibleStateImageBehavior = false;
            this.lbView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            // 
            // scoreColumn
            // 
            this.scoreColumn.Text = "Score";
            // 
            // lengthColumn
            // 
            this.lengthColumn.Text = "Snake length";
            this.lengthColumn.Width = 200;
            // 
            // speedColumn
            // 
            this.speedColumn.Text = "Speed";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(785, 31);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // update
            // 
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 571);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.materialTabControl1.ResumeLayout(false);
            this.singleplayer.ResumeLayout(false);
            this.singleplayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            this.multiplayer.ResumeLayout(false);
            this.multiplayer.PerformLayout();
            this.lb.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage singleplayer;
        private System.Windows.Forms.TabPage multiplayer;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.TrackBar speed;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.PictureBox sketch;
        private MaterialSkin.Controls.MaterialFlatButton snakeColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private MaterialSkin.Controls.MaterialFlatButton backColor;
        private MaterialSkin.Controls.MaterialSingleLineTextField name;
        private MaterialSkin.Controls.MaterialFlatButton foodColor;
        private MaterialSkin.Controls.MaterialRaisedButton startSingle;
        private System.Windows.Forms.TabPage lb;
        private MaterialSkin.Controls.MaterialListView lbView;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader scoreColumn;
        private System.Windows.Forms.ColumnHeader lengthColumn;
        private System.Windows.Forms.ColumnHeader speedColumn;
        private MaterialSkin.Controls.MaterialRaisedButton multiHost;
        private MaterialSkin.Controls.MaterialRaisedButton multiJoin;
        private MaterialSkin.Controls.MaterialSingleLineTextField portNumber;
        private MaterialSkin.Controls.MaterialSingleLineTextField multiName;
        private MaterialSkin.Controls.MaterialLabel joined;
    }
}