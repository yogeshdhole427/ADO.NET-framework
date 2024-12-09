[HttpGet]
public IActionResult GetProductList(int pageNumber = 1, int pageSize = 10)
{
    var products = _dbContext.Products
        .Include(p => p.Category)  // Assuming you have navigation properties
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(p => new
        {
            p.ProductId,
            p.ProductName,
            p.CategoryId,
            CategoryName = p.Category.CategoryName
        })
        .ToList();
    
    return Ok(products);
}