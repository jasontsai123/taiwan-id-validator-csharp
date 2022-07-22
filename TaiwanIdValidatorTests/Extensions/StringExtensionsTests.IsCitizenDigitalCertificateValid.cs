using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    /// <summary>
    /// 自然人憑證總長度只接受 16 個字元，除此之外應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("AB123456789012345")]
    [InlineData("AB1234567890123")]
    public void IsCitizenDigitalCertificateValidTest_StringsNotWithLength_16_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsCitizenDigitalCertificateValid(input), "Should only accept strings with length 16");
    }
    
    /// <summary>
    /// 自然人憑證正確案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("AB12345678901234")]
    [InlineData("RP47809425348791")]
    public void IsCitizenDigitalCertificateValidTest_InputIsCorrect_ShouldReturnTrue(string input)
    {
        Assert.True(StringExtensions.IsCitizenDigitalCertificateValid(input), "Should return true if the input is correct");
    }
    
    /// <summary>
    /// 自然人憑證錯誤案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("ab12345678901234")]
    [InlineData("A112345678901234")]
    [InlineData("9B12345678901234")]
    [InlineData("AA123456789012J4")]
    public void IsCitizenDigitalCertificateValidTest_InputIsIncorrect_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsCitizenDigitalCertificateValid(input), "Should return false if the input is incorrect");
    }
}