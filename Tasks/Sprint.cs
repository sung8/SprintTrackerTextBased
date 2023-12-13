using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public class Sprint: SprintIF
    {
        private DateTime startDate;
        public Dictionary<int, Day> Days { get; } = new Dictionary<int, Day>();

        public Sprint(DateTime startDate)
        {
            this.startDate = startDate;
            this.CalculateDays();
        }

        public DateTime GetStart()
        {
            return startDate;
        }

        private void CalculateDays()
        {
            // Fixed sprint duration of 14 days
            for (int i = 1; i <= 14; i++)
            {
                DateTime dueDate = startDate.AddDays(i - 1); // Subtract 1 to start from day 1
                Day day = new Day(dueDate);
                Days.Add(i, day); // Use the actual day id from the loop index
            }
        }

        /*public void PrintDayIdsAndDates()
        {
            foreach (var dayEntry in Days)
            {
                int dayId = dayEntry.Key;
                Day day = dayEntry.Value;
                //string dayIdString = day.GetId();
                string dueDateString = day.GetDate().ToString("yyyyMMdd");

                Console.WriteLine($"Day ID: {dayId}, Due Date: {dueDateString}");
            }
        }*/

        public string GetStringDayIdsAndDates()
        {
            var results = "";
            foreach (var dayEntry in Days)
            {
                int dayId = dayEntry.Key;
                Day day = dayEntry.Value;

                string dayIdString = day.GetId();
                string dueDateString = day.GetDate().ToString("yyyyMMdd");

                results += $"Day ID: {dayId}, Due Date: {dueDateString} \n";
            }

            return results;
        }

        public List<string> GetStringListDayIdsAndDates()
        {
            var results = new List<string>();

            foreach (var dayEntry in Days)
            {
                int dayId = dayEntry.Key;
                Day day = dayEntry.Value;

                string dayIdString = day.GetId();
                string dueDateString = day.GetDate().ToString("yyyyMMdd");

                results.Add($"Day ID: {dayId}, Due Date: {dueDateString}");
            }

            return results;
        }
    }
}
