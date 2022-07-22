using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    [Fact()]
    public void IsEInvoiceDonateCodeValidTest()
    {
        Assert.True(StringExtensions.IsEInvoiceDonateCodeValid(""), "This test needs an implementation");
    }
}