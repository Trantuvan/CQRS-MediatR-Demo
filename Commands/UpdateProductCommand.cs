using CQRSMediatRExample.Models;
using MediatR;

namespace CQRSMediatRExample.Commands;

public record UpdateProductCommand(int Id, string Name) : IRequest<Product?>;