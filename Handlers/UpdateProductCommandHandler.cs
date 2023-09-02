using CQRSMediatRExample.Commands;
using CQRSMediatRExample.Models;
using MediatR;

namespace CQRSMediatRExample.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product?>
{
    private readonly FakeDataStore _fakeDataStore;

    public UpdateProductCommandHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task<Product?> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        return await _fakeDataStore.UpdateProductAsync(request.Id, request.Name);
    }
}
