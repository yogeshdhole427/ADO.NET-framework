CREATE TABLE Products (
    ProductId INT PRIMARY KEY,
    ProductName VARCHAR(255) NOT NULL,
    CategoryId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);