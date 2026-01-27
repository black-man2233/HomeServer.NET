using System;
using System.Net;
using System.Text;
using Bogus;
using HomerServer.ExtApi.Clients;
using HomerServer.ExtApi.models;
using HomerServer.ExtApi.models.NetData;
using Microsoft.AspNetCore.Mvc;

namespace HomerServer.ExtApi.controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    private readonly NetdataClient _netdata;

    public StatsController(NetdataClient netdata) => _netdata = netdata;

    [HttpGet]
    public async Task<ActionResult<ServerStats>> GetStats()
    {
        var stats = await _netdata.GetServerStatsAsync();
        if (stats is null)
            return NotFound();
        return Ok(stats);
    }

    [HttpGet("ramusage")]
    public async Task<ActionResult<NetDataRamUsage>> GetRamUsage()
    {
        var stats = await _netdata.GetRamUsage();
        if (stats is null)
            return NotFound();
        return Ok(stats);
    }

    [HttpGet("cpuusage")]
    public async Task<ActionResult<NetDataRamUsage>> GetCpuUage()
    {
        var stats = await _netdata.GetCPUUsage();
        if (stats is null)
            return NotFound();
        return Ok(stats);
    }
    [HttpGet("uptime")]
    public async Task<ActionResult<NetDataRamUsage>> GetUpTime()
    {
        var stats = await _netdata.GetUpTime();
        if (stats is null)
            return NotFound();
        return Ok(stats);
    }
}
