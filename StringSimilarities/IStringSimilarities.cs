namespace StringSimilarities
{
    /// <summary>
    /// String similiarities algorithm: determines the percentage representing the similarities between two given strings
    /// </summary>
    public interface IStringSimilarities
    {
        /// <summary>
        /// Determines the similarities between two given <see cref="string"/>s
        /// </summary>
        /// <param name="first">The first <see cref="string"/> given as input</param>
        /// <param name="second">The seoncd <see cref="string"/> given as input</param>
        /// <returns>The <see cref="decimal"/> value representing the simmilarity percentage between the two <see cref="string"/>s</returns>
        decimal DetermineSimilarities(string first, string second);
    }
}
