using Mapster;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using mogaERP.Domain.Contracts.InventoryModule.Items;
using mogaERP.Domain.Enums;
using mogaERP.Domain.Interfaces.InventoryModule;
using mogaERP.Services.Specifications;

namespace mogaERP.Services.Services.InventoryModule;
public class ItemService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ItemService> logger) : IItemService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<ItemService> _logger = logger;

    public async Task<ApiResponse<string>> CreateItemAsync(ItemRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var unitExists = await _unitOfWork.Repository<ItemUnit>()
                             .AnyAsync(u => u.Id == request.UnitId, cancellationToken);

            if (!unitExists)
                return ApiResponse<string>.Failure(new ErrorModel("Unit not Found", AppStatusCode.NotFound));

            var groupExists = await _unitOfWork.Repository<ItemGroup>()
                             .AnyAsync(g => g.Id == request.GroupId, cancellationToken);

            if (!groupExists)
                return ApiResponse<string>.Failure(new ErrorModel("Group not Found", AppStatusCode.NotFound));

            var item = request.Adapt<Item>();

            await _unitOfWork.Repository<Item>().AddAsync(item, cancellationToken);

            await _unitOfWork.CompleteAsync(cancellationToken);

            return ApiResponse<string>.Success(AppErrors.AddSuccess, item.Id.ToString());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating item");
            return ApiResponse<string>.Failure(AppErrors.TransactionFailed);
        }
    }

    public async Task<ApiResponse<string>> DeleteItemAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var item = await _unitOfWork.Repository<Item>().GetByIdAsync(id, cancellationToken);
            if (item == null)
                return ApiResponse<string>.Failure(AppErrors.NotFound);
            item.IsDeleted = true;
            _unitOfWork.Repository<Item>().Update(item);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return ApiResponse<string>.Success(AppErrors.DeleteSuccess);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting item with id {ItemId}", id);
            return ApiResponse<string>.Failure(AppErrors.TransactionFailed);
        }

    }

    public async Task<ApiResponse<PagedResponse<ItemResponse>>> GetAllItemsAsync(SearchRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var spec = new ItemSpecification(request);

            var items = await _unitOfWork.Repository<Item>().ListAsync(spec, cancellationToken);

            var countSpec = new ItemSpecification(request);

            countSpec.DisablePagination(); // To get the total count without pagination

            var totalCount = await _unitOfWork.Repository<Item>().CountBySpecAsync(countSpec, cancellationToken);

            var itemResponses = _mapper.Map<IReadOnlyList<ItemResponse>>(items);

            var paged = new PagedResponse<ItemResponse>(itemResponses, totalCount, request.PageNumber, request.PageSize);

            return ApiResponse<PagedResponse<ItemResponse>>.Success(AppErrors.Success, paged);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all items");
            return ApiResponse<PagedResponse<ItemResponse>>.Failure(AppErrors.TransactionFailed);
        }
    }

    public async Task<ApiResponse<ItemResponse>> GetItemByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var spec = new ItemSpecification(id);

            var item = await _unitOfWork.Repository<Item>().GetEntityWithSpecAsync(spec, cancellationToken);

            if (item == null)
                return ApiResponse<ItemResponse>.Failure(AppErrors.NotFound);

            var itemResponse = _mapper.Map<ItemResponse>(item);

            return ApiResponse<ItemResponse>.Success(AppErrors.Success, itemResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving item with id {ItemId}", id);
            return ApiResponse<ItemResponse>.Failure(AppErrors.TransactionFailed);
        }
    }

    public async Task<ApiResponse<string>> UpdateItemAsync(int id, ItemRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var item = await _unitOfWork.Repository<Item>().GetByIdAsync(id, cancellationToken);

            if (item == null)
                return ApiResponse<string>.Failure(AppErrors.NotFound);

            var unitExists = await _unitOfWork.Repository<ItemUnit>()
                             .AnyAsync(u => u.Id == request.UnitId, cancellationToken);
            if (!unitExists)
                return ApiResponse<string>.Failure(new ErrorModel("Unit not Found", AppStatusCode.NotFound));
            var groupExists = await _unitOfWork.Repository<ItemGroup>()
                             .AnyAsync(g => g.Id == request.GroupId, cancellationToken);
            if (!groupExists)
                return ApiResponse<string>.Failure(new ErrorModel("Group not Found", AppStatusCode.NotFound));

            item = request.Adapt(item);

            _unitOfWork.Repository<Item>().Update(item);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return ApiResponse<string>.Success(AppErrors.UpdateSuccess);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating item with id {ItemId}", id);
            return ApiResponse<string>.Failure(AppErrors.TransactionFailed);
        }
    }
}
