// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate.Queries;

public class GetOrdersPageRequest: IRequest<GetOrdersPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
}


public class GetOrdersPageResponse
{
    public required int Length { get; set; }
    public required List<OrderDto> Entities  { get; set; }
}


public class CreateOrderRequestHandler: IRequestHandler<GetOrdersPageRequest,GetOrdersPageResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<CreateOrderRequestHandler> _logger;

    public CreateOrderRequestHandler(ILogger<CreateOrderRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetOrdersPageResponse> Handle(GetOrdersPageRequest request,CancellationToken cancellationToken)
    {
        var query = from order in _context.Orders
            select order;

        var length = await _context.Orders.AsNoTracking().CountAsync();

        var orders = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new ()
        {
            Length = length,
            Entities = orders
        };

    }

}



