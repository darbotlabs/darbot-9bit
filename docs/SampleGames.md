# Sample Games

This document provides an overview of the sample games included in the project and instructions on how to customize and extend them.

## Overview

The 8-bit Video Game Engine includes the following sample games to showcase its capabilities and provide inspiration for developers:

1. **Platformer**: A classic platformer game with basic mechanics and controls.
2. **Puzzle Game**: A simple puzzle game with a grid-based layout.
3. **Shooter**: A basic shooter game with player movement and shooting mechanics.

## Customizing and Extending Sample Games

### Platformer

The Platformer game demonstrates basic platformer mechanics, such as player movement, jumping, and collision detection. To customize and extend the Platformer game, you can:

- Modify the player character's properties, such as speed and jump height.
- Add new levels and obstacles using the Level Editor.
- Implement additional game mechanics, such as power-ups and enemies.

### Puzzle Game

The Puzzle Game showcases a simple grid-based puzzle game. To customize and extend the Puzzle Game, you can:

- Change the grid size and initial puzzle configuration.
- Add new puzzle mechanics, such as timed challenges or special tiles.
- Implement a scoring system and track player progress.

### Shooter

The Shooter game demonstrates basic shooting mechanics, including player movement and bullet firing. To customize and extend the Shooter game, you can:

- Modify the player character's properties, such as speed and bullet firing rate.
- Add new enemy types and behaviors.
- Implement additional game mechanics, such as power-ups and different weapon types.

## Creating Games from LLMs using XML, YAML, JSON, etc.

In this section, we will guide you through the process of creating games from LLMs using XML, YAML, JSON, etc. Follow the steps below to get started:

1. Create a new game configuration file in XML, YAML, or JSON format. For example, create a file named `gameConfig.xml` with the following content:
   ```xml
   <Game>
       <Player>
           <PositionX>0</PositionX>
           <PositionY>0</PositionY>
       </Player>
   </Game>
   ```

   Alternatively, you can create a YAML file named `gameConfig.yaml` with the following content:
   ```yaml
   Game:
     Player:
       PositionX: 0
       PositionY: 0
   ```

   Or create a JSON file named `gameConfig.json` with the following content:
   ```json
   {
       "Game": {
           "Player": {
               "PositionX": 0,
               "PositionY": 0
           }
       }
   }
   ```

2. Load the game configuration file in your game:
   ```csharp
   using System;
   using GameEngine;

   namespace MySimpleGame
   {
       class Program
       {
           static void Main(string[] args)
           {
               GameEngine gameEngine = new GameEngine();
               gameEngine.LoadGameConfiguration("path/to/gameConfig.xml"); // Change the file extension to .yaml or .json if needed

               gameEngine.Initialize();
               gameEngine.Start();
           }
       }
   }
   ```

3. Define your game objects based on the loaded configuration. For example, create a `Player` class that inherits from `GameEngine.GameObject` and initializes its properties from the configuration:
   ```csharp
   using System;
   using GameEngine;

   namespace MySimpleGame
   {
       public class Player : GameEngine.GameObject
       {
           private float playerX;
           private float playerY;

           public Player(float x, float y)
           {
               playerX = x;
               playerY = y;
           }

           public override void Update()
           {
               HandleInput();
               UpdatePlayerPosition();
           }

           private void HandleInput()
           {
               if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
               {
                   playerX -= 1;
               }
               else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
               {
                   playerX += 1;
               }
               else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
               {
                   playerY -= 1;
               }
               else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
               {
                   playerY += 1;
               }
           }

           private void UpdatePlayerPosition()
           {
               // Update player position logic
           }

           public void Render()
           {
               Console.SetCursorPosition((int)playerX, (int)playerY);
               Console.Write("P");
           }
       }
   }
   ```

4. Add your game objects to the game engine based on the loaded configuration:
   ```csharp
   using System;
   using GameEngine;
   using MySimpleGame;

   namespace MySimpleGame
   {
       class Program
       {
           static void Main(string[] args)
           {
               GameEngine gameEngine = new GameEngine();
               gameEngine.LoadGameConfiguration("path/to/gameConfig.xml"); // Change the file extension to .yaml or .json if needed

               // Initialize game objects from the configuration
               Player player = new Player(0, 0); // Replace with actual values from the configuration
               gameEngine.AddGameObject(player);

               gameEngine.Initialize();
               gameEngine.Start();
           }
       }
   }
   ```

5. Run your game:
   ```sh
   dotnet run
   ```

Congratulations! You have successfully created a game from LLMs using XML, YAML, JSON, etc. Explore the engine's features and capabilities to create more complex and exciting games.

## Getting Started with Customization

To start customizing and extending the sample games, follow these steps:

1. Open the `src/SampleGames/` directory in your preferred IDE.
2. Locate the sample game you want to customize (e.g., `Platformer.cs`, `PuzzleGame.cs`, or `Shooter.cs`).
3. Make the desired changes to the game's code.
4. Test your changes by running the game using the 8-bit Video Game Engine.

For more detailed instructions and examples, refer to the documentation and tutorials provided in the `docs/` directory.

Happy coding!
