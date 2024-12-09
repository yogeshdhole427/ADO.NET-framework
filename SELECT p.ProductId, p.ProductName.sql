SELECT p.ProductId, p.ProductName, p.CategoryId, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.CategoryId = c.CategoryId
ORDER BY p.ProductId
OFFSET (pageNumber - 1) * pageSize ROWS
FETCH NEXT pageSize ROWS ONLY;