using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Observer
{
    public class NotificationLog
    {
        private static NotificationLog instance = new NotificationLog();
        private List<string> history = new List<string>();
        private NotificationLog() { }

        public static NotificationLog GetInstance()
        {
            return instance;
        }

        public void AddLog(string log)
        {
            history.AddRange(Enumerable.Repeat(log, 1));
        }

        public List<string> GetLogHistory()
        {
            return this.history;
        }
    }
}
