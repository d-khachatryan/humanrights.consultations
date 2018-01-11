CREATE TABLE [dbo].[TmpOralConsultationConsultant] (
    [ID] INT NOT NULL IDENTITY, 
    [OralConsultationConsultantID]   INT              NULL,
    [OralConsultationID]             INT              NULL,
    [ConsultantID]                   INT              NULL,
    [GUID] UNIQUEIDENTIFIER NULL
    CONSTRAINT [FK_TmpOralConsultationConsultant_Consultant] FOREIGN KEY ([ConsultantID]) REFERENCES [dbo].[Consultant] ([ConsultantID]), 
    CONSTRAINT [PK_TmpOralConsultationConsultant] PRIMARY KEY ([ID])
);

