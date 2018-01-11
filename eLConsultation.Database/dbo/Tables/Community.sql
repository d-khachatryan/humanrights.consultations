CREATE TABLE [dbo].[Community]
(
	[CommunityID] INT NOT NULL PRIMARY KEY IDENTITY, 
	[RegionID] INT NULL,
    [CommunityName] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Community_Region] FOREIGN KEY ([RegionID]) REFERENCES [Region]([RegionID])    
)
