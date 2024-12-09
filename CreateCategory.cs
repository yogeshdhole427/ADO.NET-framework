[HttpPost]
public IActionResult CreateCategory([FromBody] Category category)
{
    _dbContext.Categories.Add(category);
    _dbContext.SaveChanges();
    return Ok(category);
}

[HttpGet]
public IActionResult GetCategories()
{
    var categories = _dbContext.Categories.ToList();
    return Ok(categories);
}

[HttpPut("{id}")]
public IActionResult UpdateCategory(int id, [FromBody] Category category)
{
    var existingCategory = _dbContext.Categories.Find(id);
    if (existingCategory == null)
        return NotFound();
    
    existingCategory.CategoryName = category.CategoryName;
    _dbContext.SaveChanges();
    return Ok(existingCategory);
}

[HttpDelete("{id}")]
public IActionResult DeleteCategory(int id)
{
    var category = _dbContext.Categories.Find(id);
    if (category == null)
        return NotFound();
    
    _dbContext.Categories.Remove(category);
    _dbContext.SaveChanges();
    return NoContent();
}