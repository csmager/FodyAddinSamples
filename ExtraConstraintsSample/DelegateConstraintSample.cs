﻿using System;
using System.Diagnostics;
using System.Security;
using ExtraConstraints;
using Xunit;

public class DelegateConstraintSample
{
    [Fact]
    public void InvalidDelegateConstraint()
    {
        var exception = Assert.Throws<VerificationException>(() => MethodWithDelegateConstraint(10));
        Assert.Equal("Method DelegateConstraintSample.MethodWithDelegateConstraint: type argument 'System.Int32' violates the constraint of type parameter 'T'.", exception.Message);
    }

    [Fact]
    public void ValidDelegateConstraint()
    {
        MethodWithDelegateConstraint<Action>(() => Debug.WriteLine("foo"));
    }

    void MethodWithDelegateConstraint<[DelegateConstraint(typeof(Action))] T>(T value)
    {
    }
}