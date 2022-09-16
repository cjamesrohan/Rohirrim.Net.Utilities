using System;
using FluentAssertions;
using FluentAssertions.Equivalency;

namespace Rohirrim.Net.Utilities;

public sealed class ResultAssertions<T>
{
    private readonly Result<T> _instance;

    public ResultAssertions(Result<T> instance)
    {
        _instance = instance;
    }

    public AndConstraint<ResultAssertions<T>> BeSuccess(T expected, Func<EquivalencyAssertionOptions<T>, EquivalencyAssertionOptions<T>>? config = null)
    {
        _instance.IsSuccess.Should().BeTrue();
        _instance.Error.Should().BeNull();
        if (config is not null)
            _instance.Value.Should().BeEquivalentTo(expected, config);
        else
            _instance.Value.Should().BeEquivalentTo(expected);
        return new AndConstraint<ResultAssertions<T>>(this);
    }

    public AndConstraint<ResultAssertions<T>> BeFailure(ApiError expected)
    {
        _instance.IsSuccess.Should().BeFalse();
        _instance.Error.Should().BeEquivalentTo(expected);
        _instance.Value.Should().Be(default (T));
        return new AndConstraint<ResultAssertions<T>>(this);
    }
}