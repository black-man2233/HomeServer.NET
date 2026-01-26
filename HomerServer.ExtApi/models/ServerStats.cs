using System.Net;

namespace HomerServer.ExtApi.models;

public class ServerStats
{
    public double CPU { get; set; }
    public double RAM { get; set; }
    public string UpTime { get; set; }
    public string Ip { get; set; }

    public ServerStats()
    {
        UpTime = "0 sec";
        Ip = "172.0.0.1";
        RAM = 00;
        CPU = 00;
    }
}
