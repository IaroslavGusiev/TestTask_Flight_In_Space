using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Code.Extensions
{
    public static class EnumerableExtension
    {
        public static T PickRandom<T>(this IEnumerable<T> collection)
        {
            switch (collection)
            {
                case null:
                    return default;
            
                case IList<T> list:
                    return list.Count != 0
                        ? list[Random.Range(0, list.Count)]
                        : default;
            
                case HashSet<T> hashset:
                    return hashset.Count != 0
                        ? hashset.ElementAt(Random.Range(0, hashset.Count))
                        : default;
                default:
                {
                    List<T> actual = collection.ToList();
                    return actual.Count > 0
                        ? actual[Random.Range(0, actual.Count)]
                        : default;
                }
            }
        }
    }
}