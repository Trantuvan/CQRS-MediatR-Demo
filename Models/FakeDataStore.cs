namespace CQRSMediatRExample.Models;

public class FakeDataStore
{
    private readonly List<Product> _products;
    public FakeDataStore()
    {
        _products = new List<Product>
        {
            new() {Id = 1,Name = "Test Product 1"},
            new() {Id = 2,Name = "Test Product 2"},
            new() {Id = 3,Name = "Test Product 3"},
        };
    }

    public async Task EventOccured(Product product, string evt)
    {
        _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
        await Task.CompletedTask;
    }

    public async Task AddProductAsync(Product product)
    {
        _products.Add(product);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await Task.FromResult(_products);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var product = _products.SingleOrDefault(x => x.Id == id);

        if (product == null)
        {
            return await Task.FromResult(default(Product));
        }

        return await Task.FromResult(product);
    }

    public async Task<Product?> UpdateProductAsync(int id, string name)
    {
        var productToUpdate = _products.Find(x => x.Id == id);

        if (productToUpdate is null)
        {
            return await Task.FromResult(default(Product));
        }

        //* still the same object Id with different name
        productToUpdate.Name = name;

        return await Task.FromResult(productToUpdate);
    }

    public async Task DeleteProductAsync(Product product)
    {
        _products.Remove(product);

        await Task.CompletedTask;
    }
}