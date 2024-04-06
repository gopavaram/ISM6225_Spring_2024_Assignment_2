/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Numerics;
using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine($"Output: {numberOfUniqueNumbers}, nums = [{string.Join(",", nums1)}]");

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1,1,1,1,1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 10, 3, 8, 2, 16 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0) return 0; // Handles empty array case
                int idx = 0; // Keeps track of current element's position
                             // Use two pointers: one for unique elements (idx) and another to iterate (i)
                             // If current element is different from the one at idx, it's new, so update idx
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[idx])
                    {
                        idx++;
                        nums[idx] = nums[i];
                    }
                }
                for (int i = idx+1; i < nums.Length; i++)
                {
                    nums[i] = 'V';
                }
                return idx + 1; // Returns the new length of unique elements
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self- Reflection:
            This code removes duplicate numbers from a sorted list, keeping only one copy of each unique number. 
            It then counts how many unique numbers are left and updates the list accordingly. 
            It works by comparing each number with the one before it. If they're different, it keeps the current number as unique and moves forward. 
            Finally, it returns the count of unique numbers.
        */


        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Start by setting up an index to track the next non-zero element's position.
                int Ind = 0;

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is non-zero, move it to the nonZeroIndex position and increment Ind
                    if (nums[i] != 0)
                    {
                        nums[Ind] = nums[i];
                        Ind++;
                    }
                }

                // Fill the remaining positions from nonZeroIndex to the end of the array with zeros
                while (Ind < nums.Length)
                {
                    nums[Ind] = 0;
                    Ind++;
                }

                return new List<int>(nums);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self- Reflection:

            This code reorganizes an integer array, moving all zeros to the end while preserving the order of non-zero elements.
         */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {

                IList<IList<int>> tripletsList = new List<IList<int>>(); // Initialize list to store unique triplets
                Array.Sort(nums); // Sort the input array in ascending order

                // Iterate through the array, leaving out the last two elements to form a triplet
                for (int idx = 0; idx < nums.Length - 2; idx++)
                {
                    // Skip duplicate elements to avoid duplicate triplets
                    if (idx > 0 && nums[idx] == nums[idx - 1])
                        continue;

                    int leftPtr = idx + 1; // Pointer for the element after the current element
                    int rightPtr = nums.Length - 1; // Pointer for the last element of the array

                    // Use the two-pointer approach to find the other two elements for forming the triplet
                    while (leftPtr < rightPtr)
                    {
                        int tripletSum = nums[idx] + nums[leftPtr] + nums[rightPtr]; // Calculate the sum of the current triplet

                        // If the sum is zero, we have found a triplet
                        if (tripletSum == 0)
                        {
                            // Add the triplet to the result list
                            tripletsList.Add(new List<int> { nums[idx], nums[leftPtr], nums[rightPtr] });

                            // Skip duplicates for the left and right pointers
                            while (leftPtr < rightPtr && nums[leftPtr] == nums[leftPtr + 1])
                                leftPtr++;
                            while (leftPtr < rightPtr && nums[rightPtr] == nums[rightPtr - 1])
                                rightPtr--;

                            // Move the pointers to find other triplets
                            leftPtr++;
                            rightPtr--;
                        }
                        else if (tripletSum < 0)
                        {
                            leftPtr++; // Move the left pointer to increase the sum
                        }
                        else
                        {
                            rightPtr--; // Move the right pointer to decrease the sum
                        }
                    }
                }


                return tripletsList; // Return list of unique triplets
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
         * Self-Reflection:
            This code looks for sets of three numbers in a list where if you add them up, they equal zero.
            It sorts the list first to make it easier to search through. 
            Then, it checks each set of three numbers to see if they fit the rule. If they do, it adds them to the list.
         */


        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int Total1 = 0; // store the maximum count of consecutive 1's
                int count = 0;    //store the current count of consecutive 1's

                foreach (int num in nums)
                {
                    // If the current element is 1, increment the count
                    if (num == 1)
                    {
                        count++;
                    }
                    else
                    {
                        // If the current element is 0, update maxCount if count is greater,
                        // then reset count to 0
                        Total1 = Math.Max(Total1, count);
                        count = 0;
                    }
                }

                // Update Total1 if the last sequence of 1's is longer than any previous ones
                Total1 = Math.Max(Total1, count);
                return Total1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*This code counts how many times there are back-to-back ones in a row in a line of numbers. 
          If it spots a zero, it stops counting and checks if it's seen more ones in a row than before. 
          Then it tells you the longest streak of ones it found. 
          It's like counting how many times you see the same color in a row in a line of colored blocks.
        */


        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. 
        You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binaryNumber)
        {
            try
            {
                int decimalValue = 0; // Start with decimal value set to 0
                int baseValue = 1; // Set the base value to 1

                // Convert binary number to decimal
                while (binaryNumber != 0)
                {
                    int digit = binaryNumber % 10; // Extract the last digit of the binary number
                    binaryNumber = binaryNumber / 10; // Remove the last digit from the binary number

                    decimalValue = decimalValue + (digit * baseValue); // Update the decimal value
                    baseValue = baseValue * 2; // Multiply the base value by 2 for the next digit (bit)
                }

                return decimalValue; // Return the final decimal value after conversion

            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self- Reflection:
          This code takes a binary number like a series of on/off switches and adds up their values to get the equivalent decimal number. 
          It's like counting the total number of lights turned on, where each light represents a power of 2, starting from 1.
         */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                    return 0;

                int maxDifference = 0;

                // Find the smallest and largest elements in the array
                int minElement = nums[0];
                int maxElement = nums[0];

                foreach (int element in nums)
                {
                    minElement = Math.Min(minElement, element);
                    maxElement = Math.Max(maxElement, element);
                }

                // Calculate the size of each segment
                int segmentSize = Math.Max(1, (maxElement - minElement) / (nums.Length - 1));

                // Calculate the number of segments
                int numSegments = (maxElement - minElement) / segmentSize + 1;

                // Initialize segments
                int[] minSegment = new int[numSegments];
                int[] maxSegment = new int[numSegments];
                bool[] hasElement = new bool[numSegments];

                // Put elements into segments
                foreach (int element in nums)
                {
                    int segmentIndex = (element - minElement) / segmentSize;
                    minSegment[segmentIndex] = hasElement[segmentIndex] ? Math.Min(minSegment[segmentIndex], element) : element;
                    maxSegment[segmentIndex] = hasElement[segmentIndex] ? Math.Max(maxSegment[segmentIndex], element) : element;
                    hasElement[segmentIndex] = true;
                }

                // Calculate the maximum difference
                int previousMax = minElement;
                for (int i = 0; i < numSegments; i++)
                {
                    if (hasElement[i])
                    {
                        maxDifference = Math.Max(maxDifference, minSegment[i] - previousMax);
                        previousMax = maxSegment[i];
                    }
                }

                return maxDifference;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /*  Self- Reflection:
         This code finds the biggest gap between neighboring numbers in a sorted list. 
         It splits the range between the smallest and largest numbers into sections and assigns each number to its appropriate section. 
         Then, it calculates the largest gap between sections with numbers. 
         Finally, it reports this gap as the result.*/

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3)
                    return 0; // If the array has fewer than 3 elements, return 0

                Array.Sort(nums); // Sort the array in ascending order

                // Start from the end of the sorted array to maximize perimeter
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    // Check if the current triplet can form a triangle with non-zero area
                    if (nums[i] < nums[i - 1] + nums[i - 2])
                        return nums[i] + nums[i - 1] + nums[i - 2]; // If possible, return the perimeter of the triangle
                }

                return 0; // If no triangle with non-zero area is possible, return 0
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self- Reflection:
         This code finds the largest perimeter of a triangle that can be formed from three lengths given in an array. 
         It first sorts the array in ascending order. 
        Then, starting from the end of the sorted array, it checks if three consecutive lengths can form a triangle with a non-zero area. 
         If such a triangle is found, it returns the perimeter of that triangle. If no such triangle can be formed, it returns 0.
         */

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                while (s.Contains(part))
                {
                    int index = s.IndexOf(part); // Determine the index of the first occurrence of the part within the string
                    s = s.Remove(index, part.Length); // Remove the part from the string, starting at the determined index
                }
                return s; // Once all occurrences of the part have been removed from the string, return the modified string

            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self- Reflection:
         This code acts like a text cleaner, removing specific unwanted words or phrases from a text. 
         It searches through the text for the first instance of the unwanted term, deletes it, and then repeats the process. 
         It continues doing this until the term can no longer be found, ensuring the final text doesn't contain that particular sequence of words.*/

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}