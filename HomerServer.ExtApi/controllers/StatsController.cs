using HomerServer.ExtApi.models;
using Microsoft.AspNetCore.Mvc;

namespace HomerServer.ExtApi.controllers;

[ApiController]
[Route("api/[controller]")]
public class StatsController : ControllerBase
{
    [HttpGet]
    public ActionResult<ServerStats> Get()
    {
        var res = new ServerStats()
        {
            CPU = 99,
            RAM = 35,
            Ip = "127.0.0.1",
            UpTime = new TimeSpan(5000) + " Hours"
        };
        return Ok(res);
    }
}
