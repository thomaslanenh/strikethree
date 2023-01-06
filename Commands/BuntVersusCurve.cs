using StrikeThree.Receivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{
    internal class BuntVersusCurve : ICommand
    {
        private PitchingDuel _pitchingDuel;

        // any additional variables here needed

        private Card _currentBat;
        private Card _currentPitch;

        public BuntVersusCurve(PitchingDuel pitchingDuel)
        {
            this._pitchingDuel = pitchingDuel;
        }

        public BuntVersusCurve(PitchingDuel pitchingDuel, Card currentBat, Card currentPitch)
        {
            this._currentPitch = currentPitch;
            this._currentBat = currentBat;
            this._pitchingDuel = pitchingDuel;
        }

        public void Execute()
        {
            this._pitchingDuel.CalculateBatHealth();
            this._pitchingDuel.CalculateStrikeChance();
        }
    }
}
