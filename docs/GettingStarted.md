# Getting Started with the 8-bit Video Game Engine

Welcome to the 8-bit Video Game Engine! This guide will help you get started with setting up the development environment and creating your first simple game.

## Setting Up the Development Environment

1. Install .NET 10 SDK from the official [Microsoft .NET website](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Clone the repository:
   ```sh
   git clone https://github.com/githubnext/workspace-blank.git
   ```
3. Navigate to the project directory:
   ```sh
   cd workspace-blank
   ```
4. Open the project in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
5. Restore the project dependencies:
   ```sh
   dotnet restore
   ```

## Creating a Simple Game

In this tutorial, we will create a simple game using the 8-bit Video Game Engine. Follow the steps below to get started:

1. Create a new class for your game:
   ```csharp
   using System;
   using GameEngine;

   namespace MySimpleGame
   {
       public class SimpleGame : GameEngine.GameObject
       {
           private float playerX;
           private float playerY;

           public SimpleGame()
           {
               playerX = 0;
               playerY = 0;
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

2. Add your game object to the game engine:
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
               SimpleGame simpleGame = new SimpleGame();

               gameEngine.AddGameObject(simpleGame);
               gameEngine.Initialize();
               gameEngine.Start();
           }
       }
   }
   ```

3. Run your game:
   ```sh
   dotnet run
   ```

Congratulations! You have successfully created a simple game using the 8-bit Video Game Engine. Explore the engine's features and capabilities to create more complex and exciting games.

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
