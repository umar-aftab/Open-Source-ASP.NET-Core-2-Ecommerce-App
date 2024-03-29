﻿CREATE TABLE [dbo].[WebsiteUser]
(
	[WebsiteUserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[UserName] NVARCHAR(100) NOT NULL,
	[Password] NVARCHAR(1026) NULL, 
	[Email] NVARCHAR(200) NOT NULL,
	[FirstName] NVARCHAR(100) NULL,
	[LastName] NVARCHAR(100) NULL,
	[Flagged] BIT NOT NULL DEFAULT 0
)
