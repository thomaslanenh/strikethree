using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrikeThree
{
    internal class Card
    {
        public string CardName;
        public int CardDamage;
        public int CardDefense;
        public int CardHealth;
        public string CardDescription;
        public string Animation;
        public int StrikeChance;
        public int Bases;
        public string SpecialText;
        public bool Active;
        public bool Destroyed;
        public int HitChance;

        public Card(string name, int damage, int defense, string description, int health, int strikeChance, int HitChance, int bases, string? specialText)
        { 
            this.CardName = name;
            this.CardDescription = description;
            this.CardDamage = damage;
            this.CardDefense = defense;
            this.CardHealth = health;
            this.StrikeChance= strikeChance;
            this.HitChance= HitChance;
            this.Bases = bases;
            this.SpecialText = specialText;
        }

        public int dealDamage()
        {
            return 0;
        }
    }
}
