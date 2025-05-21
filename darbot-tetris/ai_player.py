import random
import requests

class AIPlayer:
    def __init__(self, board):
        self.board = board

    def evaluate_board(self, board):
        holes = self.count_holes(board)
        max_height = self.get_max_height(board)
        return holes + max_height

    def count_holes(self, board):
        holes = 0
        for x in range(board.width):
            block_found = False
            for y in range(board.height):
                if board.grid[y][x] != 0:
                    block_found = True
                elif block_found:
                    holes += 1
        return holes

    def get_max_height(self, board):
        max_height = 0
        for x in range(board.width):
            column_height = 0
            for y in range(board.height):
                if board.grid[y][x] != 0:
                    column_height = board.height - y
                    break
            if column_height > max_height:
                max_height = column_height
        return max_height

    def get_best_move(self, piece):
        best_score = float('inf')
        best_move = None
        for rotation in range(4):
            for x in range(self.board.width - piece.size + 1):
                piece.x = x
                piece.y = 0
                while not self.board.check_collision(piece):
                    piece.y += 1
                piece.y -= 1
                self.board.place_piece(piece)
                score = self.evaluate_board(self.board)
                self.board.remove_piece(piece)
                if score < best_score:
                    best_score = score
                    best_move = (x, rotation)
            piece.rotate()
        return best_move

    def make_move(self, piece):
        best_move = self.get_best_move(piece)
        if best_move:
            x, rotation = best_move
            for _ in range(rotation):
                piece.rotate()
            piece.x = x
            while not self.board.check_collision(piece):
                piece.y += 1
            piece.y -= 1
            self.board.place_piece(piece)

    def get_move_from_self_hosted_model(self, board_state):
        url = "http://localhost:5000/get_move"
        response = requests.post(url, json={"board_state": board_state})
        if response.status_code == 200:
            return response.json()["move"]
        else:
            return None

    def make_move_with_self_hosted_model(self, piece):
        board_state = self.board.grid
        move = self.get_move_from_self_hosted_model(board_state)
        if move:
            x, rotation = move
            for _ in range(rotation):
                piece.rotate()
            piece.x = x
            while not self.board.check_collision(piece):
                piece.y += 1
            piece.y -= 1
            self.board.place_piece(piece)
