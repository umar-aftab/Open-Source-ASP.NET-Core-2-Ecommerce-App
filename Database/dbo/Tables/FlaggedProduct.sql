CREATE TABLE [dbo].[FlaggedProduct]
(
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[AdminUserId] UNIQUEIDENTIFIER NOT NULL,
	[Comments] NVARCHAR(200) NULL,
	PRIMARY KEY([ProductId],[AdminUserId]),
	CONSTRAINT [FK_FlaggedProduct_to_Order] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId]),
	CONSTRAINT [FK_FlaggedProduct_to_AdminUser] FOREIGN KEY ([AdminUserId]) REFERENCES [AdminUser]([AdminUserId])
)
