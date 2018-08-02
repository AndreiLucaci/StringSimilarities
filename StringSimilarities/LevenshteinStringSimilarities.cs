using System.Collections.Generic;
using System.Linq;

namespace StringSimilarities
{
    /// <inheritdoc />
    public class LevenshteinStringSimilarities : IStringSimilarities
    {
        /// <inheritdoc />
        public decimal DetermineSimilarities(string first, string second)
        {
            // validate arguments
            ValidateArguments(first, second);

            var distance = ComputeDistance(first, second);

            var percentage = ComputePercentage(first, second, distance);

            return percentage;
        }

        private static int ComputeDistance(string first, string second)
        {
            // create distance arrays
            var firstArrayDistance = CreateArrayDistance(second.Length);
            var secondArrayDistance = CreateArrayDistance(second.Length);

            // initialize distance array
            InitializeFirstArrayDistances(second, firstArrayDistance);

            // compute the distance
            firstArrayDistance = ComputeDistances(first, second, secondArrayDistance, firstArrayDistance);

            // return the result
            return firstArrayDistance.Last();
        }

        private static decimal ComputePercentage(string first, string second, int distance)
        {
            var maxLength = new[] {first.Length, second.Length}.Max();
            var result = (decimal)maxLength - distance;

            return result / maxLength * 100;
        }

        private static int[] CreateArrayDistance(int stringLength)
        {
            return new int[stringLength + 1];
        }

        private static int[] ComputeDistances(string first, string second, int[] secondArrayDistance,
            int[] firstArrayDistance)
        {
            for (var i = 0; i < first.Length; i++)
            {
                secondArrayDistance[0] = i + 1;

                for (var j = 0; j < second.Length; j++)
                {
                    var delCost = ComputeDeletionCost(firstArrayDistance, j);
                    var insCost = ComputeInsertionCost(secondArrayDistance, j);
                    var subConst = ComputeSubstitutionCost(first, second, i, j, firstArrayDistance);
                    secondArrayDistance[j + 1] = ComputeMinimum(delCost, insCost, subConst);
                }

                firstArrayDistance = SwapArrays(firstArrayDistance, ref secondArrayDistance);
            }

            return firstArrayDistance;
        }

        private static void InitializeFirstArrayDistances(string second, IList<int> firstArrayDistance)
        {
            for (var i = 0; i < second.Length; i++)
            {
                firstArrayDistance[i] = i;
            }
        }

        private static void ValidateArguments(string first, string second)
        {
            if (string.IsNullOrEmpty(first))
            {
                throw new System.ArgumentNullException(nameof(first));
            }

            if (string.IsNullOrEmpty(second))
            {
                throw new System.ArgumentNullException(nameof(second));
            }
        }

        private static int[] SwapArrays(int[] firstArrayDistance, ref int[] secondArrayDistance)
        {
            var temp = firstArrayDistance;
            firstArrayDistance = secondArrayDistance;
            secondArrayDistance = temp;
            return firstArrayDistance;
        }

        private static int ComputeMinimum(int delCost, int insCost, int subConst)
        {
            return new[] {delCost, insCost, subConst}.Min();
        }

        private static int ComputeSubstitutionCost(string first, string second, int i, int j, IReadOnlyList<int> firstArrayDistance)
        {
            return Equals(first[i], second[j]) ? firstArrayDistance[j] : firstArrayDistance[j] + 1;
        }

        private static int ComputeInsertionCost(IReadOnlyList<int> secondArrayDistance, int j)
        {
            return secondArrayDistance[j] + 1;
        }

        private static int ComputeDeletionCost(IReadOnlyList<int> firstArrayDistance, int j)
        {
            return firstArrayDistance[j + 1] + 1;
        }
    }
}
