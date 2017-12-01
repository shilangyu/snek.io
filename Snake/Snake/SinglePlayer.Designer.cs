namespace Snake
{
    partial class singlePlayer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sketch = new System.Windows.Forms.PictureBox();
            this.snakeUpdate = new System.Windows.Forms.Timer(this.components);
            this.labelGameover = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).BeginInit();
            this.SuspendLayout();
            // 
            // sketch
            // 
            this.sketch.BackColor = System.Drawing.Color.DarkCyan;
            this.sketch.Location = new System.Drawing.Point(12, 22);
            this.sketch.Name = "sketch";
            this.sketch.Size = new System.Drawing.Size(1600, 900);
            this.sketch.TabIndex = 0;
            this.sketch.TabStop = false;
            this.sketch.Paint += new System.Windows.Forms.PaintEventHandler(this.sketch_Paint);
            // 
            // snakeUpdate
            // 
            this.snakeUpdate.Interval = 500;
            this.snakeUpdate.Tick += new System.EventHandler(this.snakeUpdate_Tick);
            // 
            // labelGameover
            // 
            this.labelGameover.AutoSize = true;
            this.labelGameover.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGameover.Location = new System.Drawing.Point(350, 217);
            this.labelGameover.Name = "labelGameover";
            this.labelGameover.Size = new System.Drawing.Size(0, 19);
            this.labelGameover.TabIndex = 1;
            this.labelGameover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(22, 22);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(0, 13);
            this.labelScore.TabIndex = 2;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(523, 524);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 3;
            // 
            // singlePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 941);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.labelGameover);
            this.Controls.Add(this.sketch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "singlePlayer";
            this.Text = "Snake.io";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formSnake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sketch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sketch;
        private System.Windows.Forms.Timer snakeUpdate;
        private System.Windows.Forms.Label labelGameover;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelError;
    }
}


