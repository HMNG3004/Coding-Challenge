# **Day 5: Print Queue** 🎄

## Challenge Overview

Satisfied with their search on Ceres, the squadron of scholars suggests subsequently scanning the stationery stacks of sub-basement 17.

For the full description of the challenge, visit the official [Advent of Code 2024 - Day 5](https://adventofcode.com/2024/day/5) page.

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
47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47
```
