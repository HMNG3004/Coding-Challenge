# **Count Prefix and Suffix Pairs I**

You are given a **0-indexed** string array `words`.

Let's define a **boolean** function `isPrefixAndSuffix` that takes two strings, `str1` and `str2`:

- `isPrefixAndSuffix(str1, str2)` returns `true` if `str1` is both a **prefix** and a **suffix** of `str2`, and `false` otherwise.

For example, `isPrefixAndSuffix("aba", "ababa")` is `true` because `"aba"` is a prefix of `"ababa"` and also a suffix, but `isPrefixAndSuffix("abc", "abcd")` is `false`.

_Return an integer denoting the **number** of index pairs `(i, j)` such that `i < j`, and `isPrefixAndSuffix(words[i], words[j])` is `true`._

View full [question](https://leetcode.com/problems/count-prefix-and-suffix-pairs-i?envType=daily-question&envId=2025-01-08)

View my [submission](https://leetcode.com/problems/count-prefix-and-suffix-pairs-i/submissions/1501318662)
