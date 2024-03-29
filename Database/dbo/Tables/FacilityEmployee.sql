﻿CREATE TABLE [dbo].[FacilityEmployee]
(
	[EmployeeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[FacilityId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	[Email] NVARCHAR(200) NOT NULL,
	[Street] NVARCHAR(100) NULL,
	[PostalCode] NVARCHAR(100) NULL,
	[City] NVARCHAR(100) NULL,
	[Password] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_FacilityEmployee_to_Facility] FOREIGN KEY ([FacilityId]) REFERENCES [DropOffFacility]([FacilityId]) ON DELETE CASCADE ON UPDATE CASCADE 

)
