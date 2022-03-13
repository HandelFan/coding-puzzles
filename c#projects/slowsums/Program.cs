using System;

class SlowSums {
  static void Main(string[] args) {
    // Call getTotalTime() with test cases here
    int[] arr = new int[]{1, 2, 3, 4, 5};
    
    Console.WriteLine(getTotalTime(arr) == 50);

    arr = new int[]{4, 1, 2, 3};

    Console.WriteLine(getTotalTime(arr) == 26);
  }
  

  private static int getTotalTime(int[] arr) {
    // Write your code here
    Array.Sort(arr);
    int totalTime = 0;
    for (int i = arr.Length - 1; i >= 1; i -= 1) {
        totalTime += arr[i] + arr[i - 1];
        arr[i - 1] = arr[i] + arr[i - 1];
    }

    return totalTime;
  }
}