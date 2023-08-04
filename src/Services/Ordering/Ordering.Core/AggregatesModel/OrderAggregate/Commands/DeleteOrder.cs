// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate.Commands;

public class DeleteOrderRequestValidator: AbstractValidator<DeleteOrderRequest>
{
    public DeleteOrderRequestValidator(){

        RuleFor(x => x.OrderId).NotNull();

    }

}


public class DeleteOrderRequest: IRequest<DeleteOrderResponse>
{
    public GUid OrderId { get; set; }
}


public class DeleteOrderResponse
{
    public required OrderDto Order { get; set; }
}


public class DeleteOrderRequestHandler: IRequestHandler<DeleteOrderRequest,DeleteOrderResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<DeleteOrderRequestHandler> _logger;

    public DeleteOrderRequestHandler(ILogger<DeleteOrderRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteOrderResponse> Handle(DeleteOrderRequest request,CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(request.OrderId);

        _context.Orders.Remove(order);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Order = order.ToDto()
        };
    }

}



