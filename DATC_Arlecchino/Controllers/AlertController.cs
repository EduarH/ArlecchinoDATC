using DATC_Arlecchino.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Numerics;

namespace DATC_Arlecchino.Controllers;

[ApiController]
[Route("Alert")]
public class AlertController : ControllerBase
{
     AlertRepo DataBase = new AlertRepo(
       "citydanger",
        "do07hR2MKPVPvWljhTERQ4ucU1QGOE3hZJSgOm4xR/VzJrOhsWO4tRfkPQlx584zJgIqWmWqrqRB+ASt2lzqWQ==",
        "CityDanger"
    );

    [HttpGet()]
    public IActionResult Get()
    {
        List<Alert> alertList = new List<Alert>();
        Task.Run(async () => { alertList = await DataBase.GetAllAlerts(); }).GetAwaiter().GetResult();
        return Ok(alertList);
    }

    [HttpGet("{title}")]
    public IActionResult Get(string title)
    {
        List<Alert> alertList = new List<Alert>();
        Task.Run(async () => { alertList = await DataBase.GetAllAlerts(); }).GetAwaiter().GetResult();
        List<Alert> foundList = new List<Alert>();
        foreach (Alert x in alertList)
        {
            if (x.Title == title)
            {
                foundList.Add(x);
            }
        }

        if (foundList.Count == 0)
            return Ok("Nu exista alerte cu tiltul asta");

        return Ok(foundList);
    }

    [HttpPost("PostAlert")]
    public async Task<string> Post(string partitionKey,string rowKey,string latitude, string longitude, string title,string text)
    {
        Alert alert = new Alert(partitionKey, rowKey, latitude, longitude, title, text);
        await DataBase.InsertAlert(alert);
        return "Post Succesful";
    }
}