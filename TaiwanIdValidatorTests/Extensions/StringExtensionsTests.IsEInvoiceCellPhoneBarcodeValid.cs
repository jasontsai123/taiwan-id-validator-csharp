using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    [Fact()]
    public void IsEInvoiceCellPhoneBarcodeValidTest()
    {
        Assert.True(StringExtensions.IsEInvoiceCellPhoneBarcodeValid(""), "This test needs an implementation");
    }
}