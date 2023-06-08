using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Roll20MacroMaker.Model
{
    public class SpellRange
    {
        // Instance Members
        public static readonly SpellRange Personal = new SpellRange("Personal");
        public static readonly SpellRange Touch = new SpellRange("Touch");
        public static readonly SpellRange Close = new SpellRange("Close");
        public static readonly SpellRange Medium = new SpellRange("Medium");
        public static readonly SpellRange Long = new SpellRange("Long");
        public static readonly SpellRange Unlimited = new SpellRange("Unlimited");
        public static readonly SpellRange Static = new SpellRange("Static (Feet)");
        public static readonly SpellRange Special = new SpellRange("Special (Custom)");

        // Properties
        public string Name { get; }

        // Constructor(s)
        private SpellRange(string name)
        {
            this.Name = name;
        }

        // Action methods
        public static List<SpellRange> GetAllInstances()
        {
            return typeof(SpellRange)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SpellRange) && f.GetValue(null) is SpellRange)
                .Select(f => (SpellRange)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
