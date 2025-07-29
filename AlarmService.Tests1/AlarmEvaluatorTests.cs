using AlarmService.Core;
using Xunit;

namespace AlarmService.Tests;

public class AlarmEvaluatorTests
{
    [Fact]
    public void Evaluate_GreaterThan_ReturnsRaised()
    {
        var evaluator = new AlarmEvaluator();
        var input = new AlarmInput
        {
            AlarmId = "OverTemp001",
            Value = 90,
            Threshold = 85,
            Operator = "GreaterThan"
        };

        var result = evaluator.Evaluate(input);

        Assert.Equal("Raised", result.Status);
    }
}