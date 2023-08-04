// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.OrderAggregate.Commands;

public class CreateOrderRequestValidator: AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator(){

        RuleFor(x => x.Description).NotNull();

    }

}


public class CreateOrderRequest: IRequest<CreateOrderResponse>
{
    public string Description { get; set; }
}


public class CreateOrderResponse
{
    public required OrderDto Order { get; set; }
}


public class CreateOrderRequestHandler: IRequestHandler<CreateOrderRequest,CreateOrderResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<CreateOrderRequestHandler> _logger;

    public CreateOrderRequestHandler(ILogger<CreateOrderRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request,CancellationToken cancellationToken)
    {
        var order = new Order();

        _context.Orders.Add(order);

        order.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Order = order.ToDto()
        };

    }

}



