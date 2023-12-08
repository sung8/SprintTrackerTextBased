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
        private static ViewOrganizer instance = new ViewOrganizer();

        private ViewOrganizer() { }


        public static ViewOrganizer getInstance()
        {
            return instance;
        } 

        public List<Users.Team> getTeams()
        {
            return teams;
        }
    }
}
