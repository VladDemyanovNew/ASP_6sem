namespace Lab8a.Controllers;

using Lab8a.Database.Entities;
using Lab8a.Models;
using Lab8a.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

public class DistController : Controller
{
    private readonly IPhoneService _phoneService;

    public DistController(IPhoneService phoneService)
    {
        this._phoneService = phoneService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var phones = this._phoneService.GetAll();
        return View(phones);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddSave(Phone phoneCreateData)
    {
        _ = await this._phoneService.CreateAsync(phoneCreateData);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int phoneId)
    {
        var phone = await this._phoneService.GetAsync(phoneId);
        return View(phone);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSave(Phone phoneUpdateData)
    {
        await this._phoneService.UpdateAsync(phoneUpdateData);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int phoneId)
    {
        var phone = await this._phoneService.GetAsync(phoneId);
        return View(phone);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteSave(int phoneId)
    {
        await this._phoneService.DeleteAsync(phoneId);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
