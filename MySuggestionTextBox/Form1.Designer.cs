namespace MySuggestingTextBox
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
            this.textBox1 = new Nvd.Windows.Forms.TextBox();
            this.textBox2 = new Nvd.Windows.Forms.TextBox();
            this.textBox3 = new Nvd.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBox1.ListBoxDynamicWidth = false;
            this.textBox1.ListItems = null;
            this.textBox1.ListItemsBackColor = System.Drawing.Color.Aqua;
            this.textBox1.ListItemsFont = null;
            this.textBox1.ListItemsForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBox1.WaterMarkText = "BC FC Changed";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBox2.ListBoxDynamicWidth = false;
            this.textBox2.ListItems = null;
            this.textBox2.ListItemsBackColor = System.Drawing.Color.Empty;
            this.textBox2.ListItemsFont = null;
            this.textBox2.ListItemsForeColor = System.Drawing.Color.Empty;
            this.textBox2.Location = new System.Drawing.Point(139, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBox2.WaterMarkText = "Nothing";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.textBox3.ListBoxDynamicWidth = true;
            this.textBox3.ListItems = null;
            this.textBox3.ListItemsBackColor = System.Drawing.Color.Empty;
            this.textBox3.ListItemsFont = null;
            this.textBox3.ListItemsForeColor = System.Drawing.Color.Empty;
            this.textBox3.Location = new System.Drawing.Point(266, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.WaterMarkColor = System.Drawing.Color.Gray;
            this.textBox3.WaterMarkText = "Dynamic";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 544);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Nvd.Windows.Forms.TextBox textBox1;
        private Nvd.Windows.Forms.TextBox textBox2;
        private Nvd.Windows.Forms.TextBox textBox3;
    }
}