using mogaERP.Domain.Contracts.InventoryModule.Items;

namespace mogaERP.Domain.Interfaces.InventoryModule;
public interface IItemService
{
    Task<ApiResponse<string>> CreateItemAsync(ItemRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> UpdateItemAsync(int id, ItemRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> DeleteItemAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<ItemResponse>> GetItemByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<PagedResponse<ItemResponse>>> GetAllItemsAsync(SearchRequest request, CancellationToken cancellationToken = default);
}
