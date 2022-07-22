using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    [Fact()]
    public void IsNationalIdentificationNumberValidTest()
    {
        Assert.True(StringExtensions.IsNationalIdentificationNumberValid(""), "This test needs an implementation");
    }
}