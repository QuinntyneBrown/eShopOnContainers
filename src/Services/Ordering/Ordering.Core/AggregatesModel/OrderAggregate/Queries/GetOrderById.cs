// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate.Queries;

public class GetOrderByIdRequest: IRequest<GetOrderByIdResponse>
{
    public Guid OrderId { get; set; }
}


public class GetOrderByIdResponse
{
    public required OrderDto Order { get; set; }
}


public class GetOrderByIdRequestHandler: IRequestHandler<GetOrderByIdRequest,GetOrderByIdResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<GetOrderByIdRequestHandler> _logger;

    public GetOrderByIdRequestHandler(ILogger<GetOrderByIdRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Order = (await _context.Orders.AsNoTracking().SingleOrDefaultAsync(x => x.OrderId == request.OrderId)).ToDto()
        };

    }

}



