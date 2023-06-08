using Roll20MacroMaker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Roll20MacroMaker.Utilities
{
    public class SpellMacro
    {
        public static string CreateMacro(SpellTemplate spellTemplate)
        {
            string macroStyle = "&{template:DnD35StdRoll} ";
            string macroSpellFlag = "{{spellflag=true}} ";
            string macroName = FormatName(spellTemplate.Name);
            string macroSchool = FormatSchool(spellTemplate.School, spellTemplate.SubSchools, spellTemplate.SpellDescriptors);
            string macroSpellLevel = FormatSpellLevel(spellTemplate.SpellLevel, spellTemplate.CasterClass);
            string macroComponents = FormatSpellComponents(spellTemplate.Components);
            string macroCastingTime = FormatCastingTime(spellTemplate.CastingTime.Name);
            string macroRange = FormatSpellRange(spellTemplate.Range, spellTemplate.RangeFeet);
            string macroAim = FormatSpellAim(spellTemplate.Aim);
            string macroDuration = FormatSpellDuration(spellTemplate.Duration);
            string macroSavingThrow = FormatSpellSavingThrow(spellTemplate.SavingThrow, spellTemplate.SavingThrowFailure);
            string macroSpellDC = FormatSpellDC(spellTemplate.SavingThrow, spellTemplate.SavingThrowFailure, spellTemplate.SavingThrowFormula, spellTemplate.SpellLevel.Level);
            string macroSpellResistance = FormatSpellResistance(spellTemplate.SpellResist);
            string macroAttackRoll = FormatSpellAttackRoll(spellTemplate.AttackRoll);
            string macroDamage = FormatSpellDamage(spellTemplate.Damage, spellTemplate.DamageType);
            string macroDescription = FormatSpellDescription(spellTemplate.Description);

            return macroStyle + macroSpellFlag + macroName + macroSchool + macroSpellLevel + macroComponents + macroCastingTime + macroRange
                   + macroAim + macroDuration + macroSavingThrow + macroSpellDC + macroSpellResistance + macroAttackRoll + macroDamage + macroDescription;
        }

        public static string CalculateRange(SpellRange spellRange, string staticRange)
        {
            return spellRange == SpellRange.Personal ? string.Empty 
                : spellRange == SpellRange.Touch ? string.Empty
                : spellRange == SpellRange.Close ? "[[25 + 5 * floor(@{scLevel} / 2)]] "
                : spellRange == SpellRange.Medium ? "[[100 + 10 * @{scLevel}]] "
                : spellRange == SpellRange.Long ? "[[400 + 40 * @{scLevel}]] "
                : spellRange == SpellRange.Unlimited ? string.Empty
                : spellRange == SpellRange.Static ? staticRange ?? string.Empty
                : spellRange == SpellRange.Special ? staticRange ?? string.Empty
                : string.Empty;
        }

        public static string FormatName(string name)
        {
            return "{{name= " + name + " }} ";
        }

        public static string FormatSchool(SpellSchool school, List<SpellSubSchool> subSchool, List<SpellDescriptor> spellDescriptor)
        {
            string schoolName = school?.Name ?? string.Empty;
            return schoolName == string.Empty ? "" : "{{School:= " + schoolName + FormatSubSchoolsDescriptors(subSchool, spellDescriptor) + "}} ";
        }

        public static string FormatSubSchoolsDescriptors(List<SpellSubSchool> subSchools, List<SpellDescriptor> spellDescriptors)
        {
            var formattedNames = new List<string>();

            if (subSchools != null && subSchools.Count > 0)
            {
                var subSchoolNames = subSchools.Select(ss => ss.Name);
                formattedNames.AddRange(subSchoolNames);
            }

            if (spellDescriptors != null && spellDescriptors.Count > 0)
            {
                var descriptorNames = spellDescriptors.Select(sd => sd.Name);
                formattedNames.AddRange(descriptorNames);
            }

            if (formattedNames.Count == 0) return string.Empty;

            return $" ({string.Join(", ", formattedNames)})";
        }

        public static string FormatSpellLevel(SpellLevel spellLevel, CasterClass casterClass)
        {
            if (spellLevel == null) return string.Empty;
            return "{{Level: = " + spellLevel.Name + " " + casterClass.Abbreviation + " }} ";
        }

        public static string FormatSpellComponents(string components)
        {
            if (string.IsNullOrEmpty(components)) return string.Empty;
            return "{{Comp'nts:= " + components + " }} ";
        }

        public static string FormatCastingTime(string castingTime)
        {
            if (string.IsNullOrEmpty(castingTime)) return string.Empty;
            return "{{Casting Time:= " + castingTime + " }} ";
        }

        public static string FormatSpellAim(string aim)
        {
            if (string.IsNullOrEmpty(aim)) return string.Empty;
            return "{{Aim:= " + aim + " }} ";
        }

        public static string FormatSpellDuration(string duration)
        {
            if (string.IsNullOrEmpty(duration)) return string.Empty;
            return "{{Duration:= " + duration + " }} ";
        }

        public static string FormatSpellDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return string.Empty;
            }

            string formattedDescription = "{{Description:= " + description + " }}";
            return formattedDescription;
        }

        public static string FormatSpellDamage(string damage, DamageType damageType)
        {
            if (string.IsNullOrEmpty(damage) || damageType == null) return string.Empty;
            return "{{Damage:= [[" + damage + "]] " + damageType.Name + " }} ";
        }

        public static string FormatSpellAttackRoll(string attackRoll)
        {
            if (string.IsNullOrEmpty(attackRoll)) return string.Empty;
            return "{{Attack:= @{" + attackRoll + "AttackRoll} }} ";
        }

        public static string FormatSpellResistance(string spellResist)
        {
            if (string.IsNullOrEmpty(spellResist)) return string.Empty;
            return "{{Spell Resistance:= " + spellResist + " }} ";
        }

        public static string FormatSpellRange(SpellRange range, string rangeFeet)
        {
            if (range == null) return string.Empty;
            return "{{Range:= " + range + " " + CalculateRange(range, rangeFeet) + " }} ";
        }

        public static string FormatSpellSavingThrow(SavingThrow savingThrow, SavingThrowFailure savingThrowFailure)
        {
            if (savingThrow == null || savingThrowFailure == null) return string.Empty;
            return "{{Saving Throw:= " + savingThrow.Name + " }} {{Saving Throw Failure:= " + savingThrowFailure.Name + " }} ";
        }

        public static string FormatSpellDC(SavingThrow savingThrow, SavingThrowFailure savingThrowFailure, SavingThrowFormula savingThrowFormula, int spellLevel)
        {
            if (savingThrow == null || savingThrowFailure == null || savingThrowFormula == null) return string.Empty;
            return "{{Spell DC:= " + "[[@{" + savingThrowFormula + "} + " + spellLevel + "]] }} ";
        }

        public static string GetDCVariable(SavingThrowFormula savingThrowFormula)
        {
            return savingThrowFormula == SavingThrowFormula.Spell ? "spellDC" 
                : savingThrowFormula == SavingThrowFormula.SpellLike ? "spellDC" 
                : savingThrowFormula == SavingThrowFormula.Supernatural ? "supernaturalDC" 
                : "Special";
        }
    }
}
