CREATE TABLE [dbo].[OrderProduct]
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	PRIMARY KEY([OrderId],[ProductId]),
	CONSTRAINT [FK_OrderProduct_to_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId]),
	CONSTRAINT [FK_OrderProduct_to_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([OrderId])
)
