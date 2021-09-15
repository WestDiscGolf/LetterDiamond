using System;
using FluentAssertions;
using Xunit;

namespace LetterDiamond.Tests
{
    public class CharExtensionsTests
    {
        [Theory]
        [InlineData('A', 0)]
        [InlineData('B', 1)]
        [InlineData('C', 2)]
        [InlineData('D', 3)]
        [InlineData('E', 4)]
        [InlineData('F', 5)]
        [InlineData('G', 6)]
        [InlineData('H', 7)]
        [InlineData('I', 8)]
        [InlineData('J', 9)]
        [InlineData('K', 10)]
        [InlineData('L', 11)]
        [InlineData('M', 12)]
        [InlineData('N', 13)]
        [InlineData('O', 14)]
        [InlineData('P', 15)]
        [InlineData('Q', 16)]
        [InlineData('R', 17)]
        [InlineData('S', 18)]
        [InlineData('T', 19)]
        [InlineData('U', 20)]
        [InlineData('V', 21)]
        [InlineData('W', 22)]
        [InlineData('X', 23)]
        [InlineData('Y', 24)]
        [InlineData('Z', 25)]
        [InlineData('a', 0)]
        [InlineData('b', 1)]
        [InlineData('c', 2)]
        [InlineData('d', 3)]
        [InlineData('e', 4)]
        [InlineData('f', 5)]
        [InlineData('g', 6)]
        [InlineData('h', 7)]
        [InlineData('i', 8)]
        [InlineData('j', 9)]
        [InlineData('k', 10)]
        [InlineData('l', 11)]
        [InlineData('m', 12)]
        [InlineData('n', 13)]
        [InlineData('o', 14)]
        [InlineData('p', 15)]
        [InlineData('q', 16)]
        [InlineData('r', 17)]
        [InlineData('s', 18)]
        [InlineData('t', 19)]
        [InlineData('u', 20)]
        [InlineData('v', 21)]
        [InlineData('w', 22)]
        [InlineData('x', 23)]
        [InlineData('y', 24)]
        [InlineData('z', 25)]
        public void GetIndex_HappyPath(char c, int expectedIndex)
        {
            // Arrange
            
            // Act
            var result = c.GetIndex();

            // Assert
            result.Should().Be(expectedIndex);
        }

        [Theory]
        [InlineData('{')]
        [InlineData('|')]
        [InlineData('}')]
        [InlineData('~')]
        [InlineData('')]
        [InlineData('€')]
        [InlineData('')]
        [InlineData('‚')]
        [InlineData('ƒ')]
        [InlineData('„')]
        [InlineData('…')]
        [InlineData('†')]
        [InlineData('‡')]
        [InlineData('ˆ')]
        [InlineData('‰')]
        [InlineData('Š')]
        [InlineData('‹')]
        [InlineData('Œ')]
        [InlineData('')]
        [InlineData('Ž')]
        public void GetIndex_Throws(char c)
        {
            // only testing a subset as wouldn't add much value testing the entire unicode set

            // Arrange

            // Act
            Action result = () => c.GetIndex();

            // Assert
            result.Should().Throw<NotValidLetterException>().Which.Message.Should().Be($"Unable to process '{c}' as a valid alphabetic value");
        }
    }
}
