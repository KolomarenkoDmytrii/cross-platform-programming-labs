using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Lab5.App.Models;
using Lab5.Labs;

namespace Lab5.App.Controllers;

[Authorize]
public class LabsController : Controller
{
    [HttpGet]
    public IActionResult RunLab1() => View();

    [HttpGet]
    public IActionResult RunLab2() => View();

    [HttpGet]
    public IActionResult RunLab3() => View();

    [HttpPost]
    public IActionResult RunLab1(Lab1InputViewModel input)
    {
        ViewBag.Result = Lab1.Run(input.Sequence, input.Subsequence);
        return View("RunLab1");
    }

    [HttpPost]
    public IActionResult RunLab2(Lab2InputViewModel input)
    {
        ViewBag.Result = Lab2.Run(input.Number);
        return View("RunLab2");
    }

    [HttpPost]
    public IActionResult RunLab3(Lab3InputViewModel input)
    {
        int result = Lab3.Run(input.Start, input.End);
        ViewBag.Result = result == Lab3.Graph.INFINITY ? -1 : result;
        return View("RunLab3");
    }
}
