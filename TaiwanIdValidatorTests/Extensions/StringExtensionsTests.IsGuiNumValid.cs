using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    /// <summary>
    /// 統編總長度只接受 8 位數字，除此之外應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("1234567")]
    [InlineData("123456789")]
    public void IsGuiNumberValidTest_StringsNotWithLength_8_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsGuiNumberValid(input), "Should only accept strings with length 8");
    }
    
    /// <summary>
    /// 統編正確案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("12345675")]
    [InlineData("12345676")]
    public void IsGuiNumberValidTest_InputIsCorrect_ShouldReturnTrue(string input)
    {
        Assert.True(StringExtensions.IsGuiNumberValid(input), "Should return true if the input is correct");
    }
    
    /// <summary>
    /// 統編錯誤案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("1234567")]
    [InlineData("123456789")]
    [InlineData("12345678")]
    public void IsGuiNumberValidTest_InputIsIncorrect_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsGuiNumberValid(input), "Should return false if the input is incorrect");
    }
}