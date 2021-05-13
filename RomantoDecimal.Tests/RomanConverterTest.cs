using System;
using FluentAssertions;
using Xunit;
using RomantoDecimal.App;

namespace RomantoDecimal.Tests
{
    public class RomanConverterTest
    {
        [Fact]
        public void Should_ReturnZero_IfParameterIsEmpty()
        {
            //Given
            string romanNum = "";
            //When
            int integerNum = RomanConverter.ConvertRoman(romanNum);
            //Then
            integerNum.Should().Be(0);
        }

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
        [InlineData("MMMCMXCIX", 3999)]
        public void Should_ReturnSubtractionOfNumerals(string romanNum, int answer)
        {
            //Given
            //When
            int integerNum = RomanConverter.ConvertRoman(romanNum);
            //Then
            integerNum.Should().Be(answer);
        }

        [Fact]
        public void Should_ThrowError_WhenNumberExceedsMaxValue()
        {
            //Given
            string romanNum = "MMMMMMMMMMM";

            //When
            Action action = () => RomanConverter.ConvertRoman(romanNum);

            //Then
            action.Should().Throw<ApplicationException>().WithMessage("Number exceeds max value");
        }

        [Fact]
        public void Should_ThrowException_WhenInputIsNull()
        {
            //Given
            string romanNum = null;

            //When
            Action action = () => RomanConverter.ConvertRoman(romanNum);

            //Then
            action.Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void Should_ReturnNum_EvenWithLowerCaseParams()
        {
            //Given
            string romanNum = "ix";
            //When
            int integerNum = RomanConverter.ConvertRoman(romanNum);
            //Then
            integerNum.Should().Be(9);
        }

        [Fact]
        public void Should_ThrowError_WhenNegativeValueIsGiven()
        {
            //Given
            string romanNum = "-V";
            //When
            Action action = () => RomanConverter.ConvertRoman(romanNum);
            //Then
            action.Should().Throw<ApplicationException>().WithMessage("Negative Values Are Invalid");
        }

        [Fact]
        public void Should_ThrowException_WhenGivenInvalidInput()
        {
            // //Given
            // string romanNum = "IIV";
            // //When
            // Action action = () => RomanConverter.ConvertRoman(romanNum);
            // //Then
            // action.Should().Throw<ApplicationException>().WithMessage("Input is invalid");
        }
    }
}
