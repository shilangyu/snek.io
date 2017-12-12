namespace Snake
{
    partial class MultiPlayerHost
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
            this.sketch = new System.Windows.Forms.PictureBox();
            this.snakeUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).BeginInit();
            this.SuspendLayout();
            // 
            // sketch
            // 
            this.sketch.BackColor = System.Drawing.Color.Khaki;
            this.sketch.Location = new System.Drawing.Point(13, 13);
            this.sketch.Name = "sketch";
            this.sketch.Size = new System.Drawing.Size(259, 236);
            this.sketch.TabIndex = 0;
            this.sketch.TabStop = false;
            this.sketch.Paint += new System.Windows.Forms.PaintEventHandler(this.sketch_Paint);
            // 
            // snakeUpdate
            // 
            this.snakeUpdate.Tick += new System.EventHandler(this.snakeUpdate_Tick);
            // 
            // MultiPlayerHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sketch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MultiPlayerHost";
            this.Text = "MultiPlayerHost";
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox sketch;
        private System.Windows.Forms.Timer snakeUpdate;
    }
}