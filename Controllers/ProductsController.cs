using CQRSMediatRExample.Commands;
using CQRSMediatRExample.Models;
using CQRSMediatRExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRExample.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetProductById([FromRoute] int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] Product product)
    {
        await _mediator.Send(new AddProductCommand(product));

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] string name)
    {
        //* fakeproduct is already handled query product id and update
        var product = await _mediator.Send(new UpdateProductCommand(id, name));

        if (product == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        //* call mediator to trigger fakeproduct to query the product by its id
        var productToDelete = await _mediator.Send(new GetProductByIdQuery(id));

        if (productToDelete == null)
        {
            return NotFound();
        }
        await _mediator.Send(new DeleteProductCommand(productToDelete));

        return NoContent();
    }
}