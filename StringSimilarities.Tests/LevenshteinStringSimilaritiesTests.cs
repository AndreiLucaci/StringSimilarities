using System;
using System.Collections;
using NUnit.Framework;

namespace StringSimilarities.Tests
{
    [TestFixture]
    public class LevenshteinStringSimilaritiesTests
    {
        private IStringSimilarities _sut;

        public static IEnumerable GetDatas()
        {
            yield return new Tuple<string, string, decimal, decimal>("andrei", "ardei", 0.5M, 0.5M);
            yield return new Tuple<string, string, decimal, decimal>("asdfgh", "qwerty", 0.15M, 0.17M);
            yield return new Tuple<string, string, decimal, decimal>("andrei", "andrei", 1M, 1M);
        }

        [SetUp]
        public void SetUp()
        {
            _sut = new LevenshteinStringSimilarities();
        }

        [Test]
        public void Determine_FirstStringIsNull_ThrowsArgumentNullException()
        {
            // arrange

            // act + assert
            Assert.Throws<ArgumentNullException>(() => _sut.DetermineSimilarities(null, null));
        }

        [Test]
        public void Determine_SecondStringIsNull_ThrowsArgumentNullException()
        {
            // arrange

            // act + assert
            Assert.Throws<ArgumentNullException>(() => _sut.DetermineSimilarities("some string", null));
        }

        [Test]
        public void Determine_FirstStringIsEmpty_ThrowsArgumentNullException()
        {
            // arrange

            // act + assert
            Assert.Throws<ArgumentNullException>(() => _sut.DetermineSimilarities(string.Empty, null));
        }

        [Test]
        public void Determine_SecondStringIsEmpty_ThrowsArgumentNullException()
        {
            // arrange

            // act + assert
            Assert.Throws<ArgumentNullException>(() => _sut.DetermineSimilarities("some string", string.Empty));
        }


        [Test]
        [TestCaseSource(nameof(GetDatas))]
        public void Determine_ValidStrings_ComputesCorrectlyTheDistance(Tuple<string, string, decimal, decimal> input)
        {
            // arrange
            var first = input.Item1;
            var second = input.Item2;
            var lowerboundThreshold = input.Item3;
            var upperboundThreshold = input.Item4;

            // act
            var result = _sut.DetermineSimilarities(first, second);

            // assert
            Assert.IsTrue(lowerboundThreshold <= result && result <= upperboundThreshold);
        }
    }
}
