# **Minimum Length of String After Operations**

You are given a string `s`.

You can perform the following process on `s` **any** number of times:

- Choose an index `i` in the string such that there is `at least` one character to the left of index `i` that is equal to `s[i]`, and **at least** one character to the right that is also equal to `s[i]`.
- Delete the **closest** character to the **left** of index `i` that is equal to `s[i]`.
- Delete the **closest** character to the **right** of index `i` that is equal to `s[i]`.

Return the **minimum** length of the final string `s` that you can achieve.

View full [question](https://leetcode.com/problems/minimum-length-of-string-after-operations?envType=daily-question&envId=2025-01-13)

View my [submission](https://leetcode.com/problems/minimum-length-of-string-after-operations/submissions/1507378255)