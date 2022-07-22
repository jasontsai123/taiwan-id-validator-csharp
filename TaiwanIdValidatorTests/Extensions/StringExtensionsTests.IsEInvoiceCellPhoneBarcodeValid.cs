using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    /// <summary>
    /// 電子發票手機條碼總長度只接受 8 個字元，除此之外應回傳 False
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("/ABCD1234")]
    [InlineData("/ABCD12")]
    public void IsEInvoiceCellPhoneBarcodeValidTest_StringsNotWithLength_8_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsEInvoiceCellPhoneBarcodeValid(input), "Should only accept strings with length 8");
    }
    
    /// <summary>
    /// 電子發票手機條碼正確案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("/+.-++..")]
    [InlineData("/AAA33AA")]
    [InlineData("/P4SV.-I")]
    [InlineData("/O0O01I1")]
    public void IsEInvoiceCellPhoneBarcodeValidTest_InputIsCorrect_ShouldReturnTrue(string input)
    {
        Assert.True(StringExtensions.IsEInvoiceCellPhoneBarcodeValid(input), "Should return true if the input is correct");
    }
    
    /// <summary>
    /// 電子發票手機條碼錯誤案例
    /// </summary>
    /// <param name="input"></param>
    [Theory()]
    [InlineData("/ABCD12;")]
    [InlineData("/ABCD$12")]
    [InlineData("/ab12345")]
    public void IsEInvoiceCellPhoneBarcodeValidTest_InputIsIncorrect_ShouldReturnFalse(string input)
    {
        Assert.False(StringExtensions.IsEInvoiceCellPhoneBarcodeValid(input), "Should return false if the input is incorrect");
    }
}