// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Basket.Core.AggregatesModel.BasketItemAggregate.Commands;

public class DeleteBasketItemRequestValidator: AbstractValidator<DeleteBasketItemRequest>
{
    public DeleteBasketItemRequestValidator(){

        RuleFor(x => x.BasketItemId).NotEqual(default(Guid));

    }

}


public class DeleteBasketItemRequest: IRequest<DeleteBasketItemResponse>
{
    public Guid BasketItemId { get; set; }
}


public class DeleteBasketItemResponse
{
    public required BasketItemDto BasketItem { get; set; }
}


public class DeleteBasketItemRequestHandler: IRequestHandler<DeleteBasketItemRequest,DeleteBasketItemResponse>
{
    private readonly IBasketDbContext _context;

    private readonly ILogger<DeleteBasketItemRequestHandler> _logger;

    public DeleteBasketItemRequestHandler(ILogger<DeleteBasketItemRequestHandler> logger,IBasketDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteBasketItemResponse> Handle(DeleteBasketItemRequest request,CancellationToken cancellationToken)
    {
        var basketItem = await _context.BasketItems.FindAsync(request.BasketItemId);

        _context.BasketItems.Remove(basketItem);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            BasketItem = basketItem.ToDto()
        };
    }

}



