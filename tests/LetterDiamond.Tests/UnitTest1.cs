using System;
using FluentAssertions;
using Xunit;

namespace LetterDiamond.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData('E', 'A', 4)]
        [InlineData('A', 'A', 0)]
        [InlineData('C', 'B', 1)]
        public void Test1(char letter, char row, int offset)
        {
            // Arrange

            // Act
            var result = OffSetProcessor.Process(letter, row);

            // Assert
            result.Should().Be(offset);
        }

        [Theory]
        [InlineData('E', 'A', 0)]
        [InlineData('E', 'D', 5)]
        [InlineData('E', 'E', 7)]
        [InlineData('C', 'B', 1)]
        [InlineData('C', 'C', 3)]
        public void GapTest(char letter, char row, int gap)
        {
            // Arrange

            // Act
            var result = GapProcessor.Process(letter, row);

            // Assert
            result.Should().Be(gap);
        }
    }
}
