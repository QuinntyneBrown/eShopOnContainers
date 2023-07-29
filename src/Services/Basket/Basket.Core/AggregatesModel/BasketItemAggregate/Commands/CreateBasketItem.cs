// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Basket.Core.AggregatesModel.BasketItemAggregate.Commands;

public class CreateBasketItemRequestValidator: AbstractValidator<CreateBasketItemRequest>
{
    public CreateBasketItemRequestValidator(){

        RuleFor(x => x.ProductId).NotEqual(default(Guid));
        RuleFor(x => x.ProductName).NotNull();
        RuleFor(x => x.UnitPrice).NotNull();
        RuleFor(x => x.OldUnitPrice).NotNull();
        RuleFor(x => x.Quantity).NotNull();
        RuleFor(x => x.PictureUrl).NotNull();

    }

}


public class CreateBasketItemRequest: IRequest<CreateBasketItemResponse>
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int UnitPrice { get; set; }
    public int OldUnitPrice { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }
}


public class CreateBasketItemResponse
{
    public required BasketItemDto BasketItem { get; set; }
}


public class CreateBasketItemRequestHandler: IRequestHandler<CreateBasketItemRequest,CreateBasketItemResponse>
{
    private readonly IBasketDbContext _context;

    private readonly ILogger<CreateBasketItemRequestHandler> _logger;

    public CreateBasketItemRequestHandler(ILogger<CreateBasketItemRequestHandler> logger,IBasketDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateBasketItemResponse> Handle(CreateBasketItemRequest request,CancellationToken cancellationToken)
    {
        var basketItem = new BasketItem();

        _context.BasketItems.Add(basketItem);

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



