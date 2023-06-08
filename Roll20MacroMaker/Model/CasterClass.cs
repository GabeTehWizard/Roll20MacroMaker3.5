using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Roll20MacroMaker.Model
{
    public class CasterClass
    {
        // Instance Members
        public static readonly CasterClass Bard = new CasterClass("Bard", "Brd");
        public static readonly CasterClass Cleric = new CasterClass("Cleric", "Clr");
        public static readonly CasterClass Druid = new CasterClass("Druid", "Drd");
        public static readonly CasterClass Paladin = new CasterClass("Paladin", "Pld");
        public static readonly CasterClass Ranger = new CasterClass("Ranger", "Rgr");
        public static readonly CasterClass Shadowcaster = new CasterClass("Shadowcaster", "Shc");
        public static readonly CasterClass Sorcerer = new CasterClass("Sorcerer", "Sor");
        public static readonly CasterClass Wizard = new CasterClass("Wizard", "Wiz");

        // Summary Property
        public string DisplayName { get => $"{this.Name} ({this.Abbreviation})"; }

        // Properties
        public string Name { get; }
        public string Abbreviation { get; }

        // Constructor(s)
        private CasterClass(string name, string abbreviation)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
        }

        // Action Methods
        public static List<CasterClass> GetAllInstances()
        {
            return typeof(CasterClass)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(CasterClass) && f.GetValue(null) is CasterClass)
                .Select(f => (CasterClass)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
