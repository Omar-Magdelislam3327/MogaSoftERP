namespace mogaERP.Services.Specifications;
public class PriceQuotationSpecification : BaseSpecification<PriceQuotation>
{
    public PriceQuotationSpecification(SearchRequest request)
        : base(i => !i.IsDeleted)
    {
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            AddCriteria(i => i.QuotationNumber.Contains(request.SearchTerm) ||
                             i.Supplier.Name.Contains(request.SearchTerm));
        }
        if (!string.IsNullOrWhiteSpace(request.SortBy))
        {
            if (request.SortDescending)
                ApplyOrderByDescending(e => EF.Property<object>(e, request.SortBy));
            else
                ApplyOrderBy(e => EF.Property<object>(e, request.SortBy));
        }
        ApplyPagination((request.PageNumber - 1) * request.PageSize, request.PageSize);
    }


    public PriceQuotationSpecification(int id)
        : base(i => i.Id == id && !i.IsDeleted)
    {
        AddIncludes();
    }

    private void AddIncludes()
    {
        AddInclude(i => i.Supplier);
        AddInclude(i => i.CreatedBy);
        AddInclude(i => i.UpdatedBy);
        AddInclude(i => i.Items);

        AddInclude("Items.Item");
        AddInclude("Items.Item.Unit");
    }

}
