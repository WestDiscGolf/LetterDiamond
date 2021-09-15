using System;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

var app = new CommandApp<LetterDiamond>();
await app.RunAsync(args);

public static class SpaceCalculationService
{
    public static int OffSet(char letter, char row)
    {
        var index = letter.GetIndex();

        index -= row.GetIndex();

        // todo: check for less than zero

        return index;
    }

    public static int Gap(char letter, char row)
    {
        // zero indexed row count; B is 1
        var rowCount = row.GetIndex();

        if (rowCount > 0)
        {
            return rowCount + (rowCount - 1);
        }

        return rowCount;
    }
}

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

/// <summary>
/// Exception class to throw when the required letter char is not valid.
/// </summary>
public class NotValidLetterException : Exception
{
    public NotValidLetterException(string message)
        : base(message)
    {
    }
}

public class LetterDiamond : Command<LetterDiamond.Settings>
{
    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        // validation the value entered is a char, between A and Z

        Console.WriteLine("Selected Answer: " + settings.Letter);

        // you can "increment" the letter

        if (settings.Letter?.Length == 1 && char.IsLetter(settings.Letter[0]))
        {
            var c = char.ToUpper(settings.Letter[0]);

            var index = c.GetIndex();

            for (var i = 0; i <= index; i++)
            {
                // we're on the first letter 'A'
                var a = (int)'A';
                var aDelta = a + i;

                var output = char.ConvertFromUtf32(aDelta);

                var offset = SpaceCalculationService.OffSet(c, (char)aDelta);
                var gap = SpaceCalculationService.Gap(c, (char)aDelta);

                for (var off = 0; off < offset; off++) { Console.Write(' '); }
                Console.Write(output);

                if (aDelta > (int)'A')
                {
                    for (var g = 0; g < gap; g++) { Console.Write(' '); }
                    Console.Write(output);
                }

                Console.WriteLine();
            }
            for (var i = index - 1; i >= 0; i--)
            {
                // we're on the first letter 'A'
                var a = (int)'A';
                var aDelta = a + i;

                var output = char.ConvertFromUtf32(aDelta);

                var offset = SpaceCalculationService.OffSet(c, (char)aDelta);
                var gap = SpaceCalculationService.Gap(c, (char)aDelta);

                for (var off = 0; off < offset; off++) { Console.Write(' '); }
                Console.Write(output);

                if (aDelta > (int)'A')
                {
                    for (var g = 0; g < gap; g++) { Console.Write(' '); }
                    Console.Write(output);
                }

                Console.WriteLine();
            }

        }

        return 0;
    }

    public sealed class Settings : CommandSettings
    {
        [Description("Which LetterDiamond would you like to create?")]
        [CommandArgument(0, "[Letter]")]
        public string? Letter { get; init; }
    }
}
