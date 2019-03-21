CREATE TABLE [dbo].[FlaggedOrder]
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[AdminUserId] UNIQUEIDENTIFIER NOT NULL,
	[Comments] NVARCHAR(200) NULL,
	PRIMARY KEY([OrderId],[AdminUserId]),
	CONSTRAINT [FK_FlaggedOrder_to_Order] FOREIGN KEY ([OrderId]) REFERENCES [Order]([OrderId]),
	CONSTRAINT [FK_FlaggedOrder_to_AdminUser] FOREIGN KEY ([AdminUserId]) REFERENCES [AdminUser]([AdminUserId])
)
