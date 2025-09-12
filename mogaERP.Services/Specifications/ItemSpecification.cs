namespace mogaERP.Services.Specifications;
public class ItemSpecification : BaseSpecification<Item>
{
    public ItemSpecification(SearchRequest request)
        : base(i => !i.IsDeleted)
    {
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            AddCriteria(i => i.Name.Contains(request.SearchTerm));
        }

        if (!string.IsNullOrWhiteSpace(request.SortBy))
        {
            if (request.SortDescending)
                ApplyOrderByDescending(e => EF.Property<object>(e, request.SortBy));
            else
                ApplyOrderBy(e => EF.Property<object>(e, request.SortBy));
        }

        ApplyPagination((request.PageNumber - 1) * request.PageSize, request.PageSize);


        AddIncludes();
    }

    public ItemSpecification(int id)
        : base(i => i.Id == id && !i.IsDeleted)
    {
        AddIncludes();
    }

    private void AddIncludes()
    {
        AddInclude(i => i.Unit);
        AddInclude(i => i.Group);
        AddInclude(i => i.CreatedBy);
        AddInclude(i => i.UpdatedBy);

        AddInclude("Group.MainGroup");
    }
}
