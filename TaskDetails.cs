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
    public partial class TaskDetails : Form
    {
        public TaskDetails(Tasks.Task task)
        {
            InitializeComponent();
            //treeView1.Nodes.Add(PopulateTree(task));
        }

        /*private TreeNode PopulateTree(Tasks.Task task)
        {
            var node = new TreeNode(task.name);

            foreach (var subtask in task.children)
            {
                Tasks.Task st = (Tasks.TaskComposite)subtask;

                if (subtask is TaskComposite st)
                {
                    node.Nodes.Add(PopulateTree(st));

                }
                else if (subtask is Task t)
                {
                    // Handle displaying a Task somehow 

                }
            }

            return node;
        }*/

    }
}
