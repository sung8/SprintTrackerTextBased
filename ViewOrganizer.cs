using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintTrackerBasic
{
    public class ViewOrganizer
    {
        private List<Users.Team> teams = new List<Users.Team>();
        private List<Users.TeamMember> assigned = new List<Users.TeamMember>();
        private static ViewOrganizer instance = new ViewOrganizer();

        private ViewOrganizer() { }


        public static ViewOrganizer GetInstance()
        {
            return instance;
        } 

        public List<Users.Team> GetTeams()
        {
            return teams;
        }

    }
}
