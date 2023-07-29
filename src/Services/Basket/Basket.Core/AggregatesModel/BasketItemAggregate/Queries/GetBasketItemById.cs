// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Basket.Core.AggregatesModel.BasketItemAggregate.Queries;

public class GetBasketItemByIdRequest: IRequest<GetBasketItemByIdResponse>
{
    public Guid BasketItemId { get; set; }
}


public class GetBasketItemByIdResponse
{
    public required BasketItemDto BasketItem { get; set; }
}


public class GetBasketItemByIdRequestHandler: IRequestHandler<GetBasketItemByIdRequest,GetBasketItemByIdResponse>
{
    private readonly IBasketDbContext _context;

    private readonly ILogger<GetBasketItemByIdRequestHandler> _logger;

    public GetBasketItemByIdRequestHandler(ILogger<GetBasketItemByIdRequestHandler> logger,IBasketDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetBasketItemByIdResponse> Handle(GetBasketItemByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            BasketItem = (await _context.BasketItems.AsNoTracking().SingleOrDefaultAsync(x => x.BasketItemId == request.BasketItemId)).ToDto()
        };

    }

}



