using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roll20MacroMaker.Model
{
    public class SpellSchool
    {
        // Instance Members
        public static readonly SpellSchool Abjuration = new SpellSchool("Abjuration", new List<SpellSubSchool>());
        public static readonly SpellSchool Conjuration = new SpellSchool("Conjuration", new List<SpellSubSchool>() { SpellSubSchool.Calling, SpellSubSchool.Creation, SpellSubSchool.Healing, SpellSubSchool.Summoning, SpellSubSchool.Teleportation });
        public static readonly SpellSchool Divination = new SpellSchool("Divination", new List<SpellSubSchool>() { SpellSubSchool.Scrying });
        public static readonly SpellSchool Enchantment = new SpellSchool("Enchantment", new List<SpellSubSchool>() { SpellSubSchool.Charm, SpellSubSchool.Compulsion });
        public static readonly SpellSchool Evocation = new SpellSchool("Evocation", new List<SpellSubSchool>());
        public static readonly SpellSchool Illusion = new SpellSchool("Illusion", new List<SpellSubSchool>() { SpellSubSchool.Figment, SpellSubSchool.Glamer, SpellSubSchool.Pattern, SpellSubSchool.Phantasm, SpellSubSchool.Shadow });
        public static readonly SpellSchool Necromancy = new SpellSchool("Necromancy", new List<SpellSubSchool>());
        public static readonly SpellSchool Transmutation = new SpellSchool("Transmutation", new List<SpellSubSchool>());

        // Properties
        public string Name { get; }
        public IReadOnlyList<SpellSubSchool> SubSchools { get; }

        // Constructor
        private SpellSchool(string name, List<SpellSubSchool> subSchools)
        {
            this.Name = name;
            this.SubSchools = subSchools.AsReadOnly();
        }

        // Action Methods
        public static List<SpellSchool> GetAllInstances()
        {
            return typeof(SpellSchool)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SpellSchool) && f.GetValue(null) is SpellSchool)
                .Select(f => (SpellSchool)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class SpellSubSchool
    {
        // Instance Members
        public static readonly SpellSubSchool Calling = new SpellSubSchool("Calling");
        public static readonly SpellSubSchool Charm = new SpellSubSchool("Charm");
        public static readonly SpellSubSchool Compulsion = new SpellSubSchool("Compulsion");
        public static readonly SpellSubSchool Creation = new SpellSubSchool("Creation");
        public static readonly SpellSubSchool Figment = new SpellSubSchool("Figment");
        public static readonly SpellSubSchool Glamer = new SpellSubSchool("Glamer");
        public static readonly SpellSubSchool Healing = new SpellSubSchool("Healing");
        public static readonly SpellSubSchool Pattern = new SpellSubSchool("Pattern");
        public static readonly SpellSubSchool Phantasm = new SpellSubSchool("Phantasm");
        public static readonly SpellSubSchool Scrying = new SpellSubSchool("Scrying");
        public static readonly SpellSubSchool Shadow = new SpellSubSchool("Shadow");
        public static readonly SpellSubSchool Summoning = new SpellSubSchool("Summoning");
        public static readonly SpellSubSchool Teleportation = new SpellSubSchool("Teleportation");

        // Properties
        public string Name { get; }

        // Constructors
        private SpellSubSchool(string name)
        {
            this.Name = name;
        }

        // Action Methods
        public static List<SpellSubSchool> GetAllInstances()
        {
            return typeof(SpellSubSchool)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SpellSubSchool) && f.GetValue(null) is SpellSubSchool)
                .Select(f => (SpellSubSchool)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
