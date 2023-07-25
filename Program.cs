using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _25JulyAssignment15
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        //Merge Sort
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);

        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }


        static void Main(string[] args)
        {
            int[] arr1 = { -7, 96, -3, 9, 7, 57, 34, 0, 8 };
            int[] arr2 = { -7, 96, -3, 9, 7, 57, 34, 0, 8 };

            //Quick Sorting
            Console.WriteLine("Before Sorting using Quick Sort:");
            Print(arr1);

            Console.WriteLine("After Quick Sort:");
            Stopwatch stopwatch0 = new Stopwatch();
            stopwatch0.Start();
            QuickSort(arr1);
            stopwatch0.Stop();
            Print(arr1);

            Console.WriteLine($"Array {arr1.Length} Time Taken for Quick Sort is {stopwatch0.Elapsed.TotalMilliseconds} milliseconds\n");
            Console.WriteLine("********************************************");

            //Merge Sorting
            Console.WriteLine("Before Sorting using Merge Sort: ");
            Print(arr2);
            Console.WriteLine("After Merge Sort:");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            MergeSort(arr2);
            stopwatch1.Stop();
            Print(arr2);

            Console.WriteLine($"\nArray {arr1.Length} Time Taken for Merge Sort is {stopwatch1.Elapsed.TotalMilliseconds} milliseconds");

            Console.ReadKey();

        }
    }
}

