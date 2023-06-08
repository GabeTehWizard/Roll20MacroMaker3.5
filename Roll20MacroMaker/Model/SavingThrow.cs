using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Roll20MacroMaker.Model
{
    public class SavingThrowFormula
    {
        // Instance Members
        public static readonly SavingThrowFormula Spell = new SavingThrowFormula("Spell", "Saving Throw DC = 10 + Spell Level + Casting Modifier");
        public static readonly SavingThrowFormula SpellLike = new SavingThrowFormula("Spell-Like Ability", "Saving Throw DC = 10 + Spell-Like Ability Level + Casting Modifier");
        public static readonly SavingThrowFormula Supernatural = new SavingThrowFormula("Supernatural Ability", "Saving Throw DC = 10 + Half the Character's Hit Dice + Casting Modifier");

        // Properties
        public string Name { get; }
        public string Formula { get; }
        
        // Constructor(s)
        private SavingThrowFormula(string name, string formula) 
        {
            this.Name = name;
            this.Formula = formula;
        }

        // Action Methods
        public static List<SavingThrowFormula> GetAllInstances()
        {
            return typeof(SavingThrowFormula)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SavingThrowFormula) && f.GetValue(null) is SavingThrowFormula)
                .Select(f => (SavingThrowFormula)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class SavingThrow
    {
        // Instance Members
        public static readonly SavingThrow Fortitude = new SavingThrow("Fortitude");
        public static readonly SavingThrow Reflex = new SavingThrow("Reflex");
        public static readonly SavingThrow Will = new SavingThrow("Will");

        // Properties
        public string Name { get; }

        // Constructor(s)
        private SavingThrow(string name)
        {
            this.Name = name;
        }

        // Action Methods
        public static List<SavingThrow> GetAllInstances()
        {
            return typeof(SavingThrow)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SavingThrow) && f.GetValue(null) is SavingThrow)
                .Select(f => (SavingThrow)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class SavingThrowFailure
    {
        // Instance Members 
        public static readonly SavingThrowFailure Disbelief = new SavingThrowFailure("Disbelief");
        public static readonly SavingThrowFailure Half = new SavingThrowFailure("Half");
        public static readonly SavingThrowFailure Negates = new SavingThrowFailure("Negates");
        public static readonly SavingThrowFailure None = new SavingThrowFailure("None");
        public static readonly SavingThrowFailure Partial = new SavingThrowFailure("Partial");

        // Properties
        public string Name { get; }

        // Constructor(s)
        private SavingThrowFailure(string name)
        {
            this.Name = name;
        }

        // Action Methods
        public static List<SavingThrowFailure> GetAllInstances()
        {
            return typeof(SavingThrowFailure)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SavingThrowFailure) && f.GetValue(null) is SavingThrowFailure)
                .Select(f => (SavingThrowFailure)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
