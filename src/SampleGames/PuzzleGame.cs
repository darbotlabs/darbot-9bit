using System;
using System.Collections.Generic;
using GameEngine;
using LevelEditor;
using PhysicsEngine;

namespace SampleGames
{
    public class PuzzleGame : GameEngine.GameObject
    {
        private int[,] puzzleGrid;
        private int gridSize;
        private int emptyCellX;
        private int emptyCellY;

        public PuzzleGame(int size)
        {
            gridSize = size;
            puzzleGrid = new int[gridSize, gridSize];
            InitializePuzzle();
        }

        private void InitializePuzzle()
        {
            int value = 1;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    puzzleGrid[i, j] = value;
                    value++;
                }
            }
            puzzleGrid[gridSize - 1, gridSize - 1] = 0;
            emptyCellX = gridSize - 1;
            emptyCellY = gridSize - 1;
        }

        public override void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Console.ReadKey().Key == ConsoleKey.UpArrow && emptyCellY < gridSize - 1)
            {
                SwapCells(emptyCellX, emptyCellY, emptyCellX, emptyCellY + 1);
                emptyCellY++;
            }
            else if (Console.ReadKey().Key == ConsoleKey.DownArrow && emptyCellY > 0)
            {
                SwapCells(emptyCellX, emptyCellY, emptyCellX, emptyCellY - 1);
                emptyCellY--;
            }
            else if (Console.ReadKey().Key == ConsoleKey.LeftArrow && emptyCellX < gridSize - 1)
            {
                SwapCells(emptyCellX, emptyCellY, emptyCellX + 1, emptyCellY);
                emptyCellX++;
            }
            else if (Console.ReadKey().Key == ConsoleKey.RightArrow && emptyCellX > 0)
            {
                SwapCells(emptyCellX, emptyCellY, emptyCellX - 1, emptyCellY);
                emptyCellX--;
            }
        }

        private void SwapCells(int x1, int y1, int x2, int y2)
        {
            int temp = puzzleGrid[x1, y1];
            puzzleGrid[x1, y1] = puzzleGrid[x2, y2];
            puzzleGrid[x2, y2] = temp;
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (puzzleGrid[i, j] == 0)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write($"{puzzleGrid[i, j],2} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
