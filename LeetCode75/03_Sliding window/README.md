## **Sliding Window Technique: Overview**
The **sliding window** technique is a problem-solving approach used to reduce the computational complexity when working with subsets (subarrays, substrings, or sliding ranges) of a given dataset. This method involves using a fixed or variable-sized window that moves (slides) through the data structure.

## **What Does It Mean?**
The sliding window technique uses two pointers (or indices) to represent the start and end of a "window" over a dataset. By adjusting these pointers, the algorithm processes the window's content efficiently, reusing calculations and avoiding redundant work.

## **When Do We Use It?**
The sliding window technique is commonly used when:

1. **The problem involves contiguous elements:**
    - Subarrays or substrings with specific conditions (e.g., sum, product, uniqueness).
    - Finding the maximum, minimum, or average of all subarrays of a fixed size.
2. **Optimization problems:**
    - Maximizing or minimizing values within a window.
    - Finding the shortest or longest window that satisfies conditions.
3. **Dynamic subsets:**
    - Problems where the window size changes based on conditions.
    - For example, the longest substring without repeating characters.

## **Why Do We Have to Use It?**
1. Efficiency:
    - Sliding window often reduces time complexity from O(n<sup>2</sup>) (brute force) to O(n) by avoiding redundant calculations.
2. Simplicity:
    - It simplifies logic for problems involving contiguous data processing.
3. Reusability:
    - The method efficiently reuses information from previous computations in the sliding window.

## **How to Use It?**
**General Steps:**
1. **Initialize Pointers:**
    - Set the `start` and `end` of the window, typically at the beginning of the data structure.
2. **Expand the Window:**
    - Move the `end` pointer to include more elements and process the new element.
3. **Shrink the Window:**
    - Move the `start` pointer to exclude elements when conditions are violated.
4. **Track Results:**
    - Update the result (e.g., maximum, minimum, or sum) whenever the conditions are met.
5. **Iterate Until Completion:**
    - Stop when the `end` pointer reaches the end of the dataset.

## **Identifying Characteristics of Problems Suitable for Sliding Window**
**Signs a problem can be solved with sliding window:**
1. **Contiguous Subset:**
    - You need to find or evaluate all subsets of contiguous elements (e.g., subarrays or substrings).
2. **Optimization Criteria:**
    - Problems ask for the maximum, minimum, or count of elements in a window.
3. **Dynamic Window Size:**
    - The window expands or shrinks based on problem-specific conditions.
4. **Condition Evaluation:**
    - Problems involve checking a specific condition over subsets of the dataset (e.g., unique characters, sums, or target matches).

## **Examples**
**Example 1: Maximum Sum of Subarray of Fixed Size**

**Problem:** Find the maximum sum of all subarrays of size k.

**Approach:**

1. Use a fixed-size sliding window.
2. Add the new element at the end and remove the element at the start as the window slides.

Code:

    int MaxSumSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        int maxSum = 0, currentSum = 0;

        for (int i = 0; i < n; i++)
        {
            currentSum += nums[i];

            if (i >= k - 1)
            {
                maxSum = Math.Max(maxSum, currentSum);
                currentSum -= nums[i - (k - 1)];
            }
        }

        return maxSum;
    }
    
**Example 2: Longest Substring Without Repeating Characters**

**Problem:** Find the length of the longest substring without repeating characters.

**Approach:**
1. Use a variable-sized sliding window.
2. Expand the window by moving the end pointer.
3. Shrink the window by moving the start pointer when duplicates are found.

Code:

    int LengthOfLongestSubstring(string s)
    {
        var set = new HashSet<char>();
        int start = 0, maxLength = 0;

        for (int end = 0; end < s.Length; end++)
        {
            while (set.Contains(s[end]))
            {
                set.Remove(s[start]);
                start++;
            }
            set.Add(s[end]);
            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }

**Example 3: Minimum Window Substring**

**Problem:** Find the smallest window in a string that contains all characters of another string.

**Approach:**
1. Use a variable-sized sliding window.
2. Expand the window to include all required characters.
3. Shrink the window while still satisfying the condition.

Code:

    string MinWindowSubstring(string s, string t)
    {
        var countT = new Dictionary<char, int>();
        foreach (var c in t)
            countT[c] = countT.GetValueOrDefault(c, 0) + 1;

        var window = new Dictionary<char, int>();
        int start = 0, matched = 0, minLength = int.MaxValue, minStart = 0;

        for (int end = 0; end < s.Length; end++)
        {
            char c = s[end];
            window[c] = window.GetValueOrDefault(c, 0) + 1;

            if (countT.ContainsKey(c) && window[c] == countT[c])
                matched++;

            while (matched == countT.Count)
            {
                if (end - start + 1 < minLength)
                {
                    minLength = end - start + 1;
                    minStart = start;
                }

                char leftChar = s[start++];
                window[leftChar]--;
                if (countT.ContainsKey(leftChar) && window[leftChar] < countT[leftChar])
                    matched--;
            }
        }

        return minLength == int.MaxValue ? "" : s.Substring(minStart, minLength);
    }

## **Key Takeaways**
1. Use sliding window when the problem involves contiguous subsets or ranges.
2. Fixed-size windows are simpler; variable-sized windows require more condition checks.
3. The technique is especially useful for optimization and condition-checking problems.