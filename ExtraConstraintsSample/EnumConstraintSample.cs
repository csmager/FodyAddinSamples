using System.Security;
using ExtraConstraints;
using Xunit;

public class EnumConstraintSample
{
    [Fact]
    public void InvalidEnumConstraint()
    {
        var exception = Assert.Throws<VerificationException>(() => MethodWithEnumConstraint(10));
        Assert.Equal("Method EnumConstraintSample.MethodWithEnumConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.", exception.Message);
    }

    [Fact]
    public void ValidEnumConstraint()
    {
        MethodWithEnumConstraint(MyEnum.Value);
    }

    void MethodWithEnumConstraint<[EnumConstraint(typeof(MyEnum))] T>(T value)
    {
    }
}