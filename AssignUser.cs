using SprintTrackerBasic.Users;
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
    public partial class AssignUser : Form
    {
        ViewOrganizer vo = ViewOrganizer.GetInstance();
        private int tindex;
        private int mindex;
        private bool s1 = false;
        private bool s2 = false;
        private TaskCreator creator;
        private Issues i;
        public AssignUser(TaskCreator tc)
        {
            creator = tc;
            InitializeComponent();
            InitializeComboBox();
        }

        public AssignUser(Issues i)
        {
            this.i = i;
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            foreach (Team t in vo.GetTeams())
            {
                comboBox2.Items.Add(t.GetName());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            comboBox1.Items.Clear();
            tindex = comboBox2.SelectedIndex;
            for (int i = 0; i < vo.GetTeams()[tindex].GetTeamMembers().Count; i++)
            {
                comboBox1.Items.Add(vo.GetTeams()[tindex].GetTeamMembers()[i].name);
            }
            s1 = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mindex = comboBox1.SelectedIndex;
            s2 = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (s1 && s2)
            {
                if (creator != null)
                {
                    creator.AddingUser(vo.GetTeams()[tindex].GetTeamMembers()[mindex]);
                }
                else
                {
                    i.AddingUser(vo.GetTeams()[tindex].GetTeamMembers()[mindex]);
                }
                this.Close();
            }
        }
    }
}
