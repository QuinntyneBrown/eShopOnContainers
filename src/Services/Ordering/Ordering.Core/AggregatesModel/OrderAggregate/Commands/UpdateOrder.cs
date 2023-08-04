// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate.Commands;

public class UpdateOrderRequestValidator: AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator(){

        RuleFor(x => x.OrderId).NotNull();
        RuleFor(x => x.Description).NotNull();

    }

}


public class UpdateOrderRequest: IRequest<UpdateOrderResponse>
{
    public Guid OrderId { get; set; }
    public string Description { get; set; }
}


public class UpdateOrderResponse
{
    public required OrderDto Order { get; set; }
}


public class UpdateOrderRequestHandler: IRequestHandler<UpdateOrderRequest,UpdateOrderResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<UpdateOrderRequestHandler> _logger;

    public UpdateOrderRequestHandler(ILogger<UpdateOrderRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request,CancellationToken cancellationToken)
    {
        var order = await _context.Orders.SingleAsync(x => x.OrderId == request.OrderId);

        order.OrderId = request.OrderId;
        order.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Order = order.ToDto()
        };

    }

}



