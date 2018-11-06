using System;
namespace Remind
{
    public class RandomTimeGenerator
    {
        public RandomTimeGenerator()
        {

        }

        public int[] RandomHourMinute(int earliestHour = 0, int latestHour = 23, int earliestMin = 0, int latestMin = 59)
        {
            Random rando = new Random();
            var hour = rando.Next(earliestHour, latestHour);
            var minute = rando.Next(earliestMin, latestMin);
            return new int[] { hour, minute };
        }
    }
}
