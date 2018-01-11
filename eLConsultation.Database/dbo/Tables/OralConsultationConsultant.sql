CREATE TABLE [dbo].[OralConsultationConsultant] (
    [OralConsultationConsultantID] INT IDENTITY (1, 1) NOT NULL,
    [OralConsultationID]           INT NULL,
    [ConsultantID]                 INT NULL,
    CONSTRAINT [PK__OralCons__30473F9EB9A762E2] PRIMARY KEY CLUSTERED ([OralConsultationConsultantID] ASC),
    CONSTRAINT [FK_OralConsultationConsultant_OralConsultation] FOREIGN KEY ([OralConsultationID]) REFERENCES [dbo].[OralConsultation] ([OralConsultationID]) ON DELETE CASCADE,
	CONSTRAINT [FK_OralConsultationConsultant_Consultant] FOREIGN KEY ([ConsultantID]) REFERENCES [dbo].[Consultant] ([ConsultantID])
);


