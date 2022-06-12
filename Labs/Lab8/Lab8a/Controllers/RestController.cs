namespace Lab8a.Controllers;

using Lab8a.Database.Entities;
using Lab8a.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RestController : ControllerBase
{
    private readonly IPhoneService _phoneService;

    public RestController(IPhoneService phoneService)
    {
        this._phoneService = phoneService;
    }

    [HttpGet]
    public IQueryable<Phone> GetAll() => this._phoneService.GetAll();

    [HttpGet("{phoneId}")]
    public async Task<Phone> Get(int phoneId) =>
            await this._phoneService.GetAsync(phoneId);

    [HttpPost]
    public async Task<Phone> Post([FromBody] Phone phoneCreateData) =>
        await this._phoneService.CreateAsync(phoneCreateData);

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Phone phoneUpdateData)
    {
        await this._phoneService.UpdateAsync(phoneUpdateData);
        return NoContent();
    }

    [HttpDelete("{phoneId}")]
    public async Task<IActionResult> Delete(int phoneId)
    {
        await this._phoneService.DeleteAsync(phoneId);
        return NoContent();
    }
}
