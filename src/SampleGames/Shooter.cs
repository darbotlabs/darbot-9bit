using System;
using System.Collections.Generic;
using GameEngine;
using LevelEditor;
using PhysicsEngine;

namespace SampleGames
{
    public class Shooter : GameEngine.GameObject
    {
        private float playerX;
        private float playerY;
        private float playerVelocityX;
        private float playerVelocityY;
        private List<Bullet> bullets;

        public Shooter()
        {
            playerX = 0;
            playerY = 0;
            playerVelocityX = 0;
            playerVelocityY = 0;
            bullets = new List<Bullet>();
        }

        public override void Update()
        {
            HandleInput();
            UpdatePlayerPosition();
            UpdateBullets();
            CheckCollisions();
        }

        private void HandleInput()
        {
            // Handle player input for movement and shooting
            if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
            {
                playerVelocityX = -1;
            }
            else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
            {
                playerVelocityX = 1;
            }
            else if (Console.ReadKey().Key == ConsoleKey.UpArrow)
            {
                playerVelocityY = -1;
            }
            else if (Console.ReadKey().Key == ConsoleKey.DownArrow)
            {
                playerVelocityY = 1;
            }
            else if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                Shoot();
            }
        }

        private void UpdatePlayerPosition()
        {
            playerX += playerVelocityX;
            playerY += playerVelocityY;

            // Reset velocity
            playerVelocityX = 0;
            playerVelocityY = 0;
        }

        private void UpdateBullets()
        {
            foreach (var bullet in bullets)
            {
                bullet.Update();
            }
        }

        private void CheckCollisions()
        {
            // Check for collisions with bullets and enemies
            foreach (var bullet in bullets)
            {
                // Check for collisions with enemies
                // (Assume we have a list of enemies in the game)
                foreach (var enemy in GameEngine.Enemies)
                {
                    if (bullet.CollidesWith(enemy))
                    {
                        // Handle collision
                        Console.WriteLine("Bullet hit an enemy!");
                    }
                }
            }
        }

        private void Shoot()
        {
            // Create a new bullet and add it to the list
            var bullet = new Bullet(playerX, playerY);
            bullets.Add(bullet);
        }

        public void Render()
        {
            // Render the player character
            Console.SetCursorPosition((int)playerX, (int)playerY);
            Console.Write("P");

            // Render the bullets
            foreach (var bullet in bullets)
            {
                bullet.Render();
            }
        }
    }

    public class Bullet
    {
        private float x;
        private float y;
        private float velocityX;
        private float velocityY;

        public Bullet(float startX, float startY)
        {
            x = startX;
            y = startY;
            velocityX = 0;
            velocityY = -1;
        }

        public void Update()
        {
            x += velocityX;
            y += velocityY;
        }

        public void Render()
        {
            Console.SetCursorPosition((int)x, (int)y);
            Console.Write("o");
        }

        public bool CollidesWith(GameEngine.GameObject gameObject)
        {
            // Check for collision with a game object
            // (Assume we have a method to get the position of the game object)
            var gameObjectPosition = gameObject.GetPosition();
            return (int)x == (int)gameObjectPosition.X && (int)y == (int)gameObjectPosition.Y;
        }
    }
}
