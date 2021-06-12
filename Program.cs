using System;
using System.Collections.Generic;

namespace MergeSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var collectionToSort = GetRandomCollectionOfSize(11);

            var sortedCollection = collectionToSort.MergeSort();
            Console.WriteLine(string.Join(", ", sortedCollection));
        }

        static IList<int> GetRandomCollectionOfSize(int size)
        {
            var randomizer = new Random();
            var collection = new List<int>();
            for (var i = 0; i < size; i++)
            {
                collection.Add(randomizer.Next(100));
            }
            return collection;
        }

        static void PerformanceMeasure(Func<object> action)
        {
            long kbAtExecution = GC.GetTotalMemory(false) / 1024;

            action();

            long kbAfter1 = GC.GetTotalMemory(false) / 1024;
            long kbAfter2 = GC.GetTotalMemory(true) / 1024;

            Console.WriteLine(kbAtExecution + " Started with this kb.");
            Console.WriteLine(kbAfter1 + " After the test.");
            Console.WriteLine(kbAfter1 - kbAtExecution + " Kb Added.");
            Console.WriteLine();
            
            //Console.WriteLine(kbAfter2 + " Kb After Collection");
            //Console.WriteLine(kbAfter2 - kbAfter1 + " Amt. Collected by GC.");
        }
    }
}
