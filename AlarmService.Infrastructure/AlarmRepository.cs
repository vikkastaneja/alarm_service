
using AlarmService.Core;
using System;

namespace AlarmService.Infrastructure
{
    public class AlarmRepository
    {
        public bool SaveResult(string alarmId, bool status)
        {
            Console.WriteLine($"Alarm {alarmId} evaluated as {status}");
            return true;
        }
    }
}
