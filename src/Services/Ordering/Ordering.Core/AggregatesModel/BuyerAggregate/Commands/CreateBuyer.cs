// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Ordering.Core.AggregatesModel.BuyerAggregate.Commands;

public class CreateBuyerRequestValidator: AbstractValidator<CreateBuyerRequest>
{
    public CreateBuyerRequestValidator(){


    }

}


public class CreateBuyerRequest: IRequest<CreateBuyerResponse> { }

public class CreateBuyerResponse
{
    public required BuyerDto Buyer { get; set; }
}


public class CreateBuyerRequestHandler: IRequestHandler<CreateBuyerRequest,CreateBuyerResponse>
{
    private readonly IOrderingDbContext _context;

    private readonly ILogger<CreateBuyerRequestHandler> _logger;

    public CreateBuyerRequestHandler(ILogger<CreateBuyerRequestHandler> logger,IOrderingDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateBuyerResponse> Handle(CreateBuyerRequest request,CancellationToken cancellationToken)
    {
        var buyer = new Buyer();

        _context.Buyers.Add(buyer);


        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Buyer = buyer.ToDto()
        };

    }

}



