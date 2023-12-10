namespace SprintTrackerBasic
{
    partial class ToDoView
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
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            button3 = new Button();
            treeView1 = new System.Windows.Forms.TreeView();
            treeView2 = new System.Windows.Forms.TreeView();
            treeView3 = new System.Windows.Forms.TreeView();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.HighlightText;
            button1.Location = new Point(31, 21);
            button1.Name = "button1";
            button1.Size = new Size(113, 46);
            button1.TabIndex = 0;
            button1.Text = "New Task";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.HighlightText;
            button2.Location = new Point(610, 21);
            button2.Name = "button2";
            button2.Size = new Size(113, 46);
            button2.TabIndex = 1;
            button2.Text = "Add User";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(297, 125);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 3;
            label2.Text = "Doing";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(31, 125);
            label1.Name = "label1";
            label1.Size = new Size(63, 28);
            label1.TabIndex = 4;
            label1.Text = "To Do";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(563, 125);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 5;
            label3.Text = "Done";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaptionText;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.HighlightText;
            button3.Location = new Point(176, 21);
            button3.Name = "button3";
            button3.Size = new Size(113, 46);
            button3.TabIndex = 9;
            button3.Text = "Calendar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(31, 172);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(208, 259);
            treeView1.TabIndex = 10;
            // 
            // treeView2
            // 
            treeView2.Location = new Point(297, 172);
            treeView2.Name = "treeView2";
            treeView2.Size = new Size(208, 259);
            treeView2.TabIndex = 11;
            // 
            // treeView3
            // 
            treeView3.Location = new Point(563, 172);
            treeView3.Name = "treeView3";
            treeView3.Size = new Size(208, 259);
            treeView3.TabIndex = 12;
            // 
            // ToDoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(treeView3);
            Controls.Add(treeView2);
            Controls.Add(treeView1);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ToDoView";
            Text = "ToDoView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button button3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TreeView treeView3;
    }
}