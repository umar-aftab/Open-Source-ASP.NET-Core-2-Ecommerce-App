CREATE TABLE [dbo].[FlaggedReview]
(
	[ReviewId] UNIQUEIDENTIFIER NOT NULL,
	[AdminUserId] UNIQUEIDENTIFIER NOT NULL,
	[Comments] NVARCHAR(200) NULL,
	PRIMARY KEY([ReviewId],[AdminUserId]),
	CONSTRAINT [FK_FlaggedReview_to_Review] FOREIGN KEY ([ReviewId]) REFERENCES [Review]([ReviewId]),
	CONSTRAINT [FK_FlaggedReview_to_AdminUser] FOREIGN KEY ([AdminUserId]) REFERENCES [AdminUser]([AdminUserId])
)
