import pygame
import random
from game_board import GameBoard
from ai_player import AIPlayer
from tetromino import Tetromino
from utils import check_collision, clear_lines

# Constants
SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600
GRID_SIZE = 30
GRID_WIDTH = 10
GRID_HEIGHT = 20
FPS = 60

# Initialize Pygame
pygame.init()
screen = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))
pygame.display.set_caption("Side by Side Tetris AI Competition")
clock = pygame.time.Clock()

# Initialize game state
board1 = GameBoard(GRID_WIDTH, GRID_HEIGHT)
board2 = GameBoard(GRID_WIDTH, GRID_HEIGHT)
ai1 = AIPlayer(board1)
ai2 = AIPlayer(board2)
current_piece1 = Tetromino()
current_piece2 = Tetromino()
next_piece1 = Tetromino()
next_piece2 = Tetromino()
game_over = False

def draw_board(board, offset_x, offset_y):
    for y in range(board.height):
        for x in range(board.width):
            if board.grid[y][x] != 0:
                pygame.draw.rect(screen, board.grid[y][x], (offset_x + x * GRID_SIZE, offset_y + y * GRID_SIZE, GRID_SIZE, GRID_SIZE))

def draw_piece(piece, offset_x, offset_y):
    for y in range(piece.size):
        for x in range(piece.size):
            if piece.shape[y][x] != 0:
                pygame.draw.rect(screen, piece.color, (offset_x + (piece.x + x) * GRID_SIZE, offset_y + (piece.y + y) * GRID_SIZE, GRID_SIZE, GRID_SIZE))

def handle_input():
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            return True
    return False

def update_game_state():
    global current_piece1, current_piece2, next_piece1, next_piece2, game_over

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

def render():
    screen.fill((0, 0, 0))
    draw_board(board1, 50, 50)
    draw_board(board2, 450, 50)
    draw_piece(current_piece1, 50, 50)
    draw_piece(current_piece2, 450, 50)
    pygame.display.flip()

# Main game loop
while not game_over:
    if handle_input():
        break
    update_game_state()
    render()
    clock.tick(FPS)

pygame.quit()
