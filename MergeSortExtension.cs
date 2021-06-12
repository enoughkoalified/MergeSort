using System;
using System.Collections.Generic;
namespace MergeSortAlgorithm
{
    internal static class MergeSortExtension
    {
        public static IEnumerable<T> MergeSort<T>(this IList<T> input) where T : IComparable<T>
        {
            return new MergeSort().Sort<T>(input);
        }
    }
}