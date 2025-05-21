using System;
using System.Collections.Generic;
using GameEngine;
using LevelEditor;
using PhysicsEngine;

namespace SampleGames
{
    public class Platformer : GameEngine.GameObject
    {
        private float playerX;
        private float playerY;
        private float playerVelocityX;
        private float playerVelocityY;
        private bool isJumping;

        public Platformer()
        {
            playerX = 0;
            playerY = 0;
            playerVelocityX = 0;
            playerVelocityY = 0;
            isJumping = false;
        }

        public override void Update()
        {
            HandleInput();
            UpdatePlayerPosition();
            CheckCollisions();
        }

        private void HandleInput()
        {
            // Handle player input for movement and jumping
            if (Console.ReadKey().Key == ConsoleKey.LeftArrow)
            {
                playerVelocityX = -1;
            }
            else if (Console.ReadKey().Key == ConsoleKey.RightArrow)
            {
                playerVelocityX = 1;
            }
            else if (Console.ReadKey().Key == ConsoleKey.Spacebar && !isJumping)
            {
                playerVelocityY = -5;
                isJumping = true;
            }
        }

        private void UpdatePlayerPosition()
        {
            playerX += playerVelocityX;
            playerY += playerVelocityY;

            // Apply gravity
            playerVelocityY += 0.1f;

            // Reset horizontal velocity
            playerVelocityX = 0;
        }

        private void CheckCollisions()
        {
            // Check for collisions with the ground
            if (playerY >= 0)
            {
                playerY = 0;
                playerVelocityY = 0;
                isJumping = false;
            }
        }

        public void Render()
        {
            // Render the player character
            Console.SetCursorPosition((int)playerX, (int)playerY);
            Console.Write("P");
        }
    }
}
