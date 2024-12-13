# **Find Score of an Array After Marking All Elements**

You are given an array `nums` consisting of positive integers.

Starting with `score = 0`, apply the following algorithm:

- Choose the smallest integer of the array that is not marked. If there is a tie, choose the one with the smallest index.
- Add the value of the chosen integer to `score`.
- Mark **the chosen element and its two adjacent elements if they exist.**
- Repeat until all the array elements are marked.

_Return the score you get after applying the above algorithm._

View full question <a href="https://leetcode.com/problems/find-score-of-an-array-after-marking-all-elements?envType=daily-question&envId=2024-12-13D">here</a>
