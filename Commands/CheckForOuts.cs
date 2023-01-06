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
        private PitchingDuel _pitchingDuel;

        public CheckForOuts(PitchingDuel pitchingDuel)
        {
            this._pitchingDuel= pitchingDuel;
        }

        public void Execute()
        {
            this._pitchingDuel.CheckForBatBattleOut();
        }
    }
}
