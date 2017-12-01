namespace Snake
{
    partial class temp
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
            System.Windows.Forms.ComboBox mode;
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.speed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.sketch = new System.Windows.Forms.PictureBox();
            this.snakeColor = new MaterialSkin.Controls.MaterialFlatButton();
            this.backColor = new MaterialSkin.Controls.MaterialFlatButton();
            this.bonuses = new MaterialSkin.Controls.MaterialCheckBox();
            this.name = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.startSingle = new MaterialSkin.Controls.MaterialRaisedButton();
            mode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).BeginInit();
            // 
            // mode
            // 
            mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            mode.Items.AddRange(new object[] {
            "Empty",
            "Box"});
            mode.Location = new System.Drawing.Point(244, 98);
            mode.Name = "mode";
            mode.Size = new System.Drawing.Size(121, 21);
            mode.TabIndex = 8;
            // 
            // update
            // 
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(7, 51);
            this.speed.Maximum = 30;
            this.speed.Minimum = 1;
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(306, 45);
            this.speed.TabIndex = 0;
            this.speed.Value = 14;
            this.speed.ValueChanged += new System.EventHandler(this.speed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Speed";
            // 
            // sketch
            // 
            this.sketch.Location = new System.Drawing.Point(7, 148);
            this.sketch.Name = "sketch";
            this.sketch.Size = new System.Drawing.Size(306, 204);
            this.sketch.TabIndex = 3;
            this.sketch.TabStop = false;
            this.sketch.Paint += new System.Windows.Forms.PaintEventHandler(this.sketch_Paint);
            // 
            // snakeColor
            // 
            this.snakeColor.AutoSize = true;
            this.snakeColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.snakeColor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.snakeColor.Depth = 0;
            this.snakeColor.Location = new System.Drawing.Point(7, 89);
            this.snakeColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.snakeColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.snakeColor.Name = "snakeColor";
            this.snakeColor.Primary = false;
            this.snakeColor.Size = new System.Drawing.Size(103, 36);
            this.snakeColor.TabIndex = 5;
            this.snakeColor.Text = "Snake color";
            this.snakeColor.UseVisualStyleBackColor = false;
            this.snakeColor.Click += new System.EventHandler(this.snakeColor_Click);
            // 
            // backColor
            // 
            this.backColor.AutoSize = true;
            this.backColor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backColor.Depth = 0;
            this.backColor.Location = new System.Drawing.Point(118, 89);
            this.backColor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.backColor.MouseState = MaterialSkin.MouseState.HOVER;
            this.backColor.Name = "backColor";
            this.backColor.Primary = false;
            this.backColor.Size = new System.Drawing.Size(95, 36);
            this.backColor.TabIndex = 9;
            this.backColor.Text = "back color";
            this.backColor.UseVisualStyleBackColor = true;
            this.backColor.Click += new System.EventHandler(this.backColor_Click);
            // 
            // bonuses
            // 
            this.bonuses.AutoSize = true;
            this.bonuses.Depth = 0;
            this.bonuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.bonuses.Location = new System.Drawing.Point(244, 127);
            this.bonuses.Margin = new System.Windows.Forms.Padding(0);
            this.bonuses.MouseLocation = new System.Drawing.Point(-1, -1);
            this.bonuses.MouseState = MaterialSkin.MouseState.HOVER;
            this.bonuses.Name = "bonuses";
            this.bonuses.Ripple = true;
            this.bonuses.Size = new System.Drawing.Size(114, 30);
            this.bonuses.TabIndex = 10;
            this.bonuses.Text = "With bonuses";
            this.bonuses.UseVisualStyleBackColor = true;
            // 
            // name
            // 
            this.name.Depth = 0;
            this.name.Hint = "";
            this.name.Location = new System.Drawing.Point(7, 119);
            this.name.MouseState = MaterialSkin.MouseState.HOVER;
            this.name.Name = "name";
            this.name.PasswordChar = '\0';
            this.name.SelectedText = "";
            this.name.SelectionLength = 0;
            this.name.SelectionStart = 0;
            this.name.Size = new System.Drawing.Size(206, 23);
            this.name.TabIndex = 11;
            this.name.Text = "Your name";
            this.name.UseSystemPasswordChar = false;
            this.name.Enter += new System.EventHandler(this.name_Enter);
            this.name.Leave += new System.EventHandler(this.name_Leave);
            // 
            // startSingle
            // 
            this.startSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startSingle.Depth = 0;
            this.startSingle.Location = new System.Drawing.Point(7, 359);
            this.startSingle.MouseState = MaterialSkin.MouseState.HOVER;
            this.startSingle.Name = "startSingle";
            this.startSingle.Primary = true;
            this.startSingle.Size = new System.Drawing.Size(306, 74);
            this.startSingle.TabIndex = 12;
            this.startSingle.Text = "Play";
            this.startSingle.UseVisualStyleBackColor = true;
            this.startSingle.Click += new System.EventHandler(this.startSingle_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 466);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.TrackBar speed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox sketch;
        private MaterialSkin.Controls.MaterialFlatButton snakeColor;
        private MaterialSkin.Controls.MaterialFlatButton backColor;
        private MaterialSkin.Controls.MaterialCheckBox bonuses;
        private MaterialSkin.Controls.MaterialSingleLineTextField name;
        private MaterialSkin.Controls.MaterialRaisedButton startSingle;
    }
}