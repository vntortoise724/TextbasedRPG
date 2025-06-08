using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRPG.Components
{
    internal sealed class Story
    {
        private Story() { }

        private static Story? _instance;
        private static readonly object _lock = new();

        public static Story Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new Story();
                    }
                }
                return _instance;
            }
        }

        public static void InitializeGame()
        {
            // Initialize game components here, such as rooms, player, etc.
            // This is where you would set up the initial state of the game.
            // Define rooms
            Room forest = new("Forest", "A dense forest with towering trees and a faint path leading deeper into the woods.");
            Room cave = new("Cave", "A dark cave with damp walls and the sound of dripping water echoing through the chambers.");

            // Define exits for the rooms
            forest.Exits["north"] = cave;
            cave.Exits["south"] = forest;

            // Add your player's current location;
            Player player = new(forest);

            StartGameLoop(player);
        }

        private static void StartGameLoop(Player player)
        {
            // Main game loop where the player can interact with the game world.
            // This is where you would handle player input, update the game state, and render the game world.
            while (true)
            {
                Console.WriteLine($"You are in {player.CurrentRoom.Name}. {player.CurrentRoom.Description}");
                Console.WriteLine("Available exits: " + string.Join(", ", player.CurrentRoom.Exits.Keys));

                string input = Console.ReadLine().Trim().ToLower();

                if (input == "exit")
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    Thread.Sleep(2000);
                    break;
                }

                ParseCommand(input, player);
            }
        }

        private static void ParseCommand(string input, Player player)
        {
            // Parse the player's command and update the game state accordingly.
            // This is where you would handle movement, actions, and other game mechanics.

            string[] word = input.Split(' ');
            string command = word[0];

            switch (command)
            {
                case "go":
                    if (word.Length > 1)
                    {
                        string direction = word[1];
                        if (player.CurrentRoom.Exits.ContainsKey(direction))
                        {
                            player.CurrentRoom = player.CurrentRoom.Exits[direction];
                            Console.WriteLine($"You move {direction} to {player.CurrentRoom.Name}.");
                        }
                        else
                        {
                            Console.WriteLine("You can't go that way.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You seem stuck in thoughts...");
                    }
                    break;

                case "look":
                    Console.WriteLine($"What you see: {player.CurrentRoom.Description}");
                    break;

                default:
                    Console.WriteLine("Doesn't ring a bell at all...");
                    break;
            }
        }
    }
}
