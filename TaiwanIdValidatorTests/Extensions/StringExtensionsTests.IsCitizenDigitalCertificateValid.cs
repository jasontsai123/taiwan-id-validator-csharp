using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    [Fact()]
    public void IsCitizenDigitalCertificateValidTest()
    {
        Assert.True(StringExtensions.IsCitizenDigitalCertificateValid(""), "This test needs an implementation");
    }
}