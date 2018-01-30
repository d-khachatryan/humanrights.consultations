CREATE TABLE [dbo].[TmpTypeConsultationDeclarationType] (
    [ID] INT NOT NULL IDENTITY, 
    [TypeConsultationDeclarationTypeID] INT NULL,
    [TypeConsultationID] INT NULL,
    [DeclarationTypeID] INT NULL,
	[DeclarationURL] NVARCHAR(50) NULL,
    [DeclarationDeadline] DATE NULL, 
    [DeclarationDate] DATE NULL, 
    [OrganizationID] INT NULL, 
    [ResponseDate] DATE NULL, 
    [ResponseTypeID] INT NULL, 
    [ResponseContentID] INT NULL, 
    [ResponseQualityID] INT NULL, 
	[GUID] UNIQUEIDENTIFIER NOT NULL
    CONSTRAINT [FK_TmpTypeConsultationDeclarationType_DeclarationType] FOREIGN KEY ([DeclarationTypeID]) REFERENCES [dbo].[DeclarationType] ([DeclarationTypeID])
	CONSTRAINT [FK_TmpTypeConsultationDeclarationType_ResponseType] FOREIGN KEY ([ResponseTypeID]) REFERENCES [dbo].[ResponseType] ([ResponseTypeID])
    CONSTRAINT [FK_TmpTypeConsultationDeclarationType_ResponseContent] FOREIGN KEY ([ResponseContentID]) REFERENCES [dbo].[ResponseContent] ([ResponseContentID])
	CONSTRAINT [FK_TmpTypeConsultationDeclarationType_ResponseQuality] FOREIGN KEY ([ResponseQualityID]) REFERENCES [dbo].[ResponseQuality] ([ResponseQualityID])
	CONSTRAINT [PK_TypeConsultationDeclarationType] PRIMARY KEY ([ID])
);

