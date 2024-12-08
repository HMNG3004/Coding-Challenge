# **Day 8: Resonant Collinearity** 🎄

## Challenge Overview

Scanning across the city, you find that there are actually many such antennas. Each antenna is tuned to a specific frequency indicated by a single lowercase letter, uppercase letter, or digit. You create a map (your puzzle input) of these antennas.

For the full description of the challenge, visit the official [Advent of Code 2024 - Day 8](https://adventofcode.com/2024/day/8) page.

---

## Approach to the Problem

### **Step 1: Input Parsing**

We begin by reading the input data provided in a text file. Each line corresponds to a specific clue about the Historian's whereabouts.

### **Step 2: Logic Implementation**

Using the rules from the challenge:

1. Process each clue sequentially.
2. Apply the logic described in the problem to determine the Historian’s location.
3. Consider edge cases, such as duplicate locations or unexpected input formats.

### **Step 3: Result Calculation**

After processing all clues, output the exact location where the Historian is most likely to be found.

---

## Example

### Input

A sample input file (`input.txt`) might contain:

```txt
............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............
```
