CREATE TABLE [dbo].[FlaggedUser]
(
	[WebsiteUserId] UNIQUEIDENTIFIER NOT NULL,
	[AdminUserId] UNIQUEIDENTIFIER NOT NULL,
	[Comments] NVARCHAR(200) NULL,
	PRIMARY KEY([WebsiteUserId],[AdminUserId]),
	CONSTRAINT [FK_FlaggedUser_to_WebsiteUser] FOREIGN KEY ([WebsiteUserId]) REFERENCES [WebsiteUser]([WebsiteUserId]),
	CONSTRAINT [FK_FlaggedUser_to_AdminUser] FOREIGN KEY ([AdminUserId]) REFERENCES [AdminUser]([AdminUserId])
)
