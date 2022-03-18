using System;
using System.Collections.Generic;

namespace Sorting_Algorithms
{
	internal delegate void Choiсe (int[] array);

	internal static class Program
	{
		internal static void Main(string[] args)
		{
			GetChoice();
		}

		internal static void Manager(int[] array, Choiсe choiсe)
		{
			if (array is null)
			{
				throw new ArgumentNullException(nameof(array));
			}
			choiсe(array);
			Display(array);
		}

		internal static int GetIntChoice()
		{
			Console.WriteLine("Choice method of sort: \n 1 - Selection Sort" +
				"\n 2 - Recursive Selection Sort" +
				"\n 3 - Insertion Sort" +
				"\n 4 - Recursive Insertion Sort" +
				"\n 5 - Bubble Sort" +
				"\n 6 - Recursive Bubble Sort" +
				"\n 7 - Quick Sort");
			
			if (int.TryParse(Console.ReadLine(), out int i))
			{
				return i;
			}
			else
			{
				throw new ArgumentException(message: "Invalid choise");
			}
		}

		internal static void GetChoice()
		{
			int i = GetIntChoice();
			if (i < 0 || i > 7)
			{
				throw new ArgumentException(message: "Invalid choise");
			}
			int[] array = GetArray();
			switch (i)
			{
				case 1:
					Manager(array, Sorter.SelectionSort);
					break;
				case 2:
					Manager(array, Sorter.RecursiveSelectionSort);
					break;
				case 3:
					Manager(array, Sorter.InsertionSort);
					break;
				case 4:
					Manager(array, Sorter.RecursiveInsertionSort);
					break;
				case 5:
					Manager(array, Sorter.BubbleSort);
					break;
				case 6:
					Manager(array, Sorter.RecursiveBubbleSort);
					break;
				case 7:
					Manager(array, Sorter.QuickSort);
					break;
			}
		}

		internal static int[] GetArray()
		{
			Console.WriteLine(" 1 - Random array" +
				"\n 2 - Create array");
			if (int.TryParse(Console.ReadLine(), out int i))
			{
				List<int> list = new List<int>();
				switch (i)
				{
					case 1:
						Console.WriteLine("Enter arry langht");
						if (int.TryParse(Console.ReadLine(), out int l))
						{
							if (l < 0 || l > int.MaxValue)
							{
								throw new ArgumentException(message: "Invalid array langht");
							}

							Random x = new Random();
							for (int j = 0; j < l; j++)
							{
								list.Add(x.Next());
							}
							Console.WriteLine("Your array is:");
							Display(list.ToArray());
							return list.ToArray();
						}
						else
						{
							throw new ArgumentException(message: "Invalid array langht");
						}
					case 2:
						Console.WriteLine("Start enter member of array with white space separator:");
						string[] stringArray = Console.ReadLine().Split(' ', StringSplitOptions.None);
						for (int j = 0; j < stringArray.Length; j++)
						{
							if (int.TryParse(stringArray[j], out int u))
							{
								list.Add(u);
							}
							else
							{
								throw new ArgumentException(message: "Invalid member of array");
							}
							
						}
						return list.ToArray();
					default:
						throw new ArgumentException(message: "Invalid choice");
				}
			}
			else
			{
				throw new ArgumentException(message: "Invalid choice");
			}
		}

		internal static void Display(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine(array[i]);
			}
		}
	}
}
