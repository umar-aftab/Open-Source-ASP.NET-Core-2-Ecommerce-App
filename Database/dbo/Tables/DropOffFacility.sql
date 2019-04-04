﻿CREATE TABLE [dbo].[DropOffFacility]
(
	[FacilityId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Street] NVARCHAR(50) NULL,
	[PostalCode] NVARCHAR(10) NULL,
	[City] NVARCHAR(50) NULL,
	[Hours] NVARCHAR(50) NULL 
)