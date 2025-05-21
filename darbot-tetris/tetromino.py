import random

class Tetromino:
    SHAPES = [
        [[1, 1, 1, 1]],
        [[1, 1], [1, 1]],
        [[0, 1, 1], [1, 1, 0]],
        [[1, 1, 0], [0, 1, 1]],
        [[1, 1, 1], [0, 1, 0]],
        [[1, 1, 1], [1, 0, 0]],
        [[1, 1, 1], [0, 0, 1]]
    ]

    COLORS = [
        (0, 255, 255),
        (255, 255, 0),
        (0, 255, 0),
        (255, 0, 0),
        (0, 0, 255),
        (255, 165, 0),
        (128, 0, 128)
    ]

    def __init__(self):
        self.shape = random.choice(self.SHAPES)
        self.color = random.choice(self.COLORS)
        self.size = len(self.shape)
        self.x = 0
        self.y = 0

    def rotate(self):
        self.shape = [list(row) for row in zip(*self.shape[::-1])]
