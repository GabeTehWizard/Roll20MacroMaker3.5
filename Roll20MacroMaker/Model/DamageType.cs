using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roll20MacroMaker.Model
{
    public class DamageType
    {
        // Instance Members - Basic Damage Types
        public static readonly DamageType Acid = new DamageType("Acid");
        public static readonly DamageType Bludgeoning = new DamageType("Bludgeoning");
        public static readonly DamageType Cold = new DamageType("Cold");
        public static readonly DamageType Electricity = new DamageType("Electricity");
        public static readonly DamageType Fire = new DamageType("Fire");
        public static readonly DamageType Force = new DamageType("Force");
        public static readonly DamageType NegativeEnergy = new DamageType("Negative Energy");
        public static readonly DamageType Piercing = new DamageType("Piercing");
        public static readonly DamageType PositiveEnergy = new DamageType("Positive Energy");
        public static readonly DamageType Slashing = new DamageType("Slashing");
        public static readonly DamageType Sonic = new DamageType("Sonic");
        public static readonly DamageType EnergyDrain = new DamageType("Energy Drain");

        // Instance Members - Level/Hit Dice-based Damage Types
        public static readonly DamageType Level = new DamageType("Level");
        public static readonly DamageType HitDice = new DamageType("Hit Dice");

        // Instance Members - Attribute-based Damage Types
        public static readonly DamageType Strength = new DamageType("Strength");
        public static readonly DamageType Dexterity = new DamageType("Dexterity");
        public static readonly DamageType Constitution = new DamageType("Constitution");
        public static readonly DamageType Intelligence = new DamageType("Intelligence");
        public static readonly DamageType Wisdom = new DamageType("Wisdom");
        public static readonly DamageType Charisma = new DamageType("Charisma");

        // Properties
        public string Name { get; }

        // Constructor(s)
        private DamageType(string name)
        {
            this.Name = name;
        }

        // Action Methods
        public static List<DamageType> GetAllInstances()
        {
            return typeof(DamageType)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(DamageType) && f.GetValue(null) is DamageType)
                .Select(f => (DamageType)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
