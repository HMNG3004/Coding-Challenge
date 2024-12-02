## Greedy Algorithm
### Overview
A Greedy Algorithm is a problem-solving approach used in optimization problems where the best choice at each step is selected with the hope of finding a global optimum. The Greedy Algorithm makes the locally optimal choice at each stage with the intent of finding a global optimum.

Greedy algorithms are known for their simplicity and efficiency. They are particularly useful in situations where a problem can be broken down into smaller subproblems that can be solved independently.

## How Greedy Algorithms Work
- Initialization: Start with an initial solution, often empty or a starting point.

- Selection: Choose the best option available according to the problem's criteria. This choice is made based on a "greedy choice" property, which implies that the locally optimal choice also leads to a globally optimal solution.

- Feasibility Check: Check if the chosen option leads to a feasible solution.

- Add to Solution: Add the chosen option to the solution.

- Repeat: Repeat the process until a complete solution is obtained.

- Final Solution: Once no more options are available, the final solution is achieved.

## Examples of Greedy Algorithms
### 1. Activity Selection Problem
- Given a set of activities with start and end times, the goal is to select the maximum number of activities that don't overlap.
- The greedy approach is to pick the activity that ends the earliest and continue selecting the next activity that starts after the last selected one.
### 2. Huffman Coding
- Huffman coding is a greedy algorithm used for lossless data compression. It assigns variable-length codes to input characters, with shorter codes assigned to more frequent characters.
- The greedy choice is to merge the two least frequent nodes until the entire tree is constructed.
### 3. Fractional Knapsack Problem
- The objective is to maximize the total value of items placed in a knapsack, given a weight limit.
- The greedy approach is to select items based on their value-to-weight ratio and include them fractionally if necessary.
### 4. Prim's and Kruskal's Algorithms
- These are greedy algorithms used to find the minimum spanning tree in a weighted graph.
- Prim's algorithm starts from an arbitrary vertex and grows the tree by adding the least expensive edge.
- Kruskal's algorithm sorts all edges by weight and adds the smallest edge to the growing spanning tree, avoiding cycles.
### Advantages of Greedy Algorithms
- Simplicity: Greedy algorithms are often easier to understand and implement than other approaches.
- Efficiency: They are generally faster since they make straightforward decisions at each step.
- Optimal for Certain Problems: For many problems, such as Huffman coding or Dijkstra's algorithm, greedy algorithms are provably optimal.
### Disadvantages of Greedy Algorithms
- Non-Optimal Solutions: Greedy algorithms do not always produce the optimal solution for all problems. They can get stuck in local optima and fail to find the global optimum.
- Problem-Specific: The effectiveness of a greedy algorithm is highly dependent on the problem structure. It may work well for one problem but not for another with a similar setup.
### When to Use a Greedy Algorithm
Greedy algorithms are ideal when:

- The problem has the "Greedy Choice Property," where a locally optimal choice leads to a globally optimal solution.
- The problem is easily divisible into subproblems.
- An approximate solution is acceptable.
### Conclusion
Greedy algorithms are a powerful tool in the optimization problem-solving toolkit. However, they must be applied with care, as they do not always yield the optimal solution. Understanding the problem's structure and whether it suits a greedy approach is key to successfully using this method.

### Resources
- https://www.geeksforgeeks.org/greedy-algorithms/
