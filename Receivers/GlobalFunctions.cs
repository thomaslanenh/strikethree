using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Receivers
{
    internal static class GlobalFunctions
    {
        public static void AddScoreToTeam(Globals.TeamTypes team)
        {
            switch (team)
            {
                case Globals.TeamTypes.HOME:
                    Globals.HomeScore += 1;
                    break;
                case Globals.TeamTypes.AWAY:
                    Globals.HomeScore += 1;
                    break;
            }
        }


    }
}
