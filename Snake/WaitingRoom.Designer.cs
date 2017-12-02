namespace Snake
{
    partial class WaitingRoom
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
            this.test = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.test.AutoSize = true;
            this.test.Depth = 0;
            this.test.Font = new System.Drawing.Font("Roboto", 11F);
            this.test.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.test.Location = new System.Drawing.Point(129, 123);
            this.test.MouseState = MaterialSkin.MouseState.HOVER;
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(108, 19);
            this.test.TabIndex = 0;
            this.test.Text = "materialLabel1";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(0, 277);
            this.materialRaisedButton1.MaximumSize = new System.Drawing.Size(0, 100);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(374, 100);
            this.materialRaisedButton1.TabIndex = 1;
            this.materialRaisedButton1.Text = "Start";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            // 
            // WaitingRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 377);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.test);
            this.Name = "WaitingRoom";
            this.Text = "WaitingRoom";
            this.Load += new System.EventHandler(this.WaitingRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel test;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}