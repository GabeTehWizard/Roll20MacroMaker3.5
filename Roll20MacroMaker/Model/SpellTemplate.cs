using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll20MacroMaker.Model
{
    public class SpellTemplate
    {
        // Properties
        public string Name { get; set; }
        public SpellSchool School { get; set; }
        public List<SpellSubSchool> SubSchools { get; set; }
        public List<SpellDescriptor> SpellDescriptors { get; set; }
        public SpellLevel SpellLevel { get; set; }
        public CasterClass CasterClass { get; set; }
        public string Components { get; set; }
        public CastingTime CastingTime { get; set; }
        public SpellRange Range { get; set; }
        public string RangeFeet { get; set; }
        public string Aim { get; set; }
        public string Duration { get; set; }
        public SavingThrow SavingThrow { get; set; }
        public SavingThrowFailure SavingThrowFailure { get; set; }
        public SavingThrowFormula SavingThrowFormula { get; set; }
        public string SpellResist { get; set; }
        public string AttackRoll { get; set; }
        public string Damage { get; set; }
        public DamageType DamageType { get; set; }
        public string Description { get; set; }

        //// Constructor
        //public SpellTemplate(string name, SpellSchool school, List<SpellSubSchool> subSchools, List<SpellDescriptor> spellDescriptors, SpellLevel spellLevel, CasterClass casterClass, string components, CastingTime castingTime, SpellRange range, string aim, string duration, SavingThrow savingThrow, SavingThrow savingThrowFailure, string spellResist, string attackRoll, string damage, DamageType damageType, string description)
        //{
        //    Name = name;
        //    School = school;
        //    SubSchools = subSchools;
        //    SpellDescriptors = spellDescriptors;
        //    SpellLevel = spellLevel;
        //    CasterClass = casterClass;
        //    Components = components;
        //    CastingTime = castingTime;
        //    Range = range;
        //    Aim = aim;
        //    Duration = duration;
        //    SavingThrow = savingThrow;
        //    SavingThrowFailure = savingThrowFailure;
        //    SpellResist = spellResist;
        //    AttackRoll = attackRoll;
        //    Damage = damage;
        //    DamageType = damageType;
        //    Description = description;
        //}
    }
}
