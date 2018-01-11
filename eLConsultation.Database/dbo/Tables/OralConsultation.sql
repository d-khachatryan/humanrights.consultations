CREATE TABLE [dbo].[OralConsultation]
(
	[OralConsultationID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ResidentID] INT NULL, 
	[IssueID] INT NULL, 
    [OralConsultationDate] DATE NULL, 
    [InvocationTypeID] INT NULL, 
    [TargetGroupID] INT NULL, 
    [ProblemDescription] NVARCHAR(MAX) NULL, 
    [ConsultationDescription] NVARCHAR(MAX) NULL, 
    [UserID] NVARCHAR(128) NULL, 
    [ChangeDate] DATETIME NULL, 
    [OwnerID] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_OralConsultation_Resident] FOREIGN KEY ([ResidentID]) REFERENCES [Resident]([ResidentID]),
	CONSTRAINT [FK_OralConsultation_Issue] FOREIGN KEY ([IssueID]) REFERENCES [Issue]([IssueID])
)
