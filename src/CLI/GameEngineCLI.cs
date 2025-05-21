using System;
using System.IO;
using GameEngine;
using LevelEditor;

namespace CLI
{
    public class GameEngineCLI
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            string command = args[0].ToLower();
            switch (command)
            {
                case "run":
                    RunGame(args);
                    break;
                case "build":
                    BuildGame(args);
                    break;
                case "test":
                    TestGame(args);
                    break;
                case "deploy":
                    DeployGame(args);
                    break;
                default:
                    ShowHelp();
                    break;
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("  run <gameConfigFile>    - Run the game with the specified configuration file");
            Console.WriteLine("  build                   - Build the game");
            Console.WriteLine("  test                    - Test the game");
            Console.WriteLine("  deploy                  - Deploy the game");
        }

        private static void RunGame(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Error: Missing game configuration file.");
                ShowHelp();
                return;
            }

            string gameConfigFile = args[1];
            GameEngine gameEngine = new GameEngine();
            gameEngine.LoadGameConfiguration(gameConfigFile);
            gameEngine.Initialize();
            gameEngine.Start();
        }

        private static void BuildGame(string[] args)
        {
            Console.WriteLine("Building the game...");
            // Implement build logic here
        }

        private static void TestGame(string[] args)
        {
            Console.WriteLine("Testing the game...");
            // Implement test logic here
        }

        private static void DeployGame(string[] args)
        {
            Console.WriteLine("Deploying the game...");
            // Implement deploy logic here
        }
    }
}
