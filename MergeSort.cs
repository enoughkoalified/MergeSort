using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortAlgorithm
{
    internal class MergeSort : ICustomSort
    {
        public IList<T> Sort<T>(IList<T> collection) where T : IComparable<T>
        {
            if (collection == null)
                throw new NullReferenceException("Merge Sort Collection is null");

            if (collection.Count == 0)
                return collection;

            if (collection.Count == 1)
            {
                return collection;
            }

            if (collection.Count == 2)
            {
                if (collection[1].CompareTo(collection[0]) < 0)
                {
                    collection.Swap(0, 1);
                }
                return collection;
            }

            var leftPart = Sort(collection.Take(collection.Count / 2).ToList());
            var rightPart = Sort(collection.Skip(collection.Count / 2).Take(collection.Count - collection.Count / 2).ToList());
            return Merge(leftPart, rightPart);
        }

        private IList<T> Merge<T>(IList<T> leftPart, IList<T> rightPart) where T : IComparable<T>
        {
            var mergeResultCollection = new List<T>();

            while (leftPart.Count() != 0 && rightPart.Count() != 0)
            {
                if (leftPart[0].CompareTo(rightPart[0]) < 0)
                {
                    MoveFirstElement(leftPart, mergeResultCollection);
                }
                else
                {
                    MoveFirstElement(rightPart, mergeResultCollection);
                }
            }
            if (leftPart.Count == 0)
            {
                mergeResultCollection.AddRange(rightPart);
            }
            else
            {
                mergeResultCollection.AddRange(leftPart);
            }

            return mergeResultCollection;
        }

        private void MoveFirstElement<T>(IList<T> sourceList, IList<T> destinationList)
        {
            destinationList.Add(sourceList[0]);
            sourceList.RemoveAt(0);
        }
    }
}