CREATE TABLE [dbo].[TmpTypeConsultationConsultant] (
    [ID] INT NOT NULL IDENTITY, 
    [TypeConsultationConsultantID]   INT              NULL,
    [TypeConsultationID]             INT              NULL,
    [ConsultantID]                      INT              NULL,
	[GUID] UNIQUEIDENTIFIER NOT NULL
    CONSTRAINT [FK_TmpTypeConsultationConsultant_Consultant] FOREIGN KEY ([ConsultantID]) REFERENCES [dbo].[Consultant] ([ConsultantID]), 
    CONSTRAINT [PK_TmpTypeConsultationConsultant] PRIMARY KEY ([ID])
	);

