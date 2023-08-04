// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.BuyerAggregate.Queries;

public class GetBuyersPageRequest: IRequest<GetBuyersPageResponse>
{
    public int PageSize { get; set; }
    public int Index { get; set; }
    public int Length { get; set; }
}


public class GetBuyersPageResponse
{
    public required int Length { get; set; }
    public required List<BuyerDto> Entities  { get; set; }
}


public class CreateBuyerRequestHandler: IRequestHandler<GetBuyersPageRequest,GetBuyersPageResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<CreateBuyerRequestHandler> _logger;

    public CreateBuyerRequestHandler(ILogger<CreateBuyerRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetBuyersPageResponse> Handle(GetBuyersPageRequest request,CancellationToken cancellationToken)
    {
        var query = from buyer in _context.Buyers
            select buyer;

        var length = await _context.Buyers.AsNoTracking().CountAsync();

        var buyers = await query.Page(request.Index, request.PageSize).AsNoTracking()
            .Select(x => x.ToDto()).ToListAsync();

        return new ()
        {
            Length = length,
            Entities = buyers
        };

    }

}



