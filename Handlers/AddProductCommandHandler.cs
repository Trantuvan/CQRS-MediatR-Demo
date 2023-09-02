using CQRSMediatRExample.Commands;
using CQRSMediatRExample.Models;
using MediatR;

namespace CQRSMediatRExample.Handlers;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
{
    private readonly FakeDataStore _fakeDataStore;

    public AddProductCommandHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddProductAsync(request.Product);
    }
}