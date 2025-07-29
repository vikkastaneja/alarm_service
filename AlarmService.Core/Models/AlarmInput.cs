namespace AlarmService.Core.Models
{
    public class AlarmInput
    {
        public string AlarmId { get; set; } = string.Empty;
        public double Value { get; set; }
        public double Threshold { get; set; }
        public string Operator { get; set; } = string.Empty;
    }
}