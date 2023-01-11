using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree.Receivers
{
    internal static class PitchingDuel
    {
       
        public static void ChangePitchStatus(Globals.PitchStatus pitchStatus)
        {
            Globals.CurrentPitchStatus= pitchStatus;
        }
        public static void DestroyBothCards()
        {
            Globals.CurrentPitch.Destroyed = true;
            Globals.CurrentHit.Destroyed = true;
        }

        public static void DestroyBatter()
        {
            Globals.CurrentHit.Destroyed = true;
        }

        public static void FoulBall()
        {
            // do foul ball animation 
            if (Globals.Strikes < 2)
            {
                Globals.Strikes++;
                // maybe should be replaced with a "discard batter"
            }

            ChangePitchStatus(Globals.PitchStatus.FOUL);
        }

        public static void AddStrike(int strikes)
        {
            Globals.Strikes += strikes;
            ChangePitchStatus(Globals.PitchStatus.STRIKE);
        }

        public static bool CalculateStrikeChance()
        {
            var currentPitchStrike = Globals.CurrentPitch.StrikeChance;
            var currentBatChance = Globals.CurrentHit.HitChance;

            var totalResult = currentPitchStrike - currentBatChance;
            
            
            if (totalResult < 0)
            {
                Debug.WriteLine($"Strike: {Globals.Strikes}");
                AddStrike(1);
                return true;
            }

            else if (totalResult == 0)
            {
                FoulBall();
                /*Random random = new Random();
                Debug.WriteLine("Time to do a calculation!");
                var randomPitch = random.NextDouble();
                var randomHit = random.NextDouble();

                var pitch = currentPitchStrike * randomPitch;
                var hit = currentBatChance * randomHit;

                if (pitch > hit)
                {
                    Debug.WriteLine($"Strike: {Globals.Strikes}");
                    AddStrike(1);
                    return true;
                }

                else if (pitch < hit)
                {
                    Debug.WriteLine("Base hit");
                    // trigger single hit animation
                    BasesFunctions.AddRunner(1);
                    return false;
                }
                else
                {
                    Debug.WriteLine("Still zero, mark as foul");
                    // do foul ball animation 
                    if (Globals.Strikes < 2)
                    {
                        Globals.Strikes++;
                        // maybe should be replaced with a "discard batter"
                        DestroyBatter();
                        return false;
                    }
                }*/
            }
            else
            {
                Debug.WriteLine("Base hit, adding Runner");
                BasesFunctions.AddRunner(1);
                DestroyBothCards();
                return false;
            }
            return false;
        }

        public static bool CalculateBatHealth()
        {
            var currentBatHealth = Globals.CurrentHit.CardHealth;
            var currentBatDefense = Globals.CurrentHit.CardDefense;
            var currentPitchStrength = Globals.CurrentPitch.CardDamage;

            currentBatHealth = currentBatHealth - (currentPitchStrength - currentBatDefense);

            if (currentBatHealth > 0)
            {
                Globals.CurrentHit.CardHealth = currentBatHealth;
                return false;
                // Add base runner
            }
            else if (currentBatHealth <= 0)
            {
                Globals.CurrentHit.CardHealth = 0;
                return true;
            }
            return false;
        }

        public static void AddOut(int outs)
        {
            if (Globals.Outs + outs < 3)
            {
                Globals.Outs += outs;
            }
            else
            {
                // destroy everything and change game state to next round?
                Globals.Outs = 3;
            }
        }

        public static void CheckForBatBattleOut()
        {
            if (Globals.CurrentHit.CardHealth <= 0 && Globals.CurrentHit.Destroyed == false)
            {
                AddOut(1);
                Globals.CurrentHit.Destroyed = true;
            }
        }
    }
}
