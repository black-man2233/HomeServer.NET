namespace HomerServer.ExtApi.models.NetData;

/// <summary>
/// Represents CPU utilization metrics retrieved from Netdata's system.cpu chart.
/// All values (except Time) are represented as a percentage (%) of total CPU capacity.
/// </summary>
public class NetDataCPUUsage
{
    /// <summary>
    /// Unix timestamp (seconds) for the data collection point.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Percentage of time spent running a virtual CPU for guest operating systems with niced priority.
    /// </summary>
    public double GuestNice { get; set; }

    /// <summary>
    /// Percentage of time spent running a virtual CPU for guest operating systems.
    /// </summary>
    public double Guest { get; set; }

    /// <summary>
    /// Percentage of time the virtual CPU waited for a real CPU while the hypervisor was servicing another processor.
    /// </summary>
    public double Steal { get; set; }

    /// <summary>
    /// Percentage of time spent servicing software interrupts.
    /// </summary>
    public double Softirq { get; set; }

    /// <summary>
    /// Percentage of time spent servicing hardware interrupts.
    /// </summary>
    public double Irq { get; set; }

    /// <summary>
    /// Percentage of time spent running unprivileged user processes (applications).
    /// </summary>
    public double User { get; set; }

    /// <summary>
    /// Percentage of time spent running kernel-level system processes.
    /// </summary>
    public double System { get; set; }

    /// <summary>
    /// Percentage of time spent running privileged user processes (processes with a positive nice value).
    /// </summary>
    public double Nice { get; set; }

    /// <summary>
    /// Percentage of time the CPU was idle while the system had an outstanding disk I/O request.
    /// </summary>
    public double Iowait { get; set; }

    /// <summary>
    /// Calculates the total percentage of CPU currently in use (Non-Idle).
    /// </summary>
    /// <returns>A value between 0 and 100 representing total load.</returns>

    public double TotalUsagePercentage => (User + System + Nice + Softirq + Irq + Steal + Guest + GuestNice + Iowait);

    public NetDataCPUUsage()
    {
        Time = DateTime.UtcNow;
        GuestNice = double.NaN;
        Guest = double.NaN;
        Steal = double.NaN;
        Softirq = double.NaN;
        Irq = double.NaN;
        User = double.NaN;
        System = double.NaN;
        Nice = double.NaN;
        Iowait = double.NaN;
    }


    /// <summary>
    /// Returns the estimated Idle percentage.
    /// </summary>
    public double GetIdlePercentage()
    {
        return Math.Max(0, 100 - TotalUsagePercentage);
    }
}
