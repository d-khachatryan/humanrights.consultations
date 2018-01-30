ALTER TABLE [dbo].[TypeConsultationDeclarationType] DROP CONSTRAINT [FK_TypeConsultationDeclarationType_ResponseContent]
ALTER TABLE [dbo].[TypeConsultationDeclarationType] DROP COLUMN [ResponseContentID]
ALTER TABLE [dbo].[TypeConsultationDeclarationType] ADD [ResponseContent] NVARCHAR(100)

ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] DROP CONSTRAINT [FK_TmpTypeConsultationDeclarationType_ResponseContent]
ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] DROP COLUMN [ResponseContentID]
ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] ADD [ResponseContent] NVARCHAR(100)
