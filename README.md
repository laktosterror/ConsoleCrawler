# Dungeon Crawler

This project is a simplified version of a dungeon crawler game, implemented as a console application. In this type of role-playing game, players explore labyrinthine areas known as dungeons, battling different enemies.
My task was to write code in C# that reads the file and creates various objects (walls, player, and enemies) that manage their own data (e.g., position, color, health) and methods (e.g., movement, attack).

## Overview

The game features a predefined dungeon layout provided in a text file (download Level1.txt). The dungeon includes two types of monsters: "rats" and "snakes," along with a designated starting position for the player. 

## Class Hierarchy

The game includes three main object types: `Wall`, `Rat`, and `Snake`, all inheriting from an abstract base class called `LevelElement`. This class defines shared functionality, including properties for (X,Y) position, a character for rendering, and a method to draw the element.

- **Wall**: Inherits from `LevelElement` and defines its color and character.
- **Enemy**: An abstract class for enemies, requiring subclasses to implement specific behaviors. It includes properties for name, health, and attack/defense mechanics.
- **Rat** and **Snake**: Concrete enemy classes that initialize their unique properties and implement the `Update` method.

## Loading Level Data

A `LevelData` class manages a list of `LevelElement` objects. The `Load(string filename)` method reads the dungeon layout from the specified file, creating instances of the corresponding classes for each character found (e.g., `#`, `r`, `s`) and storing their positions.

## Game Loop

The game loop continuously runs while the game is active, waiting for user input to perform player and enemy actions. Movement is restricted by walls and other objects, and players attack enemies when they occupy the same space.

## Vision Range

The player's visibility is limited to a radius of 5 characters, allowing for exploration. Walls remain visible once seen, while enemies disappear when outside this range.

## Dice Mechanics

The game simulates dice rolls to determine damage during attacks. A `Dice` class allows for the creation of various dice configurations (e.g., "3d6+2" - 3 dices, each with 6 sides + modifier) and includes a method to roll the dice.

## Combat System

When a player or enemy attacks, both roll their dice to determine attack and defense points. Damage is calculated based on the difference between these points, affecting health points (HP). If the defender survives, they counterattack.

## Movement Patterns

- The player moves one step in any direction based on user input.
- Rats move randomly in one of four directions.
- Snakes remain stationary if the player is more than two spaces away; otherwise, they move away from the player.

This project emphasizes object-oriented programming principles and provides a foundation for further development and enhancements.
