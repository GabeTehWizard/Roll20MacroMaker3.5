using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Roll20MacroMaker.Model
{
    public class CastingTime
    {
        // Instance Members
        public static readonly CastingTime Standard = new CastingTime("Standard Action");
        public static readonly CastingTime FullRound = new CastingTime("Full Round Action");
        public static readonly CastingTime Free = new CastingTime("Free Action");
        public static readonly CastingTime Swift = new CastingTime("Swift Action");
        public static readonly CastingTime Immediate = new CastingTime("Immediate Action");
        public static readonly CastingTime Special = new CastingTime("Special (See Desc)");

        // Properties
        public string Name { get; }

        // Constructor(s)
        private CastingTime(string name)
        {
            this.Name = name;
        }

        // Action Methods
        public static List<CastingTime> GetAllInstances()
        {
            return typeof(CastingTime)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(CastingTime) && f.GetValue(null) is CastingTime)
                .Select(f => (CastingTime)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
