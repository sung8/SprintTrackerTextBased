using SprintTrackerBasic.Observer;
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
    public partial class IssueNotificationLog : Form
    {
        NotificationLog notifLog = NotificationLog.GetInstance();
        public IssueNotificationLog()
        {
            InitializeComponent();
            UpdateLogUI();
        }

        private void UpdateLogUI()
        {
            // Assuming GetLogHistory returns a List<string>
            List<string> logHistory = notifLog.GetLogHistory();

            // Convert the list of strings to a single string with line breaks
            string logText = string.Join(Environment.NewLine, logHistory);

            // Set the label text
            label2.Text = logText;
        }

    }
}
