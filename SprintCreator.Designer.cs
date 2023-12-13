namespace SprintTrackerBasic
{
    partial class SprintCreator
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
            label17 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(77, 36);
            label17.Name = "label17";
            label17.Size = new Size(283, 28);
            label17.TabIndex = 52;
            label17.Text = "Set Two Week Sprint Start Date";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(169, 137);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(254, 23);
            comboBox2.TabIndex = 53;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(48, 132);
            label2.Name = "label2";
            label2.Size = new Size(108, 28);
            label2.TabIndex = 54;
            label2.Text = "Start Date: ";
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaptionText;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.HighlightText;
            button3.Location = new Point(169, 233);
            button3.Name = "button3";
            button3.Size = new Size(153, 46);
            button3.TabIndex = 55;
            button3.Text = "Create Sprint";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // SprintCreator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 312);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(label17);
            Name = "SprintCreator";
            Text = "SprintCreator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label17;
        private ComboBox comboBox2;
        private Label label2;
        private Button button3;
    }
}