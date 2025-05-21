def check_collision(board, piece):
    for y in range(piece.size):
        for x in range(piece.size):
            if piece.shape[y][x] != 0:
                if (piece.x + x < 0 or piece.x + x >= board.width or
                    piece.y + y >= board.height or
                    board.grid[piece.y + y][piece.x + x] != 0):
                    return True
    return False

def clear_lines(board):
    lines_cleared = 0
    for y in range(board.height):
        if all(board.grid[y][x] != 0 for x in range(board.width)):
            del board.grid[y]
            board.grid.insert(0, [0 for _ in range(board.width)])
            lines_cleared += 1
    return lines_cleared
