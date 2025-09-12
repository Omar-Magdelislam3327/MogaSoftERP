using mogaERP.Domain.Contracts.InventoryModule.Items;
using mogaERP.Domain.Interfaces.InventoryModule;
using mogaERP.Domain.Wrappers;

namespace mogaERP.API.Controllers;

public class ItemsController(IItemService itemService) : BaseApiController
{
    private readonly IItemService _itemService = itemService;

    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] ItemRequest request, CancellationToken cancellationToken)
    {
        var result = await _itemService.CreateItemAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllItems([FromQuery] SearchRequest request, CancellationToken cancellationToken)
    {
        var result = await _itemService.GetAllItemsAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id:int}")]

    public async Task<IActionResult> GetItemById(int id, CancellationToken cancellationToken)
    {
        var result = await _itemService.GetItemByIdAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] ItemRequest request, CancellationToken cancellationToken)
    {
        var result = await _itemService.UpdateItemAsync(id, request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteItem(int id, CancellationToken cancellationToken)
    {
        var result = await _itemService.DeleteItemAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }
}