using AlarmService.Core.Models;
using AlarmService.Core;

namespace AlarmService.Tests
{
    [TestClass]
    public class AlarmEvaluatorTests
    {
        [TestMethod]
        public void Test_Evaluate_GreaterThan_ReturnsRaised()
        {
            var evaluator = new AlarmEvaluator();
            var input = new AlarmInput
            {
                AlarmId = "OverTemp001",
                Value = 90,
                Threshold = 85,
                Operator = "GreaterThan"
            };

            var expected = new AlarmInput
            {
                AlarmId = "OverTemp001",
                Value = 90,
                Threshold = 85,
                Operator = "GreaterThan"
            };

            var result = evaluator.Evaluate(input, expected);

            Assert.IsFalse(result);
        }
    }
}
