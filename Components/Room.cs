using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG.Components
{
    internal class Room(string name, string description)
    {
        public string Name { get; } = name;
        public string Description { get; } = description;
        public Dictionary<string, Room> Exits { get; } = [];
    }
}
