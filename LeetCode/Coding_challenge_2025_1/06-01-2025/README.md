# **Minimum Number of Operations to Move All Balls to Each Box**

You have `n` boxes. You are given a binary string `boxes` of length `n`, where `boxes[i]` is `'0'` if the **i<sup>th</sup>** box is **empty**, and `'1'` if it contains **one** ball.

In one operation, you can move one ball from a box to an adjacent box. Box `i` is adjacent to box `j` if `abs(i - j) == 1`. Note that after doing so, there may be more than one ball in some boxes.

Return an array `answer` of size `n`, where `answer[i]` is the **minimum** number of operations needed to move all the balls to the **i<sup>th</sup>** box.

Each `answer[i]` is calculated considering the initial state of the boxes.

View full [question](https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box?envType=daily-question&envId=2025-01-06)

View my [submission](https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/submissions/1499274297)

Bonus with python : [submission](https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/submissions/1499264830)
