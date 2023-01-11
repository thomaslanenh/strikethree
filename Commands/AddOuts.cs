using StrikeThree.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{
    internal static class AddOuts
    {
        public static void Execute(int outs)
        {
            PitchingDuel.AddOut(outs);
        }
    }
}
