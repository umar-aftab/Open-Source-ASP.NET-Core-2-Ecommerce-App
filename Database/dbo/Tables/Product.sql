CREATE TABLE [dbo].[Product]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Price] NVARCHAR(10) NULL,
	[Description] NVARCHAR(100) NULL,
	[Image] VARBINARY(MAX) NULL,
	[ProductTypeId] UNIQUEIDENTIFIER NOT NULL,
	[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
	[Condition] NVARCHAR(100) NULL,
	[Flagged] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_Product_to_ProductType] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductType]([ProductTypeId]),
	CONSTRAINT [FK_Product_to_ProductCategory] FOREIGN KEY ([ProductCategoryId]) REFERENCES [ProductCategory]([ProductCategoryId])
)
