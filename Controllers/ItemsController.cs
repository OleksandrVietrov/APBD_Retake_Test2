using Microsoft.AspNetCore.Mvc;
using TemplateApi.DTOs;
using TemplateApi.Services;

namespace TemplateApi.Controllers;

[ApiController]
[Route("api/speakers")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _service;
    public ItemsController(IItemService service) => _service = service;
    
    [HttpGet("{id}/workshops")]
    public async Task<IActionResult> GetItem(int id)
    {
        var item = await _service.GetItemAsync(id);
        if (item is null) return NotFound($"Item {id} not found."); // 404
        return Ok(item); // 200
    }
    
    [HttpPost("/api/workshops/{wId}/register")]
    public async Task<IActionResult> CreateItem(int wId, [FromBody] CreateItemDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateItemAsync(wId, dto);
        return result switch
        {
            OpResult.Success  => Created($"/api/items", null), // 201
            OpResult.NotFound => NotFound($"Owner {wId} not found."),
            OpResult.Invalid  => BadRequest("Invalid data."),
            OpResult.Conflict => Conflict("Conflict."),
            _                 => StatusCode(500)
        };
    }

    
}
