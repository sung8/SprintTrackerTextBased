using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Observer
{
    public interface IssueObservableIF
    {
        string Subscribe(IssueObserverIF observer);
        string SubscribeMultiple(List<IssueObserverIF> observers);
        string Unsubscribe(IssueObserverIF observer);
    }
}
