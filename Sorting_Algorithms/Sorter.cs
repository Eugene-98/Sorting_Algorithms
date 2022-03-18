using System;

namespace Sorting_Algorithms
{
	public static class Sorter
    {
        /// <summary>
        /// Sorts an <paramref name="array"/> with selection sort algorithm.
        /// </summary>
        public static void SelectionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int temp, min;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive selection sort algorithm.
        /// </summary>
        public static void RecursiveSelectionSort(this int[] array)
        {
            Replace(array, 0);
        }

        public static void Replace(int[] array, int index)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == index)
            {
                return;
            }

            int i = MinIndex(array, index, array.Length - 1);
            if (i != index)
            {
                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }

            Replace(array, index + 1);
        }

        private static int MinIndex(int[] a, int i, int j)
        {
            if (i == j)
            {
                return i;
            }

            int k = MinIndex(a, i + 1, j);
            return (a[i] < a[k]) ? i : k;
        }
        /// <summary>
        /// Sorts an <paramref name="array"/> with insertion sort algorithm.
        /// </summary>
        public static void InsertionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    for (int j = i; j > 0; j--)
                    {
                        if (array[j] < array[j - 1])
                        {
                            int temp = array[j - 1];
                            array[j - 1] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive insertion sort algorithm.
        /// </summary>
        public static void RecursiveInsertionSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Replaace(array, 1);
        }

        private static void Replaace(int[] array, int n)
        {
            if (n < array.Length && n > 0)
            {
                SwapI(array, n);
                Replaace(array, n + 1);
            }
        }

        private static void SwapI(int[] array, int i)
        {
            if (i < array.Length && i > 0 && array[i] < array[i - 1])
            {
                int temp = array[i];
                array[i] = array[i - 1];
                array[i - 1] = temp;
                SwapI(array, i - 1);
            }
        }
        /// <summary>
        /// Sorts an <paramref name="array"/> with bubble sort algorithm.
        /// </summary>
        public static void BubbleSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an <paramref name="array"/> with recursive bubble sort algorithm.
        /// </summary>
        public static void RecursiveBubbleSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            Sort(array, 0);
        }

        private static void Sort(int[] array, int i)
        {
            if (i < array.Length)
            {
                Swap(array, 0, i);
            }
        }

        private static void Swap(int[] array, int j, int i)
        {
            if (j < array.Length - 1)
            {
                if (array[j + 1] < array[j])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    Swap(array, j + 1, i);
                }
                else
                {
                    Swap(array, j + 1, i);
                }
            }
            else
            {
                Sort(array, i + 1);
            }
        }
        public static void QuickSort(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            QSort(array, 0, array.Length - 1);
        }

        private static void QSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);

                QSort(array, low, pi - 1);
                QSort(array, pi + 1, high);
            }
        }

        private static int Partition(int[] array, int low, int high)
        {
            int temp;
            int pivot = array[high];

            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;

                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;

            return i + 1;
        }
    }
}
