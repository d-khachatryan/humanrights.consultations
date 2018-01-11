CREATE TABLE [dbo].[Consultant]
(
	[ConsultantID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Id] NVARCHAR(128) NULL
)
