using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roll20MacroMaker.Model
{
    public class SpellDescriptor
    {
        // Instance Members
        public static readonly SpellDescriptor Acid = new SpellDescriptor("Acid");
        public static readonly SpellDescriptor Air = new SpellDescriptor("Air");
        public static readonly SpellDescriptor Chaotic = new SpellDescriptor("Chaotic");
        public static readonly SpellDescriptor Cold = new SpellDescriptor("Cold");
        public static readonly SpellDescriptor Darkness = new SpellDescriptor("Darkness");
        public static readonly SpellDescriptor Death = new SpellDescriptor("Death");
        public static readonly SpellDescriptor Earth = new SpellDescriptor("Earth");
        public static readonly SpellDescriptor Electricity = new SpellDescriptor("Electricity");
        public static readonly SpellDescriptor Evil = new SpellDescriptor("Evil");
        public static readonly SpellDescriptor Fear = new SpellDescriptor("Fear");
        public static readonly SpellDescriptor Fire = new SpellDescriptor("Fire");
        public static readonly SpellDescriptor Force = new SpellDescriptor("Force");
        public static readonly SpellDescriptor Good = new SpellDescriptor("Good");
        public static readonly SpellDescriptor LanguageDependent = new SpellDescriptor("Language Dependent");
        public static readonly SpellDescriptor Lawful = new SpellDescriptor("Lawful");
        public static readonly SpellDescriptor Light = new SpellDescriptor("Light");
        public static readonly SpellDescriptor MindAffecting = new SpellDescriptor("Mind Affecting");
        public static readonly SpellDescriptor Sonic = new SpellDescriptor("Sonic");
        public static readonly SpellDescriptor Water = new SpellDescriptor("Water");

        // Properties
        public string Name { get; }

        // Constructor(s)
        private SpellDescriptor(string name)
        {
            this.Name = name;
        }

        // Action Methods
        // Override the implicit or explicit operator for casting to int
        //public static explicit operator int(SpellDescriptor descriptor)
        //{
        //    // Implement the logic to return the corresponding int value for the descriptor
        //    if (descriptor == Acid)
        //        return 0;
        //    if (descriptor == Air)
        //        return 1;
        //    if (descriptor == Chaotic)
        //        return 2;

        //    throw new InvalidCastException($"Cannot cast {descriptor.Name} to int.");
        //}

        //public class MyNumber
        //{
        //    private int value;

        //    public MyNumber(int value)
        //    {
        //        this.value = value;
        //    }

        //    // Define an implicit operator to convert MyNumber to int
        //    public static implicit operator int(MyNumber number)
        //    {
        //        return number.value;
        //    }
        //}

        //MyNumber myNumber = new MyNumber(42);
        //int intValue = myNumber;  // Implicit conversion

        //Console.WriteLine(intValue);  // Output: 42

        public static List<SpellDescriptor> GetAllInstances()
        {
            return typeof(SpellDescriptor)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(f => f.FieldType == typeof(SpellDescriptor))
                .Select(f => (SpellDescriptor)f.GetValue(null))
                .ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
