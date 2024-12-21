# **Maximum Number of K-Divisible Components**

There is an undirected tree with `n` nodes labeled from `0` to `n - 1`. You are given the integer `n` and a 2D integer array `edges` of length `n - 1`, where `edges[i] = [ai, bi]` indicates that there is an edge between nodes **a<sub>i</sub>** and **b<sub>i</sub>** in the tree.

You are also given a **0-indexed** integer array `values` of length `n`, where `values[i]` is the **value** associated with the **i<sup>th</sup>** node, and an integer **k**.

A **valid split** of the tree is obtained by removing any set of edges, possibly empty, from the tree such that the resulting components all have values that are divisible by `k`, where the value of a connected component is the sum of the values of its nodes.

_Return the **maximum number of components** in any valid split._

View full [question](https://leetcode.com/problems/maximum-number-of-k-divisible-components?envType=daily-question&envId=2024-12-21)

View my [submission](https://leetcode.com/problems/maximum-number-of-k-divisible-components/submissions/1484388914)
