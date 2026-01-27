namespace HomerServer.ExtApi.models.NetData;

public class NetDataUpTime
{
    public DateTime Time { get; set; }
    public UptimeDuration UpTime { get; set; }

    public NetDataUpTime()
    {
        Time = DateTime.UtcNow;
        UpTime = new();
    }
}

public class UptimeDuration
{
    public int Years { get; }
    public int Months { get; }
    public int Days { get; }
    public int Hours { get; }
    public int Minutes { get; }
    public int Seconds { get; }

    public UptimeDuration()
    {
        Years = 0;
        Days = 0;
        Hours = 0;
        Minutes = 0;
        Seconds = 0;
    }

    public UptimeDuration(
        int years,
        int months,
        int days,
        int hours,
        int minutes,
        int seconds)
    {
        Years = years;
        Months = months;
        Days = days;
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public UptimeDuration(long totalSeconds)
    {
        const int SecondsPerMinute = 60;
        const int SecondsPerHour = 60 * SecondsPerMinute;
        const int SecondsPerDay = 24 * SecondsPerHour;
        const int SecondsPerMonth = 30 * SecondsPerDay;
        const int SecondsPerYear = 365 * SecondsPerDay;

        Years = (int)(totalSeconds / SecondsPerYear);
        totalSeconds %= SecondsPerYear;

        Months = (int)(totalSeconds / SecondsPerMonth);
        totalSeconds %= SecondsPerMonth;

        Days = (int)(totalSeconds / SecondsPerDay);
        totalSeconds %= SecondsPerDay;

        Hours = (int)(totalSeconds / SecondsPerHour);
        totalSeconds %= SecondsPerHour;

        Minutes = (int)(totalSeconds / SecondsPerMinute);
        Seconds = (int)(totalSeconds % SecondsPerMinute);
    }
}