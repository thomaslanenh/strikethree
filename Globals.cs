using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StrikeThree
{
    internal static class Globals
    {
        public static int HomeScore;
        public static int AwayScore;

        public static int Outs;
        public static int Strikes;

        public static List<bool> Bases = new List<bool>()
        {
            false, false, false, false
        };

        public static List<Card> CurrentPitcherHand = new List<Card>() 
        {
            new Card("Curveball", 5, 2, "Throw a curveball to the plate. 100% strike chance.", 1, 100, 0, 0, "12-6: If Curveball wins duel, force a Double Play at scoring position.")
        };

        public static List<Card> CurrentBatterHand = new List<Card>()
        {
            new Card("Bunt", 5, 0, "Bunt a pitch, doing 1 piece of damage to this card. If Bunt wins a duel, gain a base runner.",21, 0, 100, 1, "FOUL BALL: If Bunt defeats itself in a pitch duel, draw a new batting card.")
        };

        public static Card CurrentPitch = CurrentPitcherHand[0];
        public static Card CurrentHit = CurrentBatterHand[0];
    }
}
