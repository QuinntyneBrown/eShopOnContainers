// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.BuyerAggregate.Queries;

public class GetBuyerByIdRequest: IRequest<GetBuyerByIdResponse>
{
    public Guid BuyerId { get; set; }
}


public class GetBuyerByIdResponse
{
    public required BuyerDto Buyer { get; set; }
}


public class GetBuyerByIdRequestHandler: IRequestHandler<GetBuyerByIdRequest,GetBuyerByIdResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<GetBuyerByIdRequestHandler> _logger;

    public GetBuyerByIdRequestHandler(ILogger<GetBuyerByIdRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetBuyerByIdResponse> Handle(GetBuyerByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Buyer = (await _context.Buyers.AsNoTracking().SingleOrDefaultAsync(x => x.BuyerId == request.BuyerId)).ToDto()
        };

    }

}



