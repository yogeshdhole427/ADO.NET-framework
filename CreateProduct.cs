[HttpPost]
public IActionResult CreateProduct([FromBody] Product product)
{
    _dbContext.Products.Add(product);
    _dbContext.SaveChanges();
    return Ok(product);
}

[HttpGet]
public IActionResult GetProducts()
{
    var products = _dbContext.Products.ToList();
    return Ok(products);
}

[HttpPut("{id}")]
public IActionResult UpdateProduct(int id, [FromBody] Product product)
{
    var existingProduct = _dbContext.Products.Find(id);
    if (existingProduct == null)
        return NotFound();
    
    existingProduct.ProductName = product.ProductName;
    existingProduct.CategoryId = product.CategoryId;
    _dbContext.SaveChanges();
    return Ok(existingProduct);
}

[HttpDelete("{id}")]
public IActionResult DeleteProduct(int id)
{
    var product = _dbContext.Products.Find(id);
    if (product == null)
        return NotFound();
    
    _dbContext.Products.Remove(product);
    _dbContext.SaveChanges();
    return NoContent();
}