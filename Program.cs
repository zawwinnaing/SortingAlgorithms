using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        public static List<int> lstInt = new List<int>();
        public static List<int> lst = new List<int>();
        public static int[] myInt;

        public static void Main(string[] args)
        {
            //Console.WriteLine("Enter number to sort by using quick sort");
            //string lstChar = Console.ReadLine();
            string lstChar = "5,2,8,7,4,1,7,6";
            string[] str = lstChar.Split(',').ToArray();
            foreach (var s in str)
            {
                lstInt.Add(Convert.ToInt32(s));
            }

            // int[] sortedArray = MergeSort_Recursive(lstInt.ToArray());

            // List<int> sortedArray2 = QuickSort(lstInt.ToArray());

            // List<int> lstBubbleSort = BubbleSort(lstInt);

            //List<int> lstInsertionSort = InsertionSort(lstInt);

            //List<int> lstInsertionSort = SelectionSort(lstInt);

            List<int> lstHeapSort = HeapSort(lstInt);
                 
            foreach (var s in lstHeapSort)
                Console.WriteLine(s);

            Console.ReadLine();
        }

        static List<int> HeapSort(List<int> lstInt)
        { 
            
            List<int> heapSort = BuildHeap(lstInt);

            lst.Add(heapSort[0]);
            heapSort[0]=heapSort[heapSort.Count()-1];
            heapSort.RemoveAt(heapSort.Count()-1);
            if (heapSort.Count != 1)
            {
                HeapSort(heapSort);
            }
            else
            {
                lst.Add(heapSort[0]);
            }

            return lst;
        }

        static List<int> BuildHeap(List<int> lstBuildHeap)
        { 
            for (int i = lstBuildHeap.Count()-1; i >= 0; i--)
			{
                int parent1=(i-1)/2;
                //int parent2 = (i - 2) / 2;

                if (parent1 >= 0)
                {
                    if (lstBuildHeap[i] < lstBuildHeap[parent1])
                    {
                        lstBuildHeap[i] = lstBuildHeap[i] + lstBuildHeap[parent1];
                        lstBuildHeap[parent1] = lstBuildHeap[i] - lstBuildHeap[parent1];
                        lstBuildHeap[i] = lstBuildHeap[i] - lstBuildHeap[parent1];
                    }
                
                    if (lstBuildHeap[i] < lstBuildHeap[parent1])
                    {
                        lstBuildHeap[i] = lstBuildHeap[i] + lstBuildHeap[parent1];
                        lstBuildHeap[parent1] = lstBuildHeap[i] - lstBuildHeap[parent1];
                        lstBuildHeap[i] = lstBuildHeap[i] - lstBuildHeap[parent1];
                    }    
                }
			}

            return lstBuildHeap;
        }

        static List<int> QuickSort(int[] numbers)
        {
            int leftPointer = 0;
            int rightPointer = numbers.Count() - 1;
            int pivotValue = numbers[0];
            int pivotIndex = 0;
            bool leftFlag = false;
            bool rightFlag = true;
            List<int> lst1 = new List<int>();
            List<int> lst2 = new List<int>();


            while (rightPointer >= leftPointer)
            {
                if (rightFlag)
                {
                    if (pivotValue > numbers[rightPointer])
                    {
                        numbers[leftPointer] = numbers[rightPointer];
                        leftPointer++;
                        leftFlag = true;
                        rightFlag = false;
                    }
                    else
                    {
                        rightPointer--;
                        continue;
                    }
                }
                else if (leftFlag)
                {
                    if (pivotValue < numbers[leftPointer])
                    {
                        numbers[rightPointer] = numbers[leftPointer];
                        rightPointer--;
                        leftFlag = false;
                        rightFlag = true;
                    }
                    else
                    {
                        leftPointer++;
                    }
                }
            }

            if (rightFlag)
            {
                numbers[leftPointer] = pivotValue;
                pivotIndex = leftPointer;
            }
            else
            {
                numbers[rightPointer] = pivotValue;
                pivotIndex = rightPointer;
            }

            lst1 = numbers.Take(pivotIndex).ToList();
            lst2 = numbers.Skip(pivotIndex + 1).ToList();

            if (lst1.Count() > 1)
                lst1 = QuickSort(lst1.ToArray());

            if (lst2.Count() > 1)
                lst2 = QuickSort(lst2.ToArray());

            lst1.Add(pivotValue);
            lst1.AddRange(lst2);

            return lst1;
        }

        static int[] MergeSort_Recursive(int[] numbers)
        {
            int mid = numbers.Count() / 2;

            if (mid != 0)
            {
                int[] Array1 = numbers.Take(mid).ToArray();
                int[] Array2 = numbers.Skip(mid).ToArray();

                Array1 = MergeSort_Recursive(Array1);
                Array2 = MergeSort_Recursive(Array2);

                return MergeSort(Array1, Array2);
            }

            return numbers;
        }

        static int[] MergeSort(int[] left, int[] right)
        {
            List<int> numbers = new List<int>();
            int i = 0;
            int j = 0;


            while (i < left.Count() || j < right.Count())
            {
                if (j >= right.Count())
                {
                    numbers.Add(left[i]);
                    i++;
                    continue;
                }
                else if (i >= left.Count())
                {
                    numbers.Add(right[j]);
                    j++;
                    continue;
                }
                if (left[i] < right[j])
                {
                    numbers.Add(left[i]);
                    i++;
                }
                else
                {
                    numbers.Add(right[j]);
                    j++;
                }

            }
            return numbers.ToArray();
        }

        static List<int> BubbleSort(List<int> bubbleSort)
        {
            int temp = 0;
            bool flag = false;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < bubbleSort.Count() - 1; i++)
                {
                    if (bubbleSort[i] > bubbleSort[i + 1])
                    {
                        temp = bubbleSort[i];
                        bubbleSort[i] = bubbleSort[i + 1];
                        bubbleSort[i + 1] = temp;
                        flag = false;
                    }
                }
            }

            return bubbleSort;
        }

        static List<int> InsertionSort(List<int> lstInt)
        {
            int temp = 0;

            bool swap = false;
            for (int i = 0; i < lstInt.Count; i++)
            {
                swap = false;
                for (int j = 0; j <= i; j++)
                {
                    if (swap)
                    {
                        temp = lstInt[j] + temp;
                        lstInt[j] = temp - lstInt[j];
                        temp = temp - lstInt[j];
                    }
                    else if (lstInt[i] < lstInt[j])
                    {
                        swap = true;
                        temp = lstInt[j];
                        lstInt[j] = lstInt[i];
                    }
                }
            }
            return lstInt;
        }

        static List<int> SelectionSort(List<int> lstSelectionSort)
        {
            List<int> sortedList = new List<int>();
            //Dictionary<int, int> dict = new Dictionary<int, int>();
            //lstSelectionSort.ForEach(s=>dict.Add(s,0));
            

            int temp = lstSelectionSort[0];
            int tempindex = 0;
            int removeIndex = 0;
            while (sortedList.Count() != lstSelectionSort.Count())
            {
                for (int i = 0; i < lstSelectionSort.Count(); i++)
                {
                    if (lstSelectionSort[i] == 0 )
                        continue;
                    else if (lstSelectionSort[i] < temp)
                    {
                        temp = lstSelectionSort[i];
                        removeIndex = i;
                    }
                }
                sortedList.Add(temp);
                lstSelectionSort[removeIndex] = 0;
                
                while (tempindex<lstSelectionSort.Count() && lstSelectionSort[tempindex] == 0)
                    tempindex++;
                    
                if (tempindex + 1 < lstSelectionSort.Count())
                {
                    
                    temp = lstSelectionSort[tempindex];
                    removeIndex = tempindex;
                }
            }

            return sortedList;
        }


    }
}
