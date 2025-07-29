
using AlarmService.Core.Models;

namespace AlarmService.Core
{
    public class AlarmEvaluator
    {
        public string AlarmId { get; set; } = string.Empty;
        public string Operator { get; set; } = string.Empty;

        public bool Evaluate(double value, double threshold)
        {
            return Operator switch
            {
                "GT" => value > threshold,
                "LT" => value < threshold,
                _ => false
            };
        }

        public bool Evaluate(AlarmInput value, AlarmInput threshold)
        {
            return Evaluate(value.Value, threshold.Value);
        }
    }
}
