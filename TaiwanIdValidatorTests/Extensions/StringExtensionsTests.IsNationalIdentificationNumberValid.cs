using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    /// <summary>
    /// 身分證字號總長度只接受 10 個字元，除此之外應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("A1234567899")]
    [InlineData("A12345678")]
    public void IsNationalIdentificationNumberValidTest_StringsNotWithLength_10_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsNationalIdentificationNumberValid(input), "Should only accept strings with length 10");
    }
    
    /// <summary>
    /// 身分證字號第一碼為英文字，非英文字應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("2123456789")]
    [InlineData("1123456789")]
    public void IsNationalIdentificationNumberValidTest_StringsNotBeginWithEnglishLetter_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsNationalIdentificationNumberValid(input), "Should only accept strings Begin with English letter");
    }
    
    /// <summary>
    /// 身分證字號第一個數字為 1 或 2，除此之外應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("A323456789")]
    [InlineData("A423456789")]
    public void IsNationalIdentificationNumberValidTest_FirstNumberIsNot_1_Or_2_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsNationalIdentificationNumberValid(input), "Should return false if the first number is not 1 or 2");
    }
    
    /// <summary>
    /// 身分證字號正確案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("A123456789")]
    [InlineData("F131104093")]
    [InlineData("O158238845")]
    [InlineData("N116247806")]
    [InlineData("L122544270")]
    [InlineData("C180661564")]
    [InlineData("Y123456788")]
    [InlineData("A800000014")]
    [InlineData("A900000016")]
    [InlineData("A870000015")]
    [InlineData("A970000017")]
    [InlineData("A880000018")]
    [InlineData("A980000010")]
    [InlineData("A890000011")]
    [InlineData("A990000013")]
    public void IsNationalIdentificationNumberValidTest_InputIsCorrect_ShouldReturnTrue(string input)
    {
        Assert.True(StringExtensions.IsNationalIdentificationNumberValid(input), "Should return true if the input is correct");
    }
    
    /// <summary>
    /// 身分證字號錯誤案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("a123456789")]
    [InlineData("A123456788")]
    [InlineData("F131104091")]
    [InlineData("O158238842")]
    public void IsNationalIdentificationNumberValidTest_InputIsIncorrect_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsNationalIdentificationNumberValid(input), "Should return false if the input is incorrect");
    }
}