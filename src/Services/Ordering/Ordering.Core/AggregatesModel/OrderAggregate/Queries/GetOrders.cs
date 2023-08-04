// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate.Queries;

public class GetOrdersRequest: IRequest<GetOrdersResponse> { }

public class GetOrdersResponse
{
    public required List<OrderDto> Orders { get; set; }
}


public class GetOrdersRequestHandler: IRequestHandler<GetOrdersRequest,GetOrdersResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<GetOrdersRequestHandler> _logger;

    public GetOrdersRequestHandler(ILogger<GetOrdersRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetOrdersResponse> Handle(GetOrdersRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Orders = await _context.Orders.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



