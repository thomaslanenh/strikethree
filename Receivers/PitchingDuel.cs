using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Receivers
{
    internal class PitchingDuel
    {
        public PitchingDuel()
        {
        
        }

        public void DestroyBothCards()
        {
            Globals.CurrentPitch.Destroyed = true;
            Globals.CurrentHit.Destroyed = true;
        }

        public void DestroyBatter()
        {
            Globals.CurrentHit.Destroyed = true;
        }

        public void AddStrike()
        {
            Globals.Strikes += 1;
        }

        public void CalculateStrikeChance()
        {
            var currentPitchStrike = Globals.CurrentPitch.StrikeChance;
            var currentBatChance = Globals.CurrentHit.HitChance;
            var totalResult = currentPitchStrike - currentBatChance;
            Debug.WriteLine(totalResult);

            if (totalResult <= 0)
            {
                Debug.WriteLine("YOU'RE OUTTA HERE");
                AddStrike();
                DestroyBatter();
                AddOut(1);
            }
            else
            {
                DestroyBothCards();
            }
        }

        public void CalculateBatHealth()
        {
            var currentBatHealth = Globals.CurrentHit.CardHealth;
            var currentBatDefense = Globals.CurrentHit.CardDefense;
            var currentPitchStrength = Globals.CurrentPitch.CardDamage;

            currentBatHealth = currentBatHealth - (currentPitchStrength - currentBatDefense);

            if (currentBatHealth > 0)
            {
                Globals.CurrentHit.CardHealth = currentBatHealth;
            }
            else if (currentBatHealth <= 0)
            {
                Globals.CurrentHit.CardHealth = 0;
            }
        }

        public void AddOut(int outs)
        {
            if (Globals.Outs + outs < 3)
            {
                Globals.Outs += outs;
            }
            else
            {
                // destroy everything and change game state to next round?
            }
        }

        public void CheckForBatBattleOut()
        {
            if (Globals.CurrentHit.CardHealth <= 0 && Globals.CurrentHit.Destroyed == false)
            {
                AddOut(1);
                Globals.CurrentHit.Destroyed = true;
            }
        }
    }
}
