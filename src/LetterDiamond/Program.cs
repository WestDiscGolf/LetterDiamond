﻿using System;
using Spectre.Console.Cli;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

var app = new CommandApp<LetterDiamond>();
await app.RunAsync(args);

public static class OffSetProcessor
{
    public static int Process(char letter, char row)
    {
        var index = Index(letter);

        index -= Index(row);

        // todo: check for less than zero

        return index;
    }

    /// <summary>
    /// Original implementation from https://stackoverflow.com/a/25728703/33116
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    private static int Index(char letter) => (int)char.ToUpper(letter) - (int)'A';
}

public static class GapProcessor
{
    public static int Process(char letter, char row)
    {
        // zero indexed row count; B is 1
        var rowCount = Index(row);

        if (rowCount > 0)
        {
            return rowCount + (rowCount - 1);
        }

        return rowCount;
    }

    /// <summary>
    /// Original implementation from https://stackoverflow.com/a/25728703/33116
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    private static int Index(char letter) => (int)char.ToUpper(letter) - (int)'A';
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

            var index = Index(c);

            for (var i = 0; i <= index; i++)
            {
                // we're on the first letter 'A'
                var a = (int)'A';
                var aDelta = a + i;

                var output = char.ConvertFromUtf32(aDelta);

                var offset = OffSetProcessor.Process(c, (char)aDelta);
                var gap = GapProcessor.Process(c, (char)aDelta);

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

                var offset = OffSetProcessor.Process(c, (char)aDelta);
                var gap = GapProcessor.Process(c, (char)aDelta);

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

    /// <summary>
    /// Original implementation from https://stackoverflow.com/a/25728703/33116
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
    private static int Index(char letter) => (int)char.ToUpper(letter) - (int)'A';

    public sealed class Settings : CommandSettings
    {
        [Description("Which LetterDiamond would you like to create?")]
        [CommandArgument(0, "[Letter]")]
        public string? Letter { get; init; }
    }
}
