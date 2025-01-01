# **Number of Ways to Form a Target String Given a Dictionary**

You are given a list of strings of the **same length** `words` and a string `target`.

Your task is to form `target` using the given `words` under the following rules:

- `target` should be formed from left to right.
- To form the **i<sup>th</sup>** character (**0-indexed**) of `target`, you can choose the **k<sup>th</sup>** character of the **j<sup>th</sup>** string in `words` if `target[i] = words[j][k]`.
- Once you use the **k<sup>th</sup>** character of the **j<sup>th</sup>** string of `words`, you **can no longer** use the **x<sup>th</sup>** character of any string in `words` where `x <= k`. In other words, all characters to the left of or at index `k` become unusuable for every string.
- Repeat the process until you form the string target.

**Notice** that you can use **multiple characters** from the **same string** in `words` provided the conditions above are met.

_Return the number of ways to form `target` from `words`._ Since the answer may be too large, return it **modulo** 10<sup>9</sup> + 7.

View full [question](https://leetcode.com/problems/number-of-ways-to-form-a-target-string-given-a-dictionary?envType=daily-question&envId=2024-12-29)

View my [submission](https://leetcode.com/problems/number-of-ways-to-form-a-target-string-given-a-dictionary/submissions/1491382599)
