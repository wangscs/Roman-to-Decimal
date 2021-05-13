using System;
using FluentAssertions;
using Xunit;
using RomantoDecimal.App;

namespace RomantoDecimal.Tests
{
    public class RomanConverterTest
    {
        [Fact]
        public void Should_returnDecimalInt()
        {
            //Assemble
            string romanNum = "X";
            //Act
            int integerNum = RomanConverter.ConvertRoman(romanNum);
            //Assert
            integerNum.Should().Be(10);
        }

        [Fact]
        public void Should_ReturnSumOfNumerals()
        {
            //Given
            string romanNum = "XVI";
            //When
            int integerNum = RomanConverter.ConvertRoman(romanNum);
            //Then
            integerNum.Should().Be(16);
        }

        [Theory]
        [InlineData("MCMXLIV", 1944)]
        [InlineData("XIV", 14)]
        public void Should_ReturnSubtractionOfNumerals(string romanNum, int answer)
        {
            //Given
            //When
            int integerNum = RomanConverter.ConvertRoman(romanNum);
            //Then
            integerNum.Should().Be(answer);
        }

        [Fact]
        public void Should_ThrowError_WhenNumberExceedsMax()
        {
            //Given
            int max = 10000;
            string romanNum = "MMMMMMMMMMM";
            // for (int i = 0; i < max / 1000; i++)
            // {
            //     romanNum += "M";
            // }
            //When
            Action action = () => RomanConverter.ConvertRoman(romanNum);

            Console.WriteLine($"Action: {action}");
            //Then
            action.Should().Throw<ApplicationException>();
        }
    }
}
