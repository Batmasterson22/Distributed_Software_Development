namespace TempConvGUI
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
            this.topLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cel2Fah = new System.Windows.Forms.Button();
            this.fah2Cel = new System.Windows.Forms.Button();
            this.answerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Location = new System.Drawing.Point(18, 24);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(290, 13);
            this.topLabel.TabIndex = 0;
            this.topLabel.Text = "Enter an integer then click one of the buttons for conversion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cel2Fah
            // 
            this.cel2Fah.Location = new System.Drawing.Point(76, 106);
            this.cel2Fah.Name = "cel2Fah";
            this.cel2Fah.Size = new System.Drawing.Size(152, 23);
            this.cel2Fah.TabIndex = 2;
            this.cel2Fah.Text = "Celsius to Fahrenheit";
            this.cel2Fah.UseVisualStyleBackColor = true;
            this.cel2Fah.UseWaitCursor = true;
            this.cel2Fah.Click += new System.EventHandler(this.cel2Fah_Click);
            // 
            // fah2Cel
            // 
            this.fah2Cel.Location = new System.Drawing.Point(75, 153);
            this.fah2Cel.Name = "fah2Cel";
            this.fah2Cel.Size = new System.Drawing.Size(153, 23);
            this.fah2Cel.TabIndex = 3;
            this.fah2Cel.Text = "Fahrenheit to Celsius";
            this.fah2Cel.UseVisualStyleBackColor = true;
            this.fah2Cel.UseWaitCursor = true;
            this.fah2Cel.Click += new System.EventHandler(this.fah2Cel_Click);
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.Location = new System.Drawing.Point(115, 210);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(68, 20);
            this.answerLabel.TabIndex = 4;
            this.answerLabel.Text = "Answer";
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 293);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.fah2Cel);
            this.Controls.Add(this.cel2Fah);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.topLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cel2Fah;
        private System.Windows.Forms.Button fah2Cel;
        private System.Windows.Forms.Label answerLabel;
    }
}

