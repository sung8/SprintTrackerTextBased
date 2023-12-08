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
        ViewOrganizer vo = ViewOrganizer.getInstance();
        private int index;
        public AssignUser()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {


            foreach (Team t in vo.getTeams())
            {
                comboBox2.Items.Add(t.name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            comboBox1.Items.Clear();
            index = comboBox2.SelectedIndex;
            for(int i = 0; i < vo.getTeams()[index].members.Count; i++)
            {
                comboBox1.Items.Add(vo.getTeams()[index].members[i].name);
            }
        }
    }
}
