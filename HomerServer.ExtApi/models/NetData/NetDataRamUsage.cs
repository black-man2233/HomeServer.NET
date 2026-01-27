namespace HomerServer.ExtApi.models.NetData;

public class NetDataRamUsage
{
    public DateTime Time { get; set; }
    public double Free { get; set; }
    public double User { get; set; }
    public double Cached { get; set; }
    public double Buffers { get; set; }

    public NetDataRamUsage()
    {
        Time = DateTime.UtcNow;
        Free = double.NaN;
        User = double.NaN;
        Cached = double.NaN;
        Buffers = double.NaN;
    }
}