using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG.Components
{
    internal class Player (Room startingRoom)
    {
        public Room CurrentRoom { get; set; } = startingRoom;
    }
}
