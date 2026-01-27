namespace HomerServer.ExtApi.models.NetData;

public class ServerStats
{
    public string Ip { get; set; }
    public NetDataRamUsage RamUsage { get; set; }
    public NetDataCPUUsage CPUUsage { get; set; }
    public NetDataUpTime UpTime { get; set; }

    public ServerStats()
    {
        Ip = string.Empty;
        RamUsage = new();
        CPUUsage = new();
        UpTime = new();
    }
}
