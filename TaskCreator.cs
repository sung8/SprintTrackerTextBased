using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SprintTrackerBasic
{
    public partial class TaskCreator : Form
    {
        private string taskName;
        private DateTime dueDate;
        private string desc;
        public TaskCreator()
        {
            InitializeComponent();
            InitializeDateDropdown();
        }

        private void InitializeDateDropdown()
        {
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            DateTime currentDate = DateTime.Now;
            DateTime pastMonth = currentDate.AddDays(-30);
            for (int i = 0; i < 60; i++)
            {
                DateTime dateToAdd = pastMonth.AddDays(i);
                comboBox2.Items.Add(dateToAdd.ToShortDateString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            taskName = textBox1.Text;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(comboBox2.SelectedItem.ToString(), out DateTime selectedDate))
            {
                dueDate = selectedDate;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            desc = textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssignUser au = new AssignUser();
            this.Enabled = false;
            au.ShowDialog();
            this.Enabled = true;
        }
    }
}
