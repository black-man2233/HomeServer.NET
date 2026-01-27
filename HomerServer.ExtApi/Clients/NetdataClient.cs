namespace HomerServer.ExtApi.Clients;

using HomerServer.ExtApi.models;
using HomerServer.ExtApi.models.NetData;
using HomeServer.ExtApi.Utils;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public class NetdataClient
{
    private readonly HttpClient _http;

    public DateTime UnixTimeStampToDateTime { get; private set; }

    public NetdataClient(HttpClient http) => _http = http;

    public void Configure(string baseUrl, string bearerToken, string xAuthToken = "")
    {
        _http.BaseAddress = new Uri(baseUrl);
        if (!string.IsNullOrEmpty(bearerToken))
            _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        if (!string.IsNullOrEmpty(xAuthToken))
            _http.DefaultRequestHeaders.Add("X-Auth-Token", xAuthToken);
    }

    public async Task<ServerStats> GetServerStatsAsync()
    {
        var stats = new ServerStats { Ip = _http.BaseAddress?.Host ?? "Unknown" };

        try
        {
            // 1. Get CPU (system.cpu returns percentage)
            stats.CPUUsage = await this.GetCPUUsage() ?? new();

            // 2. Get RAM (system.ram returns MiB)
            stats.RamUsage = await this.GetRamUsage() ?? new();

            // 3. Get Uptime (system.uptime returns seconds)
            stats.UpTime = await this.GetUpTime() ?? new();

        }
        catch (Exception ex) { System.Console.WriteLine("Exception" + ex.Message); }

        return stats;
    }

    public async Task<NetDataCPUUsage?> GetCPUUsage()
    {
        var response = await _http.GetFromJsonAsync<NetdataResponse>("api/v1/data?chart=system.cpu&after=-1&points=1&format=json");
        if (response is null) return null;
        var cpuData = response?.data.AsEnumerable().ElementAt(0) ?? null;
        if (cpuData is null) return null;

        var result = new NetDataCPUUsage()
        {
            Time = Helpers.UnixTimeStampToDateTime(cpuData.ElementAtOrDefault(0) ?? 00),
            GuestNice = cpuData[1] ?? 00,
            Guest = cpuData[2] ?? 00,
            Steal = cpuData[3] ?? 00,
            Softirq = cpuData[4] ?? 00,
            Irq = cpuData[5] ?? 00,
            User = cpuData[6] ?? 00,
            System = cpuData[7] ?? 00,
            Nice = cpuData[8] ?? 00,
            Iowait = cpuData[9] ?? 00,
        };

        return result;

    }
    public async Task<NetDataRamUsage?> GetRamUsage()
    {
        var response = await _http.GetFromJsonAsync<NetdataResponse>("api/v1/data?chart=system.ram&after=-1&points=1&format=json");
        if (response is null) return null;
        var ramData = response.data.AsEnumerable().ElementAt(0) ?? null;
        if (ramData is null) return null;
        var result = new NetDataRamUsage()
        {
            Time = Helpers.UnixTimeStampToDateTime(ramData.ElementAtOrDefault(0) ?? 00),
            Free = ramData[1] ?? 00,
            User = ramData[2] ?? 00,
            Cached = ramData[3] ?? 00,
            Buffers = ramData[4] ?? 00,
        };

        return result;

    }
    public async Task<NetDataUpTime?> GetUpTime()
    {
        var response = await _http.GetFromJsonAsync<NetdataResponse>("api/v1/data?chart=system.uptime&after=-1&points=1&format=json");
        if (response is null) return null;
        var uptimeData = response.data.AsEnumerable().ElementAt(0) ?? null;
        if (uptimeData is null) return null;
        var result = new NetDataUpTime()
        {
            Time = Helpers.UnixTimeStampToDateTime(uptimeData.ElementAtOrDefault(0) ?? 00),
            UpTime = new UptimeDuration(Convert.ToInt64(uptimeData.ElementAtOrDefault(1) ?? 00)),
        };
        return result;
    }

    // Helper record for Netdata JSON structure
    private record NetdataResponse(List<List<double?>> data);
}
