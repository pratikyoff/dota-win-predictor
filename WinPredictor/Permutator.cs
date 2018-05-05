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

        public static List<List<int>> PermuteMatch(List<int> matchInput)
        {
            int heroId = matchInput.First();
            var allyPermutations = Permute(matchInput.GetRange(1, 4));
            var enemyPermutations = Permute(matchInput.GetRange(5, 5));
            var isRadiant = matchInput.Last();
            List<List<int>> validPermutations = new List<List<int>>();
            foreach (var allyPermutation in allyPermutations)
            {
                foreach (var enemyPermutation in enemyPermutations)
                {
                    List<int> singlePermutation = new List<int>() { heroId };
                    singlePermutation.AddRange(allyPermutation);
                    singlePermutation.AddRange(enemyPermutation);
                    singlePermutation.Add(isRadiant);
                    validPermutations.Add(singlePermutation);
                }
            }
            return validPermutations;
        }
    }
}
