CREATE TABLE [dbo].[Issue]
(
	[IssueID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ResidentID] INT NULL, 
    [IssueName] NVARCHAR(50) NULL, 
    [IssueDescription] NVARCHAR(MAX) NULL, 
    [IssueDate] DATE NULL, 
    [IssueTypeID] INT NULL, 
    [CompanyID] INT NULL, 
    [IssueCategoryID] INT NULL, 
    CONSTRAINT [FK_Issue_IssueType] FOREIGN KEY ([IssueTypeID]) REFERENCES [IssueType]([IssueTypeID]),
	CONSTRAINT [FK_Issue_IssueCategory] FOREIGN KEY ([IssueCategoryID]) REFERENCES [IssueCategory]([IssueCategoryID]),
    CONSTRAINT [FK_Issue_Resident] FOREIGN KEY ([ResidentID]) REFERENCES [Resident]([ResidentID]),
	CONSTRAINT [FK_Issue_Company] FOREIGN KEY ([CompanyID]) REFERENCES [Company]([CompanyID])
)
