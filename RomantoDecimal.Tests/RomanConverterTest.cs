using System;
using FluentAssertions;
using Xunit;
using RomantoDecimal.App;
using System.Collections.Generic;

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
      //Given
      string romanNum = "X";
      //When
      int integerNum = RomanConverter.ConvertRoman(romanNum);
      //Then
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
      action.Should().Throw<ApplicationException>().WithMessage("Number exceeds max value of 3999");
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

    [Theory]
    [InlineData("ix", 9)]
    [InlineData("MdClXvIi", 1667)]
    [InlineData("Viii", 8)]
    public void Should_ReturnNum_EvenWithLowerCaseParams(string romanNum, int ans)
    {
      //Given
      //When
      int integerNum = RomanConverter.ConvertRoman(romanNum);
      //Then
      integerNum.Should().Be(ans);
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

    [Theory]
    [InlineData("IIX")]
    [InlineData("LXC")]
    public void Should_ThrowException_WhenGivenInvalidInput(string romanNum)
    {
      //Given
      //When
      Action action = () => RomanConverter.ConvertRoman(romanNum);
      //Then
      action.Should().Throw<KeyNotFoundException>();
    }
  }
}
