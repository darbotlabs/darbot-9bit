import random
import time
from game_board import GameBoard
from ai_player import AIPlayer
from tetromino import Tetromino
from utils import check_collision, clear_lines

GRID_WIDTH = 10
GRID_HEIGHT = 20

def display_board(board):
    for row in board.grid:
        line = ""
        for cell in row:
            line += "X " if cell != 0 else "o "
        print(line)
    print("-" * (GRID_WIDTH * 2))

def text_based_tetris():
    board1 = GameBoard(GRID_WIDTH, GRID_HEIGHT)
    board2 = GameBoard(GRID_WIDTH, GRID_HEIGHT)
    ai1 = AIPlayer(board1)
    ai2 = AIPlayer(board2)
    current_piece1 = Tetromino()
    current_piece2 = Tetromino()
    next_piece1 = Tetromino()
    next_piece2 = Tetromino()
    game_over = False
    while not game_over:
        print("\nBoard 1:")
        display_board(board1)
        print("\nBoard 2:")
        display_board(board2)

        if not check_collision(board1, current_piece1):
            current_piece1.y += 1
        else:
            board1.place_piece(current_piece1)
            clear_lines(board1)
            current_piece1 = next_piece1
            next_piece1 = Tetromino()

        if not check_collision(board2, current_piece2):
            current_piece2.y += 1
        else:
            board2.place_piece(current_piece2)
            clear_lines(board2)
            current_piece2 = next_piece2
            next_piece2 = Tetromino()

        if board1.is_game_over() or board2.is_game_over():
            game_over = True
        
        time.sleep(0.5)

    print("\nGame Over!")
    if board1.is_game_over():
        print("Board 1 lost")
    if board2.is_game_over():
        print("Board 2 lost")

text_based_tetris()
