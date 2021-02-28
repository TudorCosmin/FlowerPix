namespace din_flori
{
    partial class Form1
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
            this.poza = new System.Windows.Forms.PictureBox();
            this.b_selectare = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.b_conversie = new System.Windows.Forms.Button();
            this.b_salvare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_nrmultiplicare = new System.Windows.Forms.NumericUpDown();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.poza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_nrmultiplicare)).BeginInit();
            this.SuspendLayout();
            // 
            // poza
            // 
            this.poza.Location = new System.Drawing.Point(12, 12);
            this.poza.Name = "poza";
            this.poza.Size = new System.Drawing.Size(601, 281);
            this.poza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.poza.TabIndex = 0;
            this.poza.TabStop = false;
            // 
            // b_selectare
            // 
            this.b_selectare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_selectare.Location = new System.Drawing.Point(12, 309);
            this.b_selectare.Name = "b_selectare";
            this.b_selectare.Size = new System.Drawing.Size(100, 40);
            this.b_selectare.TabIndex = 1;
            this.b_selectare.Text = "Selectare imagine";
            this.b_selectare.UseVisualStyleBackColor = true;
            this.b_selectare.Click += new System.EventHandler(this.b_selectare_Click);
            // 
            // b_exit
            // 
            this.b_exit.Location = new System.Drawing.Point(513, 309);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(100, 40);
            this.b_exit.TabIndex = 2;
            this.b_exit.Text = "Exit";
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // b_conversie
            // 
            this.b_conversie.Enabled = false;
            this.b_conversie.Location = new System.Drawing.Point(301, 309);
            this.b_conversie.Name = "b_conversie";
            this.b_conversie.Size = new System.Drawing.Size(100, 40);
            this.b_conversie.TabIndex = 3;
            this.b_conversie.Text = "Conversie";
            this.b_conversie.UseVisualStyleBackColor = true;
            this.b_conversie.Click += new System.EventHandler(this.b_conversie_Click);
            // 
            // b_salvare
            // 
            this.b_salvare.Enabled = false;
            this.b_salvare.Location = new System.Drawing.Point(407, 309);
            this.b_salvare.Name = "b_salvare";
            this.b_salvare.Size = new System.Drawing.Size(100, 40);
            this.b_salvare.TabIndex = 4;
            this.b_salvare.Text = "Salvare imagine";
            this.b_salvare.UseVisualStyleBackColor = true;
            this.b_salvare.Click += new System.EventHandler(this.b_salvare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Numar de flori pe latime:";
            // 
            // numericUpDown_nrmultiplicare
            // 
            this.numericUpDown_nrmultiplicare.Location = new System.Drawing.Point(240, 321);
            this.numericUpDown_nrmultiplicare.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown_nrmultiplicare.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_nrmultiplicare.Name = "numericUpDown_nrmultiplicare";
            this.numericUpDown_nrmultiplicare.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown_nrmultiplicare.TabIndex = 7;
            this.numericUpDown_nrmultiplicare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_nrmultiplicare.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(301, 309);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 40);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 8;
            this.progressBar.Tag = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 356);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.numericUpDown_nrmultiplicare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_salvare);
            this.Controls.Add(this.b_conversie);
            this.Controls.Add(this.b_exit);
            this.Controls.Add(this.b_selectare);
            this.Controls.Add(this.poza);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlowerPix - Proiect de atestat - Oanea Tudor Cosmin";
            ((System.ComponentModel.ISupportInitialize)(this.poza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_nrmultiplicare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox poza;
        private System.Windows.Forms.Button b_selectare;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.Button b_conversie;
        private System.Windows.Forms.Button b_salvare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_nrmultiplicare;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

