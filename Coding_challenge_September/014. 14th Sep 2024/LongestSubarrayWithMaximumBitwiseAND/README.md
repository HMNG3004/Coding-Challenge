## Longest Subarray with Maximum Bitwise AND

### Problem Description
Given an integer array nums, we need to find the length of the longest subarray that has the maximum possible bitwise AND. 
The bitwise AND of a subarray is defined as the bitwise AND of all elements in that subarray.

### Approach
The key observation is that the maximum possible bitwise AND of a subarray is achieved when all elements in that subarray are equal to the largest element in the array.
This is because any subarray containing a smaller number will lower the result of the bitwise AND operation.

#### Steps:
1.  **Find the Maximum Element**: The first step is to find the largest element in the array nums, because the subarray with the maximum bitwise AND will only consist of this element.
```
int maximumElement = nums.Max(x => x);
```
2.  **Identify the Longest Subarray of Maximum Elements**: Next, we need to iterate through the array and find the length of the longest subarray that consists entirely of the maximum element. We initialize two variables:

-  ```maxLength```: to keep track of the longest subarray length.
-  ```currentLength```: to count the current subarray length while iterating.
For each element in ```nums```, if it is equal to ```maximumElement```, we increment ```currentLength```.
If it isn't, we compare ```currentLength``` with ```maxLength``` and reset ```currentLength``` to 0.
```
foreach (int num in nums)
{
    if (num == maximumElement)
    {
        currentLength++;
    }
    else
    {
        maxLength = Math.Max(maxLength, currentLength);
        currentLength = 0;
    }
}
```

3.  **Final Check**: After the loop, we check one last time to update ```maxLength``` in case the longest subarray ended at the last element of the array.
```
maxLength = Math.Max(maxLength, currentLength);
```
4.  **Return the Result**: Finally, we return the value of maxLength, which represents the length of the longest subarray with the maximum possible bitwise AND.
```
return maxLength;
```
## Example
**Input 1**
```
nums = [1,2,3,3,2,2]
```
-  The maximum element in the array is 3.
-  The longest subarray containing 3 is [3, 3], which has a length of 2.

**Output 1:**
```2```

**Input 2**
```
nums = [1,2,3,4]
```
-  The maximum element in the array is 4.
-  The longest subarray containing 4 is [4], which has a length of 1.

**Output 2:**
```1```

## Time Complexity
-  Finding Maximum Element: O(n), where n is the length of the array.
-  Iterating Through Array: O(n) to find the longest subarray consisting of the maximum element.
  
Thus, the total time complexity is O(n).

## Space Complexity
-  The space complexity is O(1) since we only use a few variables (```maximumElement```, ```maxLength```, ```currentLength```) and do not require additional data structure

## Why is this Efficient?
This approach ensures that we solve the problem in a single pass over the array after identifying the maximum element. This linear solution is highly efficient for larger arrays.
