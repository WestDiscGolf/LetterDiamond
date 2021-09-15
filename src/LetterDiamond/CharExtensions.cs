public static class CharExtensions
{
    /// <summary>
    /// Based on original implementation from https://stackoverflow.com/a/25728703/33116
    /// </summary>
    /// <param name="letter">The target letter character.</param>
    /// <returns>The index of the target letter in the alphabet in zero based index.</returns>
    public static int GetIndex(this char letter)
    {
        if (char.IsLetter(letter) && (letter >= 'A' && letter <= 'z'))
        {
            return char.ToUpper(letter) - 'A';
        }

        throw new NotValidLetterException($"Unable to process '{letter}' as a valid alphabetic value");
    }
}