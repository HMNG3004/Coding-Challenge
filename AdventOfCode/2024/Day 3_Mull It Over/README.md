# **Day 3: Mull It Over** 🎄

## Challenge Overview

"Our computers are having issues, so I have no idea if we have any Chief Historians in stock! You're welcome to check the warehouse, though," says the mildly flustered shopkeeper at the North Pole Toboggan Rental Shop. The Historians head out to take a look.

For the full description of the challenge, visit the official [Advent of Code 2024 - Day 3](https://adventofcode.com/2024/day/3) page.

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
xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
```

.
