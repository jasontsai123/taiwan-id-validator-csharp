using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    /// <summary>
    /// 外來人口統一證號總長度只接受 10 位數字，除此之外應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("AA234567899")]
    [InlineData("AA2345678")]
    public void IsResidentCertificateNumberValidTest_StringsNotWithLength_10_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsResidentCertificateNumberValid(input), "Should only accept strings with length 10");
    }
    
    /// <summary>
    /// 外來人口統一證號前兩碼為英文字，非英文字應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("2123456789")]
    [InlineData("1A23456789")]
    [InlineData("A123456789")]
    public void IsResidentCertificateNumberValidTest_StringsNotBegin_2_EnglishLetter_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsResidentCertificateNumberValid(input), "Should only accept strings Begin with 2 English letters");
    }
    
    /// <summary>
    /// 外來人口統一證號正確案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("AA00000009")]
    [InlineData("AB00207171")]
    [InlineData("AC03095424")]
    [InlineData("BD01300667")]
    [InlineData("CC00151114")]
    [InlineData("HD02717288")]
    [InlineData("TD00251124")]
    public void IsResidentCertificateNumberValidTest_InputIsCorrect_ShouldReturnTrue(string input)
    {
        Assert.True(StringExtensions.IsResidentCertificateNumberValid(input), "Should return true if the input is correct");
    }
    
    /// <summary>
    /// 外來人口統一證號錯誤案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("aa00000009")]
    [InlineData("AA00000000")]
    [InlineData("FG31104091")]
    [InlineData("OY58238842")]
    public void IsResidentCertificateNumberValidTest_InputIsIncorrect_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsResidentCertificateNumberValid(input), "Should return false if the input is incorrect");
    }
}