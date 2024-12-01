## Longest Substring with Even Vowels Count
### Problem Description
Given a string s, we need to find the size of the longest substring where each vowel ('a', 'e', 'i', 'o', and 'u') appears an even number of times. Non-vowel characters can appear any number of times without restrictions.

### Approach
The solution leverages bit manipulation to track how often each vowel appears as we traverse the string. We use a bitmask where each bit represents whether a vowel has been encountered an even (0) or odd (1) number of times.

#### Steps:
1.  **Vowel Mapping**: We first map each vowel to a specific bit:
-   'a' → 0th bit
-   'e' → 1st bit
-   'i' → 2nd bit
-   'o' → 3rd bit
-   'u' → 4th bit

2.  **Bitmask State**: We maintain a bitmask (currentMask) where each bit tracks the parity (even or odd) of a vowel’s count. Initially, currentMask is 0, meaning all vowels have appeared an even number of times.

3.  **Track Seen States**: We use a dictionary (seen) to store the first occurrence of each bitmask state. If the current bitmask has been seen before, it means that the substring between these two positions contains each vowel an even number of times.

4.  **Traverse the String**: For each character in the string, if it's a vowel, we toggle the corresponding bit in the bitmask. We then check if the current bitmask has been seen before:
-   If yes, we calculate the length of the substring from the first occurrence of that bitmask to the current position.
-   If not, we store the current position of the bitmask in the dictionary.

5.  **Maximize Substring Length**: At each step, we update the maximum length of the substring where all vowels appear an even number of times.

#### Example Walkthrough:
Input: ```s = "eleetminicoworoep"```

Output: ```13```

Explanation: The longest substring ```"leetminicowor"``` contains two of each vowel ```e```, ```i```, and ```o```, and none of ```a``` and ```u```.

### Example

#### Example 1
**Input 1**: ```s = "eleetminicoworoep"```

**Output**: ```13```

**Explanation**: The substring ```"leetminicowor"``` is the longest with even counts of vowels.

#### Example 2
**Input 2**: ```s = "leetcodeisgreat"```

**Output**: ```5```

**Explanation**: The longest substring with even vowel counts is "leetc".

#### Example 3
**Input 3**: ```s = "bcbcbc"```

**Output**: ```6```

**Explanation**: Since there are no vowels in this string, the entire string is the longest substring.

### Time Complexity
-  **Traversal**: O(n), where ```n``` is the length of the string ```s```. We only traverse the string once.

-  **Bitmasking and Dictionary Lookup**: Each vowel bit manipulation and dictionary lookup takes constant time.

Thus, the overall time complexity is **O(n)**.

### Space Complexity
-  We use a dictionary to store bitmask states, which requires O(n) space in the worst case.

### Why is this Efficient?
This solution uses bit manipulation and a single-pass traversal of the string. By leveraging the dictionary to store previously seen bitmask states, we can efficiently calculate the longest valid substring in linear time.

### Author's Notes ✍️💭
Working on this problem was both challenging and rewarding. The bit manipulation approach provided an elegant and efficient solution. This problem took me almost all day to solve. It is a new knowledge to me. 🚀🎉
