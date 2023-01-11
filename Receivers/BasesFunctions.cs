using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Receivers
{
    internal class BasesFunctions
    {
        public static void AddRunner(int runners)
        {
            while(runners > 0)
            {
                switch (Globals.Bases)
                {
                    case 0b1100:
                        Globals.Bases = 0b1110;
                        break;
                    case 0b1110:
                        Globals.Bases = 0b1111;
                        break;
                    case 0b1111:
                        // add run to batter
                        Globals.Bases = 0b1000;
                        break;
                    case 0b1010:
                        Globals.Bases = 0b1101;
                        break;
                    case 0b1011:
                        // add run to batter
                        Globals.Bases = 0b1101;
                        break;
                    case 0b1001:
                        // add run to batter
                        Globals.Bases = 0b1100;
                        break;
                    default:
                        Globals.Bases = 0b1100;
                        break;
                }
                runners--;
            }
            
        }
        public static string CheckBases()
        {
            switch (Globals.Bases)
            {
                //home first second third
                //1111

                case 0b1000:
                    return "home";
                case 0b1100:
                    return "homeandfirst";
                case 0b1110:
                    return "homefirstandsecond";
                case 0b1111:
                    return "basesloaded";
                case 0b1010:
                    return "homeandsecond";
                case 0b1011:
                    return "homesecondandthird";
                case 0b1001:
                    return "homeandthird";
                default:
                    return "empty";
            }
            
        }
    }
}
