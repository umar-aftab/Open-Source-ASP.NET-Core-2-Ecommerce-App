CREATE TABLE [dbo].[TransactionHistory]
(
	[HistoryId]  UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[WebsiteUserId] UNIQUEIDENTIFIER NOT NULL,
	[BillingInfoId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_History_to_WebsiteUser] FOREIGN KEY ([WebsiteUserId]) REFERENCES [WebsiteUser]([WebsiteUserId]),
	CONSTRAINT [FK_History_to_BillingInfo] FOREIGN KEY ([BillingInfoId]) REFERENCES [BillingInfo]([BillingInfoId]),
	CONSTRAINT [FK_History_to_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product]([ProductId])
)
