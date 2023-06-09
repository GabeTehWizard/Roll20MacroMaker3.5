using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.UI.Xaml;
using Roll20MacroMaker.Model;
using System.Reflection;
using Roll20MacroMaker.Utilities;

namespace Roll20MacroMaker.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<SpellSchool> SpellSchools { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            SpellSchools = SpellSchool.GetAllInstances();
            cboSpellSchool.ItemsSource = SpellSchools;
            cboSpellSchool.SelectedIndex = 0;
            lvSpellDescriptor.ItemsSource = SpellDescriptor.GetAllInstances();
            cboSpellLevel.ItemsSource = SpellLevel.GetAllInstances();
            cboSpellLevel.SelectedIndex = 0;
            cboCasterClass.ItemsSource = CasterClass.GetAllInstances();
            cboCasterClass.SelectedIndex = 0;
            cboCastingTime.ItemsSource = CastingTime.GetAllInstances();
            cboCastingTime.SelectedIndex = 0;
            cboSpellRange.ItemsSource = SpellRange.GetAllInstances(); 
            cboSpellRange.SelectedIndex = 0;
            cboSaveType.ItemsSource = SavingThrow.GetAllInstances();
            cboSavingThrowFailure.ItemsSource = SavingThrowFailure.GetAllInstances();
            cboDamageType.ItemsSource = DamageType.GetAllInstances();

            radDCSpell.Tag = SavingThrowFormula.Spell;
            radDCSupernatural.Tag = SavingThrowFormula.Supernatural;
        }

        private void RadSpellDescriptorChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (radioButton == radSepllDescriptorHide)
                {
                    lvSpellDescriptor.Height = 0;
                    scrollDescriptor.Height = 0;
                }
                else
                {
                    lvSpellDescriptor.Height = double.NaN;
                    scrollDescriptor.Height = double.NaN;
                }
            }
        }

        private void RadSubSchoolChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (radioButton == radSubSchoolHide)
                {
                    lvSubSchool.Height = 0;
                    lblEmptySubSchool.Height = 0;
                }
                else
                {
                    lvSubSchool.Height = double.NaN;
                    if (cboSpellSchool.SelectedItem is SpellSchool selectedSchool)
                    {
                        CheckSubSchool(selectedSchool);
                    }
                }
            }
        }

        private void CboSpellRangeChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboSpellRange.SelectedIndex != 7 || cboSpellRange.SelectedIndex != 6)
            {
                grdRangeColumn2.Width = new GridLength(0, GridUnitType.Star);
                grdRangeColumn3.Width = new GridLength(2, GridUnitType.Star);
            }
            else
            {
                grdRangeColumn2.Width = new GridLength(0.5, GridUnitType.Star);
                grdRangeColumn3.Width = new GridLength(1.5, GridUnitType.Star);
            }
        }

        private void CboSpellSchoolChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cboSpellSchool.SelectedItem is SpellSchool selectedSchool)
            {
                lvSubSchool.ItemsSource = selectedSchool.SubSchools;
                CheckSubSchool(selectedSchool);
            }
        }

        private void CheckSubSchool(SpellSchool spellSchool)
        {
            if (spellSchool.SubSchools.Count > 0 || radSubSchoolHide.IsChecked == true) lblEmptySubSchool.Height = 0;
            else lblEmptySubSchool.Height = 32;
        }


        private void MacroCreateClick(object sender, RoutedEventArgs e)
        {
            SpellTemplate spell = new SpellTemplate();

            spell.Name = txtSpellName.Text;
            if (cboSpellSchool.SelectedItem != null) spell.School = (SpellSchool)cboSpellSchool.SelectedItem;
            if (lvSubSchool.SelectedItems.Count > 0) spell.SubSchools = lvSubSchool.SelectedItems.Cast<SpellSubSchool>().ToList();
            if (lvSpellDescriptor.SelectedItems.Count > 0) spell.SpellDescriptors = lvSpellDescriptor.SelectedItems.Cast<SpellDescriptor>().ToList();
            if (cboSpellLevel.SelectedItem != null) spell.SpellLevel = (SpellLevel)cboSpellLevel.SelectedItem;
            if (cboCasterClass.SelectedItem != null) spell.CasterClass = (CasterClass)cboCasterClass.SelectedItem;
            spell.Components = txtComponents.Text;
            if (cboCastingTime.SelectedItem != null) spell.CastingTime = (CastingTime)cboCastingTime.SelectedItem;
            if (cboSpellRange.SelectedItem != null) spell.Range = (SpellRange)cboSpellRange.SelectedItem;
            spell.RangeFeet = txtRangeFeet.Text;
            spell.Aim = txtAim.Text;
            spell.Duration = txtDuration.Text;
            if (cboSaveType.SelectedItem != null) spell.SavingThrow = (SavingThrow)cboSaveType.SelectedItem;
            if (cboSavingThrowFailure.SelectedItem != null) spell.SavingThrowFailure = (SavingThrowFailure)cboSavingThrowFailure.SelectedItem;
            spell.SavingThrowFormula = radDCSpell.IsChecked == true ? (SavingThrowFormula)radDCSpell.Tag : (SavingThrowFormula)radDCSupernatural.Tag;
            if (cboSpellResistance.SelectedItem != null)
            {
                ComboBoxItem spellResistanceItem = (ComboBoxItem)cboSpellResistance.SelectedItem;
                if (!string.IsNullOrEmpty(spellResistanceItem.Tag?.ToString())) spell.SpellResist = spellResistanceItem.Tag.ToString();
            }
            if (cboAttackRoll.SelectedItem != null)
            {
                ComboBoxItem attackRollItem = (ComboBoxItem)cboAttackRoll.SelectedItem;
                if (!string.IsNullOrEmpty(attackRollItem.Tag?.ToString())) spell.AttackRoll = attackRollItem.Tag.ToString();
            }
            spell.Damage = txtDamage.Text;
            if (cboDamageType.SelectedItem != null) spell.DamageType = (DamageType)cboDamageType.SelectedItem;
            spell.Description = txtDescription.Text;

            txtMacroOutput.Text = SpellMacro.CreateMacro(spell);
        }
    }
}
