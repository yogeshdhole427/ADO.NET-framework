[HttpGet]
public IActionResult GetPaginatedProductList(int pageNumber = 1, int pageSize = 10)
{
    var products = _dbContext.Products
        .Include(p => p.Category)
        .OrderBy(p => p.ProductId)  // Ensure data is ordered (by ProductId)
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