using SprintTrackerBasic.Tasks;
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
    public partial class SprintCreator : Form
    {
        private CalendarView calendarView;
        ViewOrganizer vo = ViewOrganizer.GetInstance();
        private DateTime start;
        public SprintCreator(CalendarView cw)
        {
            InitializeComponent();
            calendarView = cw;
            PopulateDates();
        }

        private void PopulateDates()
        {
            comboBox2.Items.Clear();

            DateTime currentDate = DateTime.Today;
            DateTime lastDayOfNextMonth = currentDate.AddMonths(1).AddDays(-1).Date;
            for (DateTime date = currentDate; date <= lastDayOfNextMonth; date = date.AddDays(1))
            {
                comboBox2.Items.Add(date.ToShortDateString());
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(comboBox2.SelectedItem.ToString(), out DateTime selectedDate))
            {
                start = selectedDate;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (start != DateTime.MinValue)
            {
                Sprint sprint = new Sprint(start);
                vo.AddSprint(sprint);
                calendarView.AddSprint(sprint);
                this.Close();
            }

        }
    }
}
