using CQRSMediatRExample.Models;
using MediatR;

namespace CQRSMediatRExample.Commands;

public record DeleteProductCommand(Product Product) : IRequest;