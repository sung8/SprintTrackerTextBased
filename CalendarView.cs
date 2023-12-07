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
    public partial class CalendarView : Form
    {
        Label[] labels = new Label[14];
        Label[] dayLabels = new Label[7];

        public CalendarView()
        {
            InitializeComponent();
        }

        private void CalendarView_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 14; i++)
            {
                labels[i] = (Label)this.Controls.Find("label" + (i + 1), true)[0];
            }
            for (int i = 0; i < 7; i++)
            {
                dayLabels[i] = (Label)this.Controls.Find("label" + (i + 15), true)[0];
            }

            DateTime currentDate = DateTime.Today;
            for (int i = 0; i < 14; i++)
            {
                labels[i].Text = currentDate.AddDays(i).ToShortDateString();
                if (i < 7)
                {
                    dayLabels[i].Text = currentDate.AddDays(i).DayOfWeek.ToString();
                }
            }
        }
    }
}
