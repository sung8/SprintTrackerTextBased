namespace SprintTrackerBasic
{
    partial class Issues
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
            label16 = new Label();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            button4 = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(37, 76);
            label16.Name = "label16";
            label16.Size = new Size(100, 28);
            label16.TabIndex = 53;
            label16.Text = "Issue Title:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(37, 165);
            label1.Name = "label1";
            label1.Size = new Size(116, 28);
            label1.TabIndex = 54;
            label1.Text = "Description:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(37, 271);
            label2.Name = "label2";
            label2.Size = new Size(281, 28);
            label2.TabIndex = 55;
            label2.Text = "Select Team Members to Alert: ";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.HighlightText;
            button2.Location = new Point(186, 434);
            button2.Name = "button2";
            button2.Size = new Size(113, 46);
            button2.TabIndex = 56;
            button2.Text = "Create Issue";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(186, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 23);
            textBox1.TabIndex = 57;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(186, 165);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(254, 90);
            textBox3.TabIndex = 58;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Desktop;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(38, 312);
            button4.Name = "button4";
            button4.Size = new Size(166, 33);
            button4.TabIndex = 60;
            button4.Text = "Add Team Member";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(38, 363);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(295, 34);
            listBox1.TabIndex = 59;
            // 
            // Issues
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 562);
            Controls.Add(button4);
            Controls.Add(listBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label16);
            Name = "Issues";
            Text = "Issues";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label16;
        private Label label1;
        private Label label2;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox3;
        private Button button4;
        private ListBox listBox1;
    }
}