using SprintTrackerBasic.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Observer
{
    public interface IssueObserverIF
    {
        string UpdateIssue(Issue issue, string attributeName, string updatedValue);
    }
}
