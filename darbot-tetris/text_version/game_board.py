import random

class GameBoard:
    def __init__(self, width, height):
        self.width = width
        self.height = height
        self.grid = [[0 for _ in range(width)] for _ in range(height)]
        self.garbage_queue = 0

    def place_piece(self, piece):
        for y in range(piece.size):
            for x in range(piece.size):
                if piece.shape[y][x] != 0:
                    self.grid[piece.y + y][piece.x + x] = piece.color

    def remove_piece(self, piece):
        for y in range(piece.size):
            for x in range(piece.size):
                if piece.shape[y][x] != 0:
                    self.grid[piece.y + y][piece.x + x] = 0

    def check_collision(self, piece):
        for y in range(piece.size):
            for x in range(piece.size):
                if piece.shape[y][x] != 0:
                    if (piece.x + x < 0 or piece.x + x >= self.width or
                        piece.y + y >= self.height or
                        self.grid[piece.y + y][piece.x + x] != 0):
                        return True
        return False

    def clear_lines(self):
        lines_cleared = 0
        for y in range(self.height):
            if all(self.grid[y][x] != 0 for x in range(self.width)):
                del self.grid[y]
                self.grid.insert(0, [0 for _ in range(self.width)])
                lines_cleared += 1
        return lines_cleared

    def add_garbage(self, lines):
        for _ in range(lines):
            hole1 = random.randint(0, self.width - 1)
            hole2 = random.randint(0, self.width - 1)
            while hole2 == hole1:
                hole2 = random.randint(0, self.width - 1)
            garbage_line = [1 for _ in range(self.width)]
            garbage_line[hole1] = 0
            garbage_line[hole2] = 0
            self.grid.append(garbage_line)
            self.grid.pop(0)

    def is_game_over(self):
        return any(self.grid[0][x] != 0 for x in range(self.width))
