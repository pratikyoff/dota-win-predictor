using System;
using System.Collections.Generic;
using System.Linq;

namespace WinPredictor
{
    public static class Permutator
    {
        public static List<List<T>> Permute<T>(IEnumerable<T> input)
        {
            if (input.Count() == 1)
                return new List<List<T>>() { input.ToList() };

            var list = input.ToList();
            var first = list.First();
            list.RemoveAt(0);
            var permutations = Permute(list);
            var newPermutations = new List<List<T>>();
            foreach (var permutation in permutations)
            {
                for (int i = 0; i < permutation.Count; i++)
                {
                    var copy = new List<T>(permutation);
                    copy.Insert(i, first);
                    newPermutations.Add(copy);
                }
                var copyOfPermutation = new List<T>(permutation);
                copyOfPermutation.Add(first);
                newPermutations.Add(copyOfPermutation);
            }

            return newPermutations;
        }
    }
}
