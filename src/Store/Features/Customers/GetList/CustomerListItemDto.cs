

namespace Store.Features.Customers.GetList
{
    public record CustomerListItemDto(
        int Id,
        string Name,
        decimal Balance
    );
}