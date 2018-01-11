CREATE TABLE [dbo].[TypeConsultation] (
    [TypeConsultationID] INT NOT NULL PRIMARY KEY IDENTITY,
    [TypeConsultationName] NVARCHAR (500) NULL,
    [ResidentID] INT NULL,
	[IssueID] INT NULL, 
    [TypeConsultationDate] DATE NULL,
    [ConsultationTypeID] INT NULL,
    [ProcessStatusID] INT NULL,
    [ConsultationResultID] INT NULL,
    [TargetGroupID] INT NULL,
    [UserID] NVARCHAR(128) NULL, 
    [ChangeDate] DATETIME NULL, 
    [OwnerID] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_TypeConsultation_ConsultationResult] FOREIGN KEY ([ConsultationResultID]) REFERENCES [dbo].[ConsultationResult] ([ConsultationResultID]),
    CONSTRAINT [FK_TypeConsultation_ConsultationType] FOREIGN KEY ([ConsultationTypeID]) REFERENCES [dbo].[ConsultationType] ([ConsultationTypeID]),
    CONSTRAINT [FK_TypeConsultation_ProcessStatus] FOREIGN KEY ([ProcessStatusID]) REFERENCES [dbo].[ProcessStatus] ([ProcessStatusID]),
    CONSTRAINT [FK_TypeConsultation_Resident] FOREIGN KEY ([ResidentID]) REFERENCES [dbo].[Resident] ([ResidentID]),
	CONSTRAINT [FK_TypeConsultation_Issue] FOREIGN KEY ([IssueID]) REFERENCES [Issue]([IssueID]),
    CONSTRAINT [FK_TypeConsultation_TargetGroup] FOREIGN KEY ([TargetGroupID]) REFERENCES [dbo].[TargetGroup] ([TargetGroupID])
);


