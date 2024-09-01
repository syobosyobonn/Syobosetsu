namespace Syobosetsu
{
    partial class ChangeMemoName
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cansel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 19);
            this.textBox1.TabIndex = 0;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(244, 38);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(44, 23);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cansel
            // 
            this.Cansel.Location = new System.Drawing.Point(188, 38);
            this.Cansel.MaximumSize = new System.Drawing.Size(50, 23);
            this.Cansel.MinimumSize = new System.Drawing.Size(50, 23);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(50, 23);
            this.Cansel.TabIndex = 2;
            this.Cansel.Text = "Cansel";
            this.Cansel.UseVisualStyleBackColor = true;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            // 
            // ChangeMemoName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(300, 67);
            this.ControlBox = false;
            this.Controls.Add(this.Cansel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.textBox1);
            this.Name = "ChangeMemoName";
            this.ShowIcon = false;
            this.Text = "Textbox";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cansel;
    }
}