# **Find Building Where Alice and Bob Can Meet**

You are given a **0-indexed** array `heights` of positive integers, where `heights[i]` represents the height of the **i<sup>th</sup>** building.

If a person is in building `i`, they can move to any other building `j` if and only if `i < j` and `heights[i] < heights[j]`.

You are also given another array `queries` where `queries[i] = [ai, bi]`. On the **i<sup>th</sup>** query, Alice is in building **a<sub>i</sub>** while Bob is in building **b<sub>i</sub>**.

_Return an `array` ans where `ans[i]` is **the index of the leftmost building** where Alice and Bob can meet on the **i<sup>th</sup>** query. If Alice and Bob cannot move to a common building on query `i`, set `ans[i]` to `-1`._

View full [question](https://leetcode.com/problems/find-building-where-alice-and-bob-can-meet?envType=daily-question&envId=2024-12-22)

View my [submission](https://leetcode.com/problems/find-building-where-alice-and-bob-can-meet/submissions/1485618612)
