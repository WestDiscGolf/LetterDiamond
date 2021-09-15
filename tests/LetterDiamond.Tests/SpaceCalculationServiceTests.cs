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
            var sut = new SpaceCalculationService();

            // Act
            var result = sut.OffSet(letter, row);

            // Assert
            result.Should().Be(offset);
        }

        [Theory]
        [InlineData('E', 0)]
        [InlineData('E', 5)]
        [InlineData('E', 7)]
        [InlineData('C', 1)]
        [InlineData('C', 3)]
        public void GapTest(char row, int gap)
        {
            // Arrange
            var sut = new SpaceCalculationService();

            // Act
            var result = sut.Gap(row);

            // Assert
            result.Should().Be(gap);
        }
    }
}
