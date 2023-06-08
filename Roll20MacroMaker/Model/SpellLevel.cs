using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roll20MacroMaker.Model
{
    public class SpellLevel
    {
        // Instance Members
        public static readonly SpellLevel Level0 = new SpellLevel("Level 0", 0);
        public static readonly SpellLevel Level1 = new SpellLevel("Level 1", 1);
        public static readonly SpellLevel Level2 = new SpellLevel("Level 2", 2);
        public static readonly SpellLevel Level3 = new SpellLevel("Level 3", 3);
        public static readonly SpellLevel Level4 = new SpellLevel("Level 4", 4);
        public static readonly SpellLevel Level5 = new SpellLevel("Level 5", 5);
        public static readonly SpellLevel Level6 = new SpellLevel("Level 6", 6);
        public static readonly SpellLevel Level7 = new SpellLevel("Level 7", 7);
        public static readonly SpellLevel Level8 = new SpellLevel("Level 8", 8);
        public static readonly SpellLevel Level9 = new SpellLevel("Level 9", 9);
        public static readonly SpellLevel Fundamental = new SpellLevel("Fundamental", 0);

        // Properties
        public string Name { get; }
        public int Level { get; }

        // Constructor(s)
        private SpellLevel(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        // Action Methods
        public static implicit operator int(SpellLevel spellLevel)
        {
            return spellLevel.Level;
        }

        public static List<SpellLevel> GetAllInstances()
        {
            return typeof(SpellLevel)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SpellLevel) && f.GetValue(null) is SpellLevel)
                .Select(f => (SpellLevel)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
