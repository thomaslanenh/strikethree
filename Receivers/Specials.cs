using StrikeThree.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Receivers
{
    internal class Specials
    {
        private Invoker _invoker = new Invoker();

        private static void ChangeBasesAndAddOuts(byte bases, int outs)
        {
            Globals.Bases = bases;

            Debug.WriteLine($"New bases {Globals.Bases}");
            AddOuts.Execute(outs);
        }

        public static void CurveBall126()
        {
            // "12-6: If Curveball wins duel, force a Double Play at scoring position."
            var _baseStatus = BasesFunctions.CheckBases();

            

            switch (_baseStatus)
            {
                case "home":
                    break;
                case "homeandfirst":
                    ChangeBasesAndAddOuts(0b1000, 1);
                    break;
                case "homeandsecond":
                    ChangeBasesAndAddOuts(0b1000, 1);
                    break;
                case "homeandthird":
                    ChangeBasesAndAddOuts(0b1000, 1);
                    break;
                case "homefirstandsecond":
                    ChangeBasesAndAddOuts(0b1100, 1);
                    break;
                case "homefirstandthird":
                    ChangeBasesAndAddOuts(0b1100, 1);
                    break;
                case "basesloaded":
                    ChangeBasesAndAddOuts(0b1110, 1);
                    break;
            }
        }

        public static void Bunt()
        {
            //FOUL BALL: If Bunt defeats itself in a pitch duel, draw a new batting card.
            // draw card
            // add to hand
        }
    }
}
