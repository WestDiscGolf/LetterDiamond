using System;
using FluentAssertions;
using Xunit;

namespace LetterDiamond.Tests
{
    public class SpaceCalculationServiceTests
    {
        [Theory]
        [InlineData('E', 'A', 4)]
        [InlineData('A', 'A', 0)]
        [InlineData('C', 'B', 1)]
        public void Test1(char letter, char row, int offset)
        {
            // Arrange

            // Act
            var result = SpaceCalculationService.OffSet(letter, row);

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
            var result = SpaceCalculationService.Gap(row);

            // Assert
            result.Should().Be(gap);
        }
    }
}
