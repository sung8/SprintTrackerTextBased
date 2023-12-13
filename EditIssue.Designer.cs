namespace SprintTrackerBasic
{
    partial class EditIssue
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
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label16 = new Label();
            listBox1 = new ListBox();
            button2 = new Button();
            listBox2 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Location = new Point(194, 138);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(254, 90);
            textBox3.TabIndex = 62;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(194, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 23);
            textBox1.TabIndex = 61;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(45, 138);
            label1.Name = "label1";
            label1.Size = new Size(116, 28);
            label1.TabIndex = 60;
            label1.Text = "Description:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(45, 49);
            label16.Name = "label16";
            label16.Size = new Size(100, 28);
            label16.TabIndex = 59;
            label16.Text = "Issue Title:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(194, 273);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(254, 49);
            listBox1.TabIndex = 64;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick_1;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.HighlightText;
            button2.Location = new Point(194, 360);
            button2.Name = "button2";
            button2.Size = new Size(113, 46);
            button2.TabIndex = 63;
            button2.Text = "Modify";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(45, 237);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(116, 169);
            listBox2.TabIndex = 65;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(45, 200);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 66;
            label2.Text = "Issues:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(194, 237);
            label3.Name = "label3";
            label3.Size = new Size(58, 28);
            label3.TabIndex = 67;
            label3.Text = "Subs:";
            // 
            // EditIssue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 440);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label16);
            Name = "EditIssue";
            Text = "EditIssue";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox3;
        private TextBox textBox1;
        private Label label1;
        private Label label16;
        private ListBox listBox1;
        private Button button2;
        private ListBox listBox2;
        private Label label2;
        private Label label3;
    }
}