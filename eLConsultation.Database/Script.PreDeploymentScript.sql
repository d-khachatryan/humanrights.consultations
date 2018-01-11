/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF EXISTS (SELECT * FROM sys.tables where name = 'Setting')
DELETE FROM dbo.Setting 

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpOralConsultationConsultant')
DELETE FROM dbo.TmpOralConsultationConsultant 

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpOralConsultationOrganization')
DELETE FROM dbo.TmpOralConsultationOrganization 

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpOralConsultationRight')
DELETE FROM dbo.TmpOralConsultationRight

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpOralConsultationPermission')
DELETE FROM dbo.TmpOralConsultationPermission 

IF EXISTS (SELECT * FROM sys.tables where name = 'OralConsultationConsultant')
DELETE FROM dbo.OralConsultationConsultant 

IF EXISTS (SELECT * FROM sys.tables where name = 'OralConsultationOrganization')
DELETE FROM dbo.OralConsultationOrganization 

IF EXISTS (SELECT * FROM sys.tables where name = 'OralConsultationRight')
DELETE FROM dbo.OralConsultationRight 

IF EXISTS (SELECT * FROM sys.tables where name = 'OralConsultationPermission')
DELETE FROM dbo.OralConsultationPermission 

IF EXISTS (SELECT * FROM sys.tables where name = 'OralConsultation')
DELETE FROM dbo.OralConsultation 

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpTypeConsultationConsultant')
DELETE FROM dbo.TmpTypeConsultationConsultant

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpTypeConsultationInstance')
DELETE FROM dbo.TmpTypeConsultationInstance

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpTypeConsultationRecipient')
DELETE FROM dbo.TmpTypeConsultationRecipient 

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpTypeConsultationDeclarationType')
DELETE FROM dbo.TmpTypeConsultationDeclarationType 

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpTypeConsultationRight')
DELETE FROM dbo.TmpTypeConsultationRight

IF EXISTS (SELECT * FROM sys.tables where name = 'TmpTypeConsultationPermission')
DELETE FROM dbo.TmpTypeConsultationPermission 

IF EXISTS (SELECT * FROM sys.tables where name = 'TypeConsultationConsultant')
DELETE FROM dbo.TypeConsultationConsultant

IF EXISTS (SELECT * FROM sys.tables where name = 'TypeConsultationInstance')
DELETE FROM dbo.TypeConsultationInstance

IF EXISTS (SELECT * FROM sys.tables where name = 'TypeConsultationRecipient')
DELETE FROM dbo.TypeConsultationRecipient 

IF EXISTS (SELECT * FROM sys.tables where name = 'TypeConsultationDeclarationType')
DELETE FROM dbo.TypeConsultationDeclarationType 

IF EXISTS (SELECT * FROM sys.tables where name = 'TypeConsultationRight')
DELETE FROM dbo.TypeConsultationRight

IF EXISTS (SELECT * FROM sys.tables where name = 'TypeConsultationPermission')
DELETE FROM dbo.TypeConsultationPermission 

IF EXISTS (SELECT * FROM sys.tables where name = 'TypeConsultation')
DELETE FROM dbo.TypeConsultation 

IF EXISTS (SELECT * FROM sys.tables where name = 'Issue')
DELETE FROM dbo.Issue

IF EXISTS (SELECT * FROM sys.tables where name = 'IssueType')
DELETE FROM dbo.IssueType

IF EXISTS (SELECT * FROM sys.tables where name = 'IssueCategory')
DELETE FROM dbo.IssueCategory

IF EXISTS (SELECT * FROM sys.tables where name = 'Company')
DELETE FROM dbo.Company

IF EXISTS (SELECT * FROM sys.tables where name = 'Resident')
DELETE FROM dbo.Resident 

IF EXISTS (SELECT * FROM sys.tables where name = 'Community')
DELETE FROM dbo.Community

IF EXISTS (SELECT * FROM sys.tables where name = 'Region')
DELETE FROM dbo.Region 

