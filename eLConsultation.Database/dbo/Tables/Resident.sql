CREATE TABLE [dbo].[Resident]
(
	[ResidentID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [IdentificatorNumber] NVARCHAR(50) NULL, 
    [BirthDate] DATE NULL, 
	[GenderID] INT NULL,
    [RegionID] INT NULL, 
    [CommunityID] INT NULL, 
    [Street] NVARCHAR(50) NULL, 
    [Building] NVARCHAR(50) NULL, 
    [Home] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Resident_Region] FOREIGN KEY ([RegionID]) REFERENCES [Region]([RegionID]), 
    CONSTRAINT [FK_Resident_Community] FOREIGN KEY ([CommunityID]) REFERENCES [Community]([CommunityID]), 
    CONSTRAINT [FK_Resident_Gender] FOREIGN KEY ([GenderID]) REFERENCES [Gender]([GenderID])
)
