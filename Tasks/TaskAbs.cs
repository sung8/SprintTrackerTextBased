using SprintTrackerBasic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic.Tasks
{
    public abstract class TaskAbs
    {
        private int id;
        public string name { get; set; }
        public TaskAbs parent { get; set; }
        public List<TaskAbs> children { get; } = new List<TaskAbs>();
        protected TeamMember assignedMember;


        public TaskAbs(string name)
        {
            this.name = name;
        }

        public TaskAbs(string name, TeamMember member)
        {
            this.name = name;
            this.assignedMember = member;
        }

        public string GetName()
        {
            return this.name;
        }
        public TeamMember GetTeamMember()
        {
            return this.assignedMember;
        }
        public int GetId()
        {
            if (this.id == 0)
            {
                this.id = this.parent == null
                  ? TaskIdGenerator.GenerateRootId()
                  : TaskIdGenerator.GenerateId(this.parent.id);
            }

            return this.id;
        }

        public void AddChild(TaskAbs child)
        {
            child.parent = this;
            this.children.Add(child);
        }

        public abstract void Display();
    }
}
