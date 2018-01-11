CREATE TABLE [dbo].[TypeConsultationDeclarationType] (
    [TypeConsultationDeclarationTypeID] INT IDENTITY (1, 1) NOT NULL,
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
    PRIMARY KEY CLUSTERED ([TypeConsultationDeclarationTypeID] ASC),
    CONSTRAINT [FK_TypeConsultationDeclarationType_DeclarationType] FOREIGN KEY ([DeclarationTypeID]) REFERENCES [dbo].[DeclarationType] ([DeclarationTypeID]),
	CONSTRAINT [FK_TypeConsultationDeclarationType_ResponseType] FOREIGN KEY ([ResponseTypeID]) REFERENCES [dbo].[ResponseType] ([ResponseTypeID]),
    CONSTRAINT [FK_TypeConsultationDeclarationType_ResponseContent] FOREIGN KEY ([ResponseContentID]) REFERENCES [dbo].[ResponseContent] ([ResponseContentID]),
	CONSTRAINT [FK_TypeConsultationDeclarationType_ResponseQuality] FOREIGN KEY ([ResponseQualityID]) REFERENCES [dbo].[ResponseQuality] ([ResponseQualityID]),
    CONSTRAINT [FK_TypeConsultationDeclarationType_TypeConsultation] FOREIGN KEY ([TypeConsultationID]) REFERENCES [dbo].[TypeConsultation] ([TypeConsultationID]) ON DELETE CASCADE
);


