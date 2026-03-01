
CREATE TABLE Users
(
    UserID      INT IDENTITY(1,1) PRIMARY KEY,
    Username    NVARCHAR(100) NOT NULL,
    Password    NVARCHAR(100) NOT NULL,
    UserRole    NVARCHAR(50)  NOT NULL,
    FullName    NVARCHAR(200) NOT NULL,
    Address     NVARCHAR(500) NOT NULL
);

CREATE TABLE Products
(
    ProductID      INT IDENTITY(1,1) PRIMARY KEY,
    ProductName    NVARCHAR(200) NOT NULL,
    Category       NVARCHAR(100) NOT NULL,
    UnitPrice      DECIMAL(10,2) NOT NULL,
    StockQuantity  INT           NOT NULL
);

CREATE TABLE Orders
(
    OrderID      INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID   INT            NOT NULL,
    OrderDate    DATETIME       NOT NULL,
    TotalAmount  DECIMAL(10,2)  NOT NULL,
    Status       NVARCHAR(50)   NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID)
);

CREATE TABLE ORDER_DETAILS
(
    DetailID    INT IDENTITY(1,1) PRIMARY KEY,
    OrderID     INT            NOT NULL,
    ProductID   INT            NOT NULL,
    Quantity    INT            NOT NULL,
    SubTotal    DECIMAL(10,2)  NOT NULL,
    FOREIGN KEY (OrderID)   REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Users (Username, Password, UserRole, FullName, Address)
VALUES ('admin', 'admin123', 'Admin', 'System Administrator', 'Head Office');