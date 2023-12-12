namespace SprintTrackerBasic
{
    partial class AddUserToMeeting
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
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(47, 199);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(229, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(47, 84);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(229, 94);
            listBox1.TabIndex = 1;
            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(48, 36);
            label1.Name = "label1";
            label1.Size = new Size(237, 21);
            label1.TabIndex = 2;
            label1.Text = "Add Attendees to this Meeting";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.HighlightText;
            button2.Location = new Point(103, 254);
            button2.Name = "button2";
            button2.Size = new Size(113, 46);
            button2.TabIndex = 4;
            button2.Text = "Done";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(48, 225);
            label2.Name = "label2";
            label2.Size = new Size(16, 15);
            label2.TabIndex = 5;
            label2.Text = "...";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(97, 66);
            label3.Name = "label3";
            label3.Size = new Size(179, 15);
            label3.TabIndex = 6;
            label3.Text = "*Double click list item to remove";
            // 
            // AddUserToMeeting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 335);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Name = "AddUserToMeeting";
            Text = "AddUserToMeeting";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private ListBox listBox1;
        private Label label1;
        private Button button2;
        private Label label2;
        private Label label3;
    }
}