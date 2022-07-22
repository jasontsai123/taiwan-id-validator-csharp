using TaiwanIdValidator.Extensions;
using Xunit;

namespace TaiwanIdValidatorTests.Extensions;

public partial class StringExtensionsTests
{
    [Fact()]
    public void IsGuiNumberValidTest()
    {
        Assert.True(StringExtensions.IsGuiNumberValid(""), "This test needs an implementation");
    }
}