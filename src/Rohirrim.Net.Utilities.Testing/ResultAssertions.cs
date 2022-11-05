using System;
using FluentAssertions;
using FluentAssertions.Equivalency;
using LanguageExt.Common;

namespace Rohirrim.Net.Utilities.Testing;

public static class ResultExtensions
{
    public static ResultAssertions<T> Should<T>(this Result<T> instance)
    {
        return new ResultAssertions<T>(instance);
    }
}

public sealed class ResultAssertions<T>
{
    private readonly Result<T> _instance;

    public ResultAssertions(Result<T> instance)
    {
        _instance = instance;
    }

    public void BeSuccess()
    {
        SuccessBase(x => x.Should().NotBeNull());
    }

    public void BeSuccess(T expected)
    {
        SuccessBase(x => x.Should().BeEquivalentTo(expected));
    }
    
    public void BeSuccess(T expected, Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>> config)
    {
        SuccessBase(x => x.Should().BeEquivalentTo(expected, config));
    }

    public void BeFailure(Exception expected)
    {
        FailureBase(x => x.Should().BeEquivalentTo(expected));
    }

    private void SuccessBase(Action<T> action)
    {
        _instance.IsSuccess.Should().BeTrue();
        _instance.IfSucc(action);
    }
    
    private void FailureBase(Action<Exception> action)
    {
        _instance.IsSuccess.Should().BeFalse();
        _instance.IfFail(action);
    }
}