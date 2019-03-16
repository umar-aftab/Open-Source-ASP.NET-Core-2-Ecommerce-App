CREATE TABLE [dbo].[Review]
(
	[ReviewId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Subject] NVARCHAR(150) NOT NULL,
	[Content] NVARCHAR(300) NULL,
	[ReviewingUserId] UNIQUEIDENTIFIER NOT NULL,
	[ReviewedUserId] UNIQUEIDENTIFIER NOT NULL,
	[Stars] NVARCHAR(5) NOT NULL,
	[Date] DATETIME NOT NULL,
	[Flagged] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_Review_to_ReviewingUser] FOREIGN KEY ([ReviewingUserId]) REFERENCES [WebsiteUser]([WebsiteUserId]), 
	CONSTRAINT [FK_Review_to_ReviewedUser] FOREIGN KEY ([ReviewedUserId]) REFERENCES [WebsiteUser]([WebsiteUserId])  

)
