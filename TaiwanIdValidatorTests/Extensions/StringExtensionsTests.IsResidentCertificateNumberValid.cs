using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    [Fact()]
    public void IsResidentCertificateNumberValidTest()
    {
        Assert.True(StringExtensions.IsResidentCertificateNumberValid(""), "This test needs an implementation");
    }
}