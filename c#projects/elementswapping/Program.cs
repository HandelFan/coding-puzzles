using System;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class ElementSwapping {
  static void Main(string[] args) {
    // Call findMinArray() with test cases here
    int minVal = 1;
    int maxVal = 1000000;

    int n_1 = 3;
    int k_1 = 2;
    int[] arr_1 = {5, 3, 1};
    int[] expected_1 = {1, 5, 3};
    int[] output_1 = FindMinArray(arr_1,k_1);
    if (Check(expected_1, output_1)) {
      Console.WriteLine("test1 succeeded");
    }
    else {
      Console.WriteLine("test1 failed");
      Console.WriteLine("Output array:");
      foreach (int i in output_1) {
        Console.WriteLine(i);
      }
    }
    
    int n_2 = 3;
    int k_2 = 3;
    int[] arr_2 = {1, 3, 5};
    int[] expected_2 = {1, 3, 5};
    int[] output_2 = FindMinArray(arr_2, k_2);
    if (Check(expected_2, output_2)) {
      Console.WriteLine("test2 succeeded");
    }

    //basic test:
    //test1, test regular int array of 5 random nums, k = 4.
    
    //2+swap test:
    //test4, test if it does 2 swaps properly, 3 swaps

    //edgecase test:
    //test2, test an array with no swaps until the very end
    //test3, test an array with only 1 swap at the very beginning
    //test5, test reverse ordered list such that k = arr.length


    //test whether k is getting decremented properly:
    //try k = arr.length
    //try k > arr.length
    //try k > arr.length extra swaps
    //k > arr.length not enough swaps
    //k > arr.length exactly enough swaps
    //k < arr.length, not big enough to swap 1 element
    //
    
  }

  private static bool Check(int[] expected, int[] output) {
    bool result = true;
    if(expected.Length != output.Length) {
      return false;
    }
    for(int i = 0; i <expected.Length; i++) {
      result &= (expected[i] == output[i]);
    }
    return result;
  }
  
  private static int[] FindMinArray(int[] arr, int k) {
    // Write your code here
    int i = 0;
    int minVal = arr[0];
    while (k > 0 && i + 1 < arr.Length) {
      int minValTemp = FindMinValueIndex(arr, i + 1, i + k);
      if (arr[minValTemp] < minVal) {
        for (int swapCount = minValTemp; swapCount > i; swapCount--) {
          (arr[swapCount], arr[swapCount - 1]) = (arr[swapCount - 1], arr[swapCount]);
        }
        minVal = arr[minValTemp];
        k -= minValTemp - i;
      }
      else {
        i++;
      }
    }
    return arr;
  }

  private static int FindMinValueIndex(int[] arr, int startIndex, int endIndex) {
    endIndex = endIndex >= arr.Length ? arr.Length - 1 : endIndex;
    int minIndex = startIndex;
    for (int i = startIndex + 1; i <= endIndex; i++) {
      minIndex = arr[i] < arr[minIndex] ? i : minIndex;
    }
    return minIndex;
  }
}