using StrikeThree.Receivers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Commands
{
    internal class BuntVersusCurve : ICommand
    {

        // any additional variables here needed

        private Card _currentBat;
        private Card _currentPitch;

        public void Execute()
        {
            var strikeAttempt = PitchingDuel.CalculateStrikeChance();
            var batDestroyed = PitchingDuel.CalculateBatHealth();

            if (batDestroyed)
            {
                Specials.CurveBall126();
            }
            
            // trigger end round
        }
    }
}
