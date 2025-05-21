# Side by Side Tetris AI Competition

This project is a side by side Tetris simulation in Python using Pygame where two AI players compete against each other using classic Tetris rules. The match ends when one player taps out. Each AI sends garbage lines to the other when they clear lines.

## Core Features

- Classic Tetris ruleset
- Standard tetromino rotation system, 10x20 grid
- No hold functionality, no T-spins, no combos
- One active piece and one preview shown per player

## Garbage System

- Clearing 1, 2, 3, or 4 lines sends 0, 1, 2, or 4 garbage lines respectively
- Garbage lines contain two randomly placed holes
- Garbage is added from the bottom of the opponents' board with a short delay or warning animation

## Improved AI Logic

- Rule-based AI with smart placement heuristics
- Minimize the number of holes in the stack
- Minimize the height of the tallest column
- Maximize cleared lines when possible
- Prefer flat, even surfaces
- Evaluates multiple orientations and positions before selecting one

## Installation

To install the dependencies, run the following command:

```
pip install -r requirements.txt
```

## Running the Project

To run the project, execute the following command:

```
python tetris.py
```

## Contributing

We welcome contributions to this project. To contribute, please follow these steps:

1. Fork the repository
2. Create a new branch for your feature or bugfix
3. Make your changes
4. Submit a pull request with a clear description of your changes

## Testing the Latest Build

To test the latest build, run the following command:

```
python text_version/text_tetris.py
```

## Setting Up and Running the Project with the Self-Hosted Model

To set up and run the project with the self-hosted model, follow these steps:

1. Ensure that the self-hosted model is running and accessible.
2. Update the `ai_player.py` file to integrate the self-hosted model into the AI logic.
3. Install any necessary dependencies for the self-hosted model integration by adding them to the `requirements.txt` file.
4. Run the project using the following command:

```
python tetris.py
```

## Setting Up and Running the Text-Based Version with the Self-Hosted Model

To set up and run the text-based version with the self-hosted model, follow these steps:

1. Ensure that the self-hosted model is running and accessible.
2. Update the `text_version/text_tetris.py` file to include the logic for using the self-hosted model to control the AI players.
3. Install any necessary dependencies for the self-hosted model integration by adding them to the `requirements.txt` file.
4. Run the text-based version using the following command:

```
python text_version/text_tetris.py
```
