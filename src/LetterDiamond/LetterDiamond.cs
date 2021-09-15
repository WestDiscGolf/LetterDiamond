using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

public class LetterDiamond : Command<LetterDiamond.Settings>
{
    private readonly ISpaceCalculationService _spaceCalculationService;

    public sealed class Settings : CommandSettings
    {
        [Description("Which LetterDiamond would you like to create?")]
        [CommandArgument(0, "[Letter]")]
        public string? Letter { get; init; }
    }

    public LetterDiamond(ISpaceCalculationService spaceCalculationService)
    {
        _spaceCalculationService = spaceCalculationService;
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        // validation the value entered is a char, between A and Z
        if (!char.IsLetter(settings.Letter[0]))
        {
            throw new NotValidLetterException($"Unable to process '{settings.Letter[0]}' as a valid alphabetic value.");
        }

        if (settings.Letter.Length > 1)
        {
            throw new NotValidLetterException($"Unable to process '{settings.Letter}' as only single alphabetic values are valid.");
        }

        if (char.IsLetter(settings.Letter[0]))
        {
            Console.WriteLine("Selected Letter: " + settings.Letter);
            Console.WriteLine("--------------------------------");
            var c = char.ToUpper(settings.Letter[0]);

            var index = c.GetIndex();

            for (var i = 0; i <= index; i++)
            {
                OutputDisplay(i, c);
            }
            for (var i = index - 1; i >= 0; i--)
            {
                OutputDisplay(i, c);
            }
        }

        return 0;
    }

    private void OutputDisplay(int i, char c)
    {
        // we're on the first letter 'A'
        var aDelta = 'A' + i;

        var output = char.ConvertFromUtf32(aDelta);

        var offset = _spaceCalculationService.OffSet(c, (char)aDelta);
        var gap = _spaceCalculationService.Gap((char)aDelta);

        OutputGap(offset);
        Console.Write(output);

        if (aDelta > (int)'A')
        {
            OutputGap(gap);
            Console.Write(output);
        }

        Console.WriteLine();
    }

    private void OutputGap(int numberOfCharacters)
    {
        for (var g = 0; g < numberOfCharacters; g++)
        {
            Console.Write(' ');
        }
    }
}