--1.0.2.3
UPDATE dbo.Setting SET SettingValue = '1.0.2.3' WHERE SettingItem = 'version'
ALTER TABLE [TypeConsultationDeclarationType] ALTER COLUMN [DeclarationURL] nvarchar(1000)
ALTER TABLE [TypeConsultationDeclarationType] ALTER COLUMN [ResponseContent] nvarchar(1000)
ALTER TABLE [TmpTypeConsultationDeclarationType] ALTER COLUMN [DeclarationURL] nvarchar(1000)
ALTER TABLE [TmpTypeConsultationDeclarationType] ALTER COLUMN [ResponseContent] nvarchar(1000)
--1.0.2.3