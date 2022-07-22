using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    /// <summary>
    /// 電子發票捐贈碼總長度為 3~7 碼，不在這個範圍內應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("00")]
    [InlineData("12345678")]
    [InlineData("ab3456")]
    public void IsEInvoiceDonateCodeValidTest_NumberNotWithLengthBetween_7_And_3_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsEInvoiceDonateCodeValid(input), "Should have length 3~7");
    }
    
    /// <summary>
    /// 電子發票捐贈碼正確案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("001")]
    [InlineData("10001")]
    [InlineData("2134567")]
    public void IsEInvoiceDonateCodeValidTest_InputIsCorrect_ShouldReturnTrue(string input)
    {
        Assert.True(StringExtensions.IsEInvoiceDonateCodeValid(input), "Should return true if the input is correct");
    }
}