using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Sources
{
    /// <summary>
    /// Name generator data source
    /// </summary>
    /// <seealso cref="DataGenerator.Sources.DataSourceMatchName" />
    public class NameSource : DataSourceMatchName
    {
        private static readonly string[] _names = { "Name" };
        private static readonly Type[] _types = { typeof(string) };

        private static readonly string[] _attributes = 
        {
            // Environ
            "Desert", "Tundra", "Mountain", "Space", "Field", "Urban",
            // Stealth and cunning
            "Hidden", "Covert", "Uncanny", "Scheming", "Decisive",
            // Volitility
            "Rowdy", "Dangerous", "Explosive", "Threatening", "Warring",
            // Needs correction
            "Bad", "Unnecessary", "Unknown", "Unexpected", "Waning",
            // Organic Gems and materials
            "Amber", "Bone", "Coral", "Ivory", "Jet", "Nacre", "Pearl", "Obsidian", "Glass",
            // Regular Gems
            "Agate", "Beryl", "Diamond", "Opal", "Ruby", "Onyx", "Sapphire", "Emerald", "Jade",
            // Colors
            "Red", "Orange", "Yellow", "Green", "Blue", "Violet",
        };

        private static readonly string[] _objects = 
        {
            // Large cats
            "Panther", "Wildcat", "Tiger", "Lion", "Cheetah", "Cougar", "Leopard",
            // Snakes
            "Viper", "Cottonmouth", "Python", "Boa", "Sidewinder", "Cobra",
            // Other predators
            "Grizzly", "Jackal", "Falcon",
            // Prey
            "Wildabeast", "Gazelle", "Zebra", "Elk", "Moose", "Deer", "Stag", "Pony",
            // HORSES!
            "Horse", "Stallion", "Foal", "Colt", "Mare", "Yearling", "Filly", "Gelding",
            // Occupations
            "Nomad", "Wizard", "Cleric", "Pilot",
            // Technology
            "Mainframe", "Device", "Motherboard", "Network", "Transistor", "Packet", "Robot", "Android", "Cyborg",
            // Sea life
            "Octopus", "Lobster", "Crab", "Barnacle", "Hammerhead", "Orca", "Piranha",
            // Weather
            "Storm", "Thunder", "Lightning", "Rain", "Hail", "Sun", "Drought", "Snow",
            // Other
            "Warning", "Presence", "Weapon"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="NameSource"/> class.
        /// </summary>
        public NameSource() : base(_types, _names)
        {
        }

        /// <summary>
        /// Get a value from the data source.
        /// </summary>
        /// <param name="generateContext">The generate context.</param>
        /// <returns>
        /// A new value from the data source.
        /// </returns>
        public override object NextValue(IGenerateContext generateContext)
        {
            var a = _attributes[RandomGenerator.Current.Next(0, _attributes.Length)];
            var o = _objects[RandomGenerator.Current.Next(0, _objects.Length)];

            return $"{a} {o}";
        }
    }
}
