using StrikeThree.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{
    internal class CheckForOuts : ICommand
    {

        public void Execute()
        {
            PitchingDuel.CheckForBatBattleOut();
        }
    }
}
