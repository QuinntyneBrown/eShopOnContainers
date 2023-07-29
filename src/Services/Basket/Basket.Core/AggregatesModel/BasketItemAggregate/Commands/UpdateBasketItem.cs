// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Basket.Core.AggregatesModel.BasketItemAggregate.Commands;

public class UpdateBasketItemRequestValidator: AbstractValidator<UpdateBasketItemRequest>
{
    public UpdateBasketItemRequestValidator(){

        RuleFor(x => x.BasketItemId).NotEqual(default(Guid));
        RuleFor(x => x.ProductId).NotEqual(default(Guid));
        RuleFor(x => x.ProductName).NotNull();
        RuleFor(x => x.UnitPrice).NotNull();
        RuleFor(x => x.OldUnitPrice).NotNull();
        RuleFor(x => x.Quantity).NotNull();
        RuleFor(x => x.PictureUrl).NotNull();

    }

}


public class UpdateBasketItemRequest: IRequest<UpdateBasketItemResponse>
{
    public Guid BasketItemId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int UnitPrice { get; set; }
    public int OldUnitPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }
}


public class UpdateBasketItemResponse
{
    public required BasketItemDto BasketItem { get; set; }
}


public class UpdateBasketItemRequestHandler: IRequestHandler<UpdateBasketItemRequest,UpdateBasketItemResponse>
{
    private readonly IBasketDbContext _context;

    private readonly ILogger<UpdateBasketItemRequestHandler> _logger;

    public UpdateBasketItemRequestHandler(ILogger<UpdateBasketItemRequestHandler> logger,IBasketDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateBasketItemResponse> Handle(UpdateBasketItemRequest request,CancellationToken cancellationToken)
    {
        var basketItem = await _context.BasketItems.SingleAsync(x => x.BasketItemId == request.BasketItemId);

        basketItem.BasketItemId = request.BasketItemId;
        basketItem.ProductId = request.ProductId;
        basketItem.ProductName = request.ProductName;
        basketItem.UnitPrice = request.UnitPrice;
        basketItem.OldUnitPrice = request.OldUnitPrice;
        basketItem.Quantity = request.Quantity;
        basketItem.PictureUrl = request.PictureUrl;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            BasketItem = basketItem.ToDto()
        };

    }

}



