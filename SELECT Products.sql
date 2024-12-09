SELECT p.ProductId, p.ProductName, p.CategoryId, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.CategoryId = c.CategoryId;