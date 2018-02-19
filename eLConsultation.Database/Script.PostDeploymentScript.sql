/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM dbo.Setting
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('server', 'email', 'smtp.gmail.com')
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('password', 'email', 'HCAV12345678')
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('email', 'email', 'dbadmin@hcav.am')
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('port', 'email', '587')
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('deliverymethod', 'email', '0')
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('usedefaultcredentials', 'email', 'false')
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('enablessl', 'email', 'true')
INSERT INTO dbo.Setting (SettingItem, SettingGroup, SettingValue) VALUES ('version', 'application', '1.0.0.0')


DELETE FROM dbo.[AspNetUsers]
DELETE FROM dbo.[AspNetRoles]
GO

INSERT INTO [dbo].[AspNetRoles]([Id],[Name])VALUES(NEWID(),'administrator')
INSERT INTO [dbo].[AspNetRoles]([Id],[Name])VALUES(NEWID(),'reader')
INSERT INTO [dbo].[AspNetRoles]([Id],[Name])VALUES(NEWID(),'writer')
INSERT INTO [dbo].[AspNetRoles]([Id],[Name])VALUES(NEWID(),'reportspecialist')

DELETE FROM dbo.Resident
GO

DELETE FROM dbo.IssueType
GO
SET IDENTITY_INSERT IssueType ON 
INSERT INTO dbo.IssueType (IssueTypeID,IssueTypeName) VALUES (1,N'Այլ չդասակարգված');
SET IDENTITY_INSERT IssueType OFF 


DELETE FROM dbo.IssueCategory 
GO
SET IDENTITY_INSERT IssueCategory ON 
INSERT INTO dbo.IssueCategory (IssueCategoryID,IssueCategoryName) VALUES (1,N'Քաղաքացի');
INSERT INTO dbo.IssueCategory (IssueCategoryID,IssueCategoryName) VALUES (2,N'Կազմակերպություն');
SET IDENTITY_INSERT IssueCategory OFF 


DELETE FROM dbo.ResponseQuality 
GO
SET IDENTITY_INSERT ResponseQuality ON 
INSERT INTO dbo.ResponseQuality (ResponseQualityID,ResponseQualityName) VALUES (1,N'Ըստ էության պատասխան');
INSERT INTO dbo.ResponseQuality (ResponseQualityID,ResponseQualityName) VALUES (2,N'Ոչ ըստ էության պատասխան');
INSERT INTO dbo.ResponseQuality (ResponseQualityID,ResponseQualityName) VALUES (3,N'Ըստ էության պատասխան դիմումի հիմնավոր մերժմամբ');
INSERT INTO dbo.ResponseQuality (ResponseQualityID,ResponseQualityName) VALUES (4,N'Ըստ էության պատասխան դիմումի անհիմն մերժմամբ');
INSERT INTO dbo.ResponseQuality (ResponseQualityID,ResponseQualityName) VALUES (5,N'Ըստ էության պատասխան դիմումի պահանջի բավարարմամբ');
INSERT INTO dbo.ResponseQuality (ResponseQualityID,ResponseQualityName) VALUES (6,N'Միջանկյալ պատասխան');
SET IDENTITY_INSERT ResponseQuality OFF 

DELETE FROM dbo.ResponseType 
GO
SET IDENTITY_INSERT ResponseType ON 
INSERT INTO dbo.ResponseType (ResponseTypeID,ResponseTypeName) VALUES (1,N'Ժամանակին');
INSERT INTO dbo.ResponseType (ResponseTypeID,ResponseTypeName) VALUES (2,N'Ուշացումով');
SET IDENTITY_INSERT ResponseType OFF 

DELETE FROM dbo.Gender
GO
SET IDENTITY_INSERT Gender ON 
INSERT INTO dbo.Gender (GenderID,GenderName) VALUES (1,N'Արական');
INSERT INTO dbo.Gender (GenderID,GenderName) VALUES (2,N'Իգական');
INSERT INTO dbo.Gender (GenderID,GenderName) VALUES (3,N'Այլ');
SET IDENTITY_INSERT Gender OFF 


DELETE FROM dbo.AgeGroup
GO
SET IDENTITY_INSERT AgeGroup ON 
INSERT INTO dbo.AgeGroup (AgeGroupID,AgeGroupName) VALUES (1,N'0-18');
INSERT INTO dbo.AgeGroup (AgeGroupID,AgeGroupName) VALUES (2,N'19-30');
INSERT INTO dbo.AgeGroup (AgeGroupID,AgeGroupName) VALUES (3,N'31-45');
INSERT INTO dbo.AgeGroup (AgeGroupID,AgeGroupName) VALUES (4,N'46-55');
INSERT INTO dbo.AgeGroup (AgeGroupID,AgeGroupName) VALUES (5,N'56-65');
INSERT INTO dbo.AgeGroup (AgeGroupID,AgeGroupName) VALUES (6,N'66 և ավելի');
SET IDENTITY_INSERT AgeGroup OFF 

DELETE FROM dbo.ConsultationType
GO
SET IDENTITY_INSERT ConsultationType ON 
INSERT INTO dbo.ConsultationType (ConsultationTypeID,ConsultationTypeName) VALUES (1,N'Ռազմավարական');
INSERT INTO dbo.ConsultationType (ConsultationTypeID,ConsultationTypeName) VALUES (2,N'Ոչ ռազմավարական');
SET IDENTITY_INSERT ConsultationType OFF 

DELETE FROM dbo.DeclarationType
GO
SET IDENTITY_INSERT DeclarationType ON 
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (1,N'Տեղեկատվության հարցում');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (2,N'Հայցադիմում (դիմում դատարան)');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (3,N'Հաղորդում');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (4,N'Դիմում');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (5,N'Վերաքննիչ բողոք');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (6,N'Վճռաբեկ բողոք');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (7,N'Վարչական բողոք');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (8,N'Հայտարարություն');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (9,N'Միջնորդություն');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (10,N'Դիմում-բողոք');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (11,N'Հակընդդեմ հայցադիմում');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (12,N'Հայցադիմումի պատասխան');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (13,N'Առարկություն');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (14,N'Վերաքննիչ բողոքի պատասխան');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (15,N'Վճռաբեկ բողոքի պատասխան');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (16,N'Դիմում սահմանադրական դատարան');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (17,N'Դիմում եվրոպական դատարան');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (18,N'Լրացուցիչ տեղեկատվության հարցում');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (19,N'Ճառ');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (20,N'Պահանջագիր');
INSERT INTO dbo.DeclarationType (DeclarationTypeID,DeclarationTypeName) VALUES (21,N'Բողոք');
SET IDENTITY_INSERT DeclarationType OFF 



DELETE FROM dbo.HumanRight
GO
SET IDENTITY_INSERT HumanRight ON 
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (1,N'Կյանքի իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (2,N'Խոշտանգումներից զերծ մնալու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (3,N'Ստրկությունից և հարկադիր աշխատանքից զերծ մնալու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (4,N'Ազատության և անձնական անձեռնմխելիության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (5,N'Արդար դատաքննության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (6,N'Անձնական և ընտանեկան կյանքը հարգելու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (7,N'Մտքի, խղճի և կրոնի ազատության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (8,N'Արտահայտվելու ազատության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (9,N'Հավաքների և միավորման ազատության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (10,N'Ամուսնության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (11,N'Իրավական պաշտպանության արդյունավետ միջոցի իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (12,N'Խտրականությունից զերծ մնալու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (13,N'Աշխատանքի ընտրության ազատություն իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (14,N'Տնտեսական գործունեության ազատությունը և տնտեսական մրցակցության');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (15,N'Վնասի հատուցման իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (16,N'Պատշաճ վարչարարության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (17,N'Ընտրական իրավունքը և հանրաքվեին մասնակցելու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (18,N'Կրթության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (19,N'Իրավաբանական օգնություն ստանալու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (20,N'Անմեղության կանխավարկածի իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (21,N'Բնակարանի անձեռնմխելիության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (22,N'Ազատ տեղաշարժվելու և բնակավայր ընտրելու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (23,N'Սեփականության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (24,N'Սոցիալական ապահովության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (25,N'Առողջության պաշտպանվածության իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (26,N'Բարենպաստ շրջակա միջավայր ունենալու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (27,N'Միավորումներ կազմելու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (28,N'Խաղաղ, առանց զենքի հավաքներ անցկացնելու իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (29,N'Ընտրելու և հանրաքվեներին մասնակցելու, իրավունք');
INSERT INTO dbo.HumanRight (HumanRightID,HumanRightName) VALUES (30,N'Վարչական մարմնի կողմից պատճառված վնասի վերականգնման իրավունք');
SET IDENTITY_INSERT HumanRight OFF 

DELETE FROM dbo.TargetGroup
GO
SET IDENTITY_INSERT TargetGroup ON 
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (1,N'Հոգեկան և մտավոր, ֆիզիկական հաշմանդամություն ունեցող անձինք');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (2,N'Թմրամիջոց գործածողներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (3,N'Դատապարտյալներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (4,N'Կալանավորներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (5,N'Զինծառայողներ/վաղաժամ զորացրված զինծառայողներ և նրանց ընտանիքի անդամներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (6,N'Զորակոչիկներ և նրանց ընտանիքների անդամներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (7,N'Մահացած զինծառայողների ընտանիքների անդամներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (8,N'Ռազմագերիներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (9,N'Անհայտ կորածներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (10,N'Հակամարտություններից տուժածներ և նրանց ընտանիքների անդամներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (11,N'Քրեական գործերում ներգրավված վկաներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (12,N'Քաղաքացիական և քաղաքական ակտիվիստներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (13,N'Ընտրողներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (14,N'Ընտրություններին դիտորդություն իրականացնող անձ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (15,N'Կրոնական փոքրամասնություններ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (16,N'Սոցիալապես խոցելի խմբեր');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (17,N'0-5 տարեկան երեխաներ');
INSERT INTO dbo.TargetGroup (TargetGroupID,TargetGroupName) VALUES (18,N'Դպրոցականներ');
SET IDENTITY_INSERT TargetGroup OFF 

DELETE FROM dbo.Organization
GO
SET IDENTITY_INSERT Organization ON 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (1,N'ՀՀ Ընդհանուր իրավասության դատարան');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (2,N'ՀՀ վարչական դատարան');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (3,N'ՀՀ վերաքննիչ դատարան');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (4,N'ՀՀ վճռաբեկ դատարան');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (5,N'ՀՀ Սահմանադրական դատարան');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (6,N'Անշարժ գույքի կադաստրի պետական կոմիտե');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (7,N'ՀՀ հատուկ քննչական ծառայություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (8,N'ՀՀ քննչական կոմիտե');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (9,N'Զինվորական դատախազություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (10,N'ՀՀ դատախազություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (11,N'Դատական ակտերի հարկադիր կատարման ծառայություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (12,N'Տեղական ինքնակառավարման մարմիններ'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (13,N'Մարզպետարաններ'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (14,N'Պաշտպանության նախարարություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (15,N'ՀՀ աշխատանքի և սոցիալական հարցերի նախարարություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (16,N'ՀՀ արդարադատության նախարարություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (17,N'ՀՀ առողջապահության նախարարություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (18,N'ՀՀ կրթության գիտության նախարարություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (19,N'Փաստաբանների պալատ /հանրային պաշտպանի գրասենյակ/');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (20,N'ՀՀ ԱՆ աշխատակազմի առողջապահական պետական տեսչության Արդարադատության խորհուրդ'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (21,N'ՀՀ ազգային արխիվ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (22,N'Բժշկասոցիալական փորձաքննական հանձնաժողով');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (23,N'Ապահովագրական ընկերություններ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (24,N'Հարկային տեսչություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (25,N'Մաքսային տեսչություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (26,N'Հոգեբուժական հաստատություններ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (27,N'Քաղաքացիական կացության ակտերի գրանցման բաժին');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (28,N'Քրեակատարողական հիմնարկներ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (29,N'Քրեակատարողական վարչություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (30,N'ՀՀ ոստիկանություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (31,N'Եվրոպական դատարան');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (32,N'Դատական դեպարտամենտ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (33,N'Բուժհաստատություններ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (34,N'Ֆինանսական համակարգի հաշտարար');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (35,N'ՀՀ քաղաքաշինության նախարարությունը');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (36,N'Անձնագրային բաժին');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (37,N'ՀՀ ֆինանսների նախարարություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (38,N'ՀՀ կառավարություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (39,N'ՀՀ տարածքային կառավարման և արտակարգ իրավիճակների նախարարություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (40,N'Ճանապարհայաին ոստիկանություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (41,N'Բանկ/առևտրային կազմակերպություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (42,N'ՀՀ զինվորական կոմիսար'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (43,N'Բնապահպանության նախարարություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (44,N'ՀՀ Արտաքին գործերի նախարարություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (45,N'ՀՀ Միգրացիոն պետական ծառայություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (46,N'ՀՀ ազգային անվտանգության ծառայություն'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (47,N'Էլեկտրական ցանցեր'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (48,N'Գործատու');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (49,N'ՀՀ մարդու իրավունքների պաշտպան'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (50,N'ՀՀ նոտարական պալատ'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (51,N'ՀՀ Ազգային Ժողովի էթիկայի հանձնաժողով'); 
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (52,N'ՀՀ Նախագահ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (53,N'ՀՀ ազգային վիճակագրական վարչություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (54,N'Սնանկության գործով կառավարիչ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (55,N'Շտապօգնության ծառայություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (56,N'Փորձագիտական կենտրոն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (57,N'Իրավաբանական անձանց պետական ռեսգիստր');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (58,N'ՀՀ կառավարությանն առընթեր պետական եկամուտների կոմիտե');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (59,N'ՀՀ ԱՍՀՆ զբաղվածության պետական գործակալություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (60,N'Հայփոստ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (61,N'ՀՀ տրանսպորտի և կապի նախարարություն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (62,N'ՀՀ ԱԻՆ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (63,N'Ջրմուղկոյուղի');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (64,N'Հայռուսգազարդ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (65,N'Հայաստանի Հանրապետության զինկոմ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (66,N'ՀՀ տարածքային զինկոմիսարիատ');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (67,N'ՀՀ կենտրոնական բժշկական հանձնաժողով');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (68,N'ՀՀ կենտրոնական ռազմաբժշկական հանձնաժողով');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (69,N'ՀՀ հանրապետական զորակոչային հանձնաժողով');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (70,N'Հանրապետական դատական բժշկության գիտագործնական կենտրոն');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (71,N'ՀՀ ԿԱ քաղաքաշինության պետական կոմիտե');
INSERT INTO dbo.Organization (OrganizationID,OrganizationName) VALUES (72,N'ՀՀ ԿԸՀ');
SET IDENTITY_INSERT Organization OFF


DELETE FROM dbo.ProcessStatus
GO

SET IDENTITY_INSERT ProcessStatus ON  
INSERT INTO dbo.ProcessStatus (ProcessStatusID,ProcessStatusName) VALUES (1,N'Դատարան');
INSERT INTO dbo.ProcessStatus (ProcessStatusID,ProcessStatusName) VALUES (2,N'Նախաքննություն');
INSERT INTO dbo.ProcessStatus (ProcessStatusID,ProcessStatusName) VALUES (3,N'Հետաքննություն');
SET IDENTITY_INSERT ProcessStatus OFF

DELETE FROM dbo.ConsultationResult
GO

SET IDENTITY_INSERT ConsultationResult ON  
INSERT INTO dbo.ConsultationResult (ConsultationResultID,ConsultationResultName) VALUES (1,N'Միջանկյալ հաղթանակ');
INSERT INTO dbo.ConsultationResult (ConsultationResultID,ConsultationResultName) VALUES (2,N'Վերջնական հաղթանակ');
INSERT INTO dbo.ConsultationResult (ConsultationResultID,ConsultationResultName) VALUES (3,N'Այլ');
SET IDENTITY_INSERT ConsultationResult OFF


DELETE FROM dbo.InvocationType
GO

SET IDENTITY_INSERT InvocationType ON  
INSERT INTO dbo.InvocationType (InvocationTypeID,InvocationTypeName) VALUES (1,N'Անձամբ');
INSERT INTO dbo.InvocationType (InvocationTypeID,InvocationTypeName) VALUES (2,N'Փոստով');
INSERT INTO dbo.InvocationType (InvocationTypeID,InvocationTypeName) VALUES (3,N'Թեժ գիծ');
SET IDENTITY_INSERT InvocationType OFF



DELETE FROM dbo.Region
GO

SET IDENTITY_INSERT Region ON  

INSERT INTO dbo.Region (RegionID,RegionName) VALUES (8,N'Շիրակ');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (11,N'Լոռի');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (6,N'Տավուշ');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (5,N'Արագածոտն');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (9,N'Կոտայք');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (7,N'Գեղարքունիք');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (10,N'Երևան');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (4,N'Արարատ');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (1,N'Վայոց Ձոր');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (2,N'Սյունիք');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (3,N'Արմավիր');
INSERT INTO dbo.Region (RegionID,RegionName) VALUES (12,N'Արտերկիր');
SET IDENTITY_INSERT Region OFF 
GO


DELETE FROM dbo.ProcessStatus 
GO
SET IDENTITY_INSERT ProcessStatus ON 
INSERT INTO dbo.ProcessStatus (ProcessStatusID,ProcessStatusName) VALUES (1,N'Դատարան');
INSERT INTO dbo.ProcessStatus (ProcessStatusID,ProcessStatusName) VALUES (2,N'Նախաքննություն');
INSERT INTO dbo.ProcessStatus (ProcessStatusID,ProcessStatusName) VALUES (3,N'Այլ');
SET IDENTITY_INSERT ProcessStatus OFF 

DELETE FROM dbo.InvocationType 
GO
SET IDENTITY_INSERT InvocationType ON 
INSERT INTO dbo.InvocationType (InvocationTypeID,InvocationTypeName) VALUES (1,N'Անձամբ');
INSERT INTO dbo.InvocationType (InvocationTypeID,InvocationTypeName) VALUES (2,N'Փոստով');
INSERT INTO dbo.InvocationType (InvocationTypeID,InvocationTypeName) VALUES (3,N'Թեժ գիծ');
SET IDENTITY_INSERT InvocationType OFF 


DELETE FROM [dbo].[Community]
GO
SET IDENTITY_INSERT [dbo].[Community] ON 

INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (2, 11, N'ՇԱՄԼՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (4, 8, N'ՓՈՔՐ ՍԱՐԻԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (9, 2, N'ՕԽՏԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (22, 3, N'ՎԱՂԱՐՇԱՊԱՏ (ԷՋՄԻԱԾԻՆ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (23, 3, N'ԳԵՂԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (24, 3, N'ՀԱՑԻԿ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (25, 4, N'ՄԱՍԻՍ ք.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (31, 4, N'ԵՐԱՍԽ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (32, 1, N'ՄԱԼԻՇԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (36, 2, N'ԱՂԻՏՈՒ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (50, 2, N'ԱԼՎԱՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (51, 2, N'ՆՌՆԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (52, 6, N'ԾԱՂԿԱՎԱՆ (ՏԱՈՒՇԻ Տ/Շ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (53, 8, N'ՄԵԾ ՍԱՐԻԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (63, 3, N'ՋՐԱՐԲԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (66, 9, N'ԳԵՏԱՐԳԵԼ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (69, 3, N'ՍԱՐԴԱՐԱՊԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (70, 3, N'ԱՅԳԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (72, 3, N'ԱԼԱՇԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (74, 3, N'ԵՂԵԳՆՈՒՏ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (75, 4, N'ԶՈՐԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (76, 7, N'ԳԵՂՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (81, 8, N'ԶՈՐԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (86, 11, N'ՀԱԼԱՎԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (88, 11, N'ՔԱՐԱԲԵՐԴ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (91, 11, N'ՇԱՀՈՒՄՅԱՆ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (98, 8, N'ԹՈՐՈՍԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (99, 7, N'ԱՎԱԶԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (100, 8, N'ԾԱՂԿՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (101, 8, N'ՍԱՐԱԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (102, 8, N'ԲԱՎՐԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (103, 8, N'ՍԻԶԱՎԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (104, 8, N'ԳԱՌՆԱՌԻՃ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (105, 8, N'ԱՐԴԵՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (106, 8, N'ԱՂՎՈՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (107, 8, N'ԹԱՎՇՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (108, 8, N'ՂԱԶԱՆՉԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (109, 8, N'ՇԱՂԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (110, 8, N'ԲԵՐԴԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (111, 8, N'ԱԼՎԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (112, 8, N'ՄԵԾ ՍԵՊԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (113, 8, N'ՓՈՔՐ ՍԵՊԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (114, 8, N'ԱՇՈՑՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (115, 8, N'ԶԱՐԻՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (116, 8, N'ԿՐԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (117, 8, N'ԿԱՐՄՐԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (118, 8, N'ԶՈՒՅԳԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (119, 8, N'ՀԱՐԹԱՇԵՆ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (120, 8, N'ՄՈՒՍԱՅԵԼՅԱՆ ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (121, 11, N'ՄԵԾԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (122, 11, N'ՊԱՂԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (123, 11, N'ՁՅՈՒՆԱՇՈՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (124, 11, N'ՁՈՐԱՄՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (125, 11, N'ՆՈՐԱՇԵՆ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (126, 11, N'ԱՐԾՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (127, 11, N'ՍԱՐՉԱՊԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (128, 11, N'ՄԻԽԱՅԵԼՈՎԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (129, 11, N'ԼԵՌՆԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (130, 11, N'ՊՐԻՎՈԼՆՈՅԵ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (131, 8, N'ԱՄԱՍԻԱ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (132, 8, N'ՀՈՎՏՈՒՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (133, 8, N'ԱՐԵԳՆԱԴԵՄ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (134, 8, N'ԳՏԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (135, 8, N'ՋՐԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (136, 8, N'ՀՈՂՄԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (137, 8, N'ԲԱՆԴԻՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (138, 8, N'ԳՈԳՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (139, 8, N'ԱՐՓԵՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (141, 8, N'ՓՈՔՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (142, 8, N'ԼԵՌՆՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (143, 8, N'ՔԵԹԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (144, 8, N'ՋԱՋՈՒՌ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (145, 3, N'ՄԱՅԻՍՅԱՆ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (146, 8, N'ՄԱՅԻՍՅԱՆ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (147, 8, N'ՀԱՑԻԿ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (148, 8, N'ԳՅՈՒՄՐԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (149, 8, N'ԱԽՈՒՐՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (151, 8, N'ԱՌԱՓԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (152, 8, N'ՈՍԿԵՀԱՍԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (153, 8, N'ԱԽՈՒՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (154, 8, N'ՂԱՐԻԲՋԱՆՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (155, 8, N'ԱԶԱՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (156, 8, N'ԳԵՏՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (157, 11, N'ՍՊԻՏԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (158, 11, N'ՍԱՐԱՀԱՐԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (159, 11, N'ՀԱՐԹԱԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (160, 11, N'ԿԱԹՆԱՋՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (161, 11, N'ԼԵՌՆԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (162, 11, N'ՋՐԱՇԵՆ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (163, 11, N'ԾԱՂԿԱԲԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (164, 8, N'ՋՐԱՌԱՏ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (165, 11, N'ՍԱՐԱՄԵՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (166, 11, N'ԼԵՌՆԱՆՑՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (167, 11, N'ՆՈՐ ԽԱՉԱԿԱՊ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (168, 11, N'ԴԱՐՊԱՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (169, 11, N'ԼԵՌՆԱՊԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (170, 11, N'ՎԱՆԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (171, 11, N'ԳՈՒԳԱՐՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (172, 11, N'ԼԵՐՄՈՆՏՈՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (173, 11, N'ՄԱՐԳԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (174, 11, N'ՖԻԱԼԵՏՈՎՈ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (175, 11, N'ՄԵԾ ՊԱՌՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (176, 11, N'ԳԵՂԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (177, 11, N'ԳՈԳԱՐԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (178, 11, N'ՍԱՐԱԼԱՆՋ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (179, 11, N'ՇԻՐԱԿԱՄՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (180, 11, N'ՇԵՆԱՎԱՆ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (181, 8, N'ԼԵՌՆԱԳՅՈՒՂ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (182, 11, N'ԱՐԵՎԱՇՈՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (183, 11, N'ՔԱՐԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (185, 11, N'ՂՈՒՐՍԱԼ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (186, 11, N'ԱԶՆՎԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (187, 11, N'ԱՆՏԱՌԱՄՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (188, 11, N'ՁՈՐԱԳՅՈՒՂ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (189, 11, N'ԿՈՒՐԹԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (190, 11, N'ԱՐԵՎԱԾԱԳ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (191, 11, N'ԴՍԵՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (192, 11, N'ՕՁՈՒՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (193, 11, N'ՍՎԵՐԴԼՈՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (194, 11, N'ՄԵԴՈՎԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (195, 11, N'ՈՒՌՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (196, 11, N'ԲՈՎԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (197, 11, N'ՈՒՐԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (198, 11, N'ՍՏԵՓԱՆԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (199, 11, N'ԳՅՈՒԼԱԳԱՐԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (200, 11, N'ԳԱՐԳԱՌ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (201, 11, N'ՊՈՒՇԿԻՆՈ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (203, 11, N'ՀՈԲԱՐՁԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (205, 11, N'ՎԱՐԴԱԲԼՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (206, 11, N'ԾԱԹԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (207, 11, N'ՄԱՐՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (209, 11, N'ՔԱՐԻՆՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (210, 11, N'ԼՈՐՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (211, 11, N'ՇԱՄՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (212, 11, N'ԱԹԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (213, 11, N'ԱՀՆԻՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (214, 11, N'ՎԱՀԱԳՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (215, 11, N'ԴԵԲԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (216, 11, N'ԵՂԵԳՆՈՒՏ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (218, 11, N'ԲԱԶՈՒՄ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (219, 11, N'ԱՐՋՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (220, 8, N'ՀԱՅԿԱՎԱՆ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (221, 8, N'ՈՂՋԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (222, 5, N'ԼԵՌՆԱՊԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (223, 5, N'ՍԻՓԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (224, 5, N'ՃԱՐՃԱԿԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (225, 5, N'ՄԻՋՆԱՏՈՒՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (226, 5, N'ԱՎՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (227, 5, N'ԱԼԱԳՅԱԶ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (228, 3, N'ԱՐԵՎԻԿ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (229, 8, N'ԱՐԵՎԻԿ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (230, 8, N'ԲԱՍԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (231, 8, N'ԿԱՌՆՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (232, 6, N'ԾԱՂԿԱՎԱՆ (ԻՋԵՎԱՆԻ Տ/Շ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (233, 6, N'ՍԵՎՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (234, 6, N'ՎԱԶԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (235, 6, N'ՊԱՌԱՎԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (236, 6, N'ԱՅԳԵՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (237, 11, N'ՏԱՇԻՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (238, 11, N'ԱԼԱՎԵՐԴԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (240, 11, N'ՀԱՂՊԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (241, 11, N'ՃՈՃԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (242, 11, N'ՄԵԾ ԱՅՐՈՒՄ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (243, 11, N'ՇՆՈՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (244, 6, N'ԱՐՃԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (245, 6, N'ԱՅՐՈՒՄ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (246, 6, N'ԼՃԿԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (247, 6, N'ՀԱՂԹԱՆԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (248, 6, N'ԲԱԳՐԱՏԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (249, 6, N'ՊՏՂԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (250, 6, N'ԿՈՂԲ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (251, 11, N'ԱՅԳԵՀԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (252, 11, N'ԱՐԴՎԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (253, 11, N'ՄՂԱՐԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (254, 11, N'ԹՈՒՄԱՆՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (255, 11, N'ԿԱՐՄԻՐ ԱՂԵԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (256, 11, N'ՀԱԳՎԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (257, 11, N'ԱՔՈՐԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (258, 11, N'ՁՈՐԱԳԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (259, 11, N'ՉԿԱԼՈՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (260, 11, N'ՎԱՀԱԳՆԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (261, 11, N'ՓԱՄԲԱԿ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (262, 5, N'ՎԱՐԴԱԲԼՈՒՐ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (263, 5, N'ԲԵՐՔԱՌԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (264, 8, N'ՀԱՅԿԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (265, 8, N'ՋՐԱՓԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (266, 8, N'ԻՍԱՀԱԿՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (267, 8, N'ԼՈՒՍԱՂԲՅՈՒՐ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (268, 8, N'ԳՈՒՍԱՆԱԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (270, 8, N'ՀԱՅՐԵՆՅԱՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (271, 8, N'ՆՈՐ ԿՅԱՆՔ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (272, 8, N'ԳԵՏԱՓ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (273, 8, N'ԱՐԹԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (274, 8, N'ԱՐԵՎՇԱՏ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (275, 8, N'ՓՈՔՐ ՄԱՆԹԱՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (276, 8, N'ՄԵԾ ՄԱՆԹԱՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (277, 8, N'ՍԱՐԱԼԱՆՋ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (278, 8, N'ՆԱՀԱՊԵՏԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (279, 8, N'ՀԱՌԻՃ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (280, 5, N'ՀՆԱԲԵՐԴ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (281, 5, N'ԾԱՂԿԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (282, 5, N'ՆԻԳԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (283, 5, N'ԿԱՆԻԱՇԻՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (285, 5, N'ՇԵՆԿԱՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (286, 5, N'ՄԻՐԱՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (287, 5, N'ԼՈՒՍԱԳՅՈՒՂ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (288, 9, N'ՀԱՆՔԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (289, 9, N'ԱՐՏԱՎԱԶ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (290, 9, N'ՄԱՐՄԱՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (291, 9, N'ՄԵՂՐԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (292, 8, N'ՄԱՐԱԼԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (293, 8, N'ՁՈՐԱԿԱՊ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (294, 8, N'ՊԵՄԶԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (295, 8, N'ԼԵՌՆԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (296, 5, N'ԱՊԱՐԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (297, 5, N'ԿԱՅՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (298, 5, N'ՎԱՐԴԵՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (299, 5, N'ՉՔՆԱՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (300, 5, N'ԹԹՈՒՋՈՒՐ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (301, 5, N'ՁՈՐԱԳԼՈՒԽ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (302, 9, N'ԱՂԱՎՆԱՁՈՐ/Կոտայք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (303, 7, N'ԴԴՄԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (304, 7, N'ԶՈՎԱԲԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (305, 7, N'ԳԵՂԱՄԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (306, 7, N'ՎԱՐՍԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (307, 7, N'ԾՈՎԱԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (308, 7, N'ԿԱԼԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (309, 7, N'ՍԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (310, 7, N'ԴՐԱԽՏԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (311, 7, N'ԹԹՈՒՋՈՒՐ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (312, 7, N'ՃԱՄԲԱՐԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (313, 7, N'ՎԱՀԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (314, 7, N'ԱՂԲԵՐՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (315, 7, N'ԾԱՂԿՈՒՆՔ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (316, 9, N'ԾԱՂԿԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (317, 5, N'ԵՂԻՊԱՏՐՈՒՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (318, 5, N'ՔՈՒՉԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (319, 8, N'ՍԱՌՆԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (320, 8, N'ՁԻԹՀԱՆՔՈՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (321, 8, N'ԼԱՆՋԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (322, 5, N'ԾԱՂԿԱՇԵՆ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (323, 9, N'ՀՐԱԶԴԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (324, 7, N'ԼՃԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (325, 1, N'ԱՂՆՋԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (326, 7, N'ՉԿԱԼՈՎԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (327, 7, N'ՆՈՐԱՇԵՆ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (328, 7, N'ՇՈՐԺԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (329, 7, N'ԱՐՏԱՆԻՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (330, 7, N'ՋԻԼ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (331, 7, N'ԾՈՎԱԶԱՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (332, 7, N'ԼՃԱՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (333, 9, N'ԼԵՌՆԱՆԻՍՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (334, 9, N'ՔԱՂՍԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (336, 9, N'ԲՋՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (337, 9, N'ԲՈՒԺԱԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (338, 5, N'ՇՈՂԱԿՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (339, 5, N'ԵՐՆՋԱՏԱՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (340, 5, N'ՎԱՐԴԵՆՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (341, 5, N'ՇԵՆԱՎԱՆ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (342, 5, N'ՀԱՐԹԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (343, 5, N'ԱՓՆԱԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (344, 5, N'ԳԱՌՆԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (345, 5, N'ԶՈՎԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (346, 5, N'ՄԱՍՏԱՐԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (347, 5, N'ԾԱՂԿԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (348, 5, N'ԶԱՐԻՆՋԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (349, 5, N'ՑԱՄԱՔԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (350, 5, N'ՆՈՐ ԱՐԹԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (351, 5, N'ՍՈՒՍԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (352, 8, N'ԲԱԳՐԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (353, 4, N'ՏԱՓԵՐԱԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (354, 8, N'ԱՆԻՊԵՄԶԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (355, 5, N'ՍՈՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (356, 5, N'ՀԱՑԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (357, 5, N'ԿԱՆՉ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (358, 5, N'ԹԱԹՈՒԼ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (359, 5, N'ԹԱԼԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (360, 5, N'ԱԿՈՒՆՔ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (361, 5, N'ԵՂՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (362, 5, N'ՈՍԿԵԹԱՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (363, 5, N'ԿԱՐՄՐԱՇԵՆ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (364, 5, N'ՇՂԱՐՇԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (365, 5, N'ԻՐԻՆԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (366, 5, N'ՄԵԾԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (367, 5, N'ԱՐՏԱՇԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (368, 5, N'ՍԱՂՄՈՍԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (369, 9, N'ՍԱՐԱԼԱՆՋ/Կոտայք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (370, 9, N'ԱՐԱԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (371, 9, N'ԱՐԶԱԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (372, 9, N'ԱԼԱՓԱՐՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (373, 9, N'ՔԱՐԱՇԱՄԲ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (374, 9, N'ՉԱՐԵՆՑԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (375, 9, N'ՖԱՆՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (376, 7, N'ՀԱՅՐԱՎԱՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (377, 7, N'ԾԱՓԱԹԱՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (378, 7, N'ՓԱՄԲԱԿ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (379, 3, N'ՔԱՐԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (380, 7, N'ԴԱՐԱՆԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (381, 7, N'ՆՈՐԱՏՈՒՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (382, 7, N'ԳԱՎԱՌ (ԿԱՄՈ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (383, 9, N'ՋՐԱԲԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (384, 9, N'ՆՈՒՌՆՈՒՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (385, 9, N'ԱՐԳԵԼ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (387, 5, N'ՕՀԱՆԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (388, 5, N'ՈՒՇԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (389, 5, N'ՂԱԶԱՐԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (390, 5, N'ԱՆՏԱՌՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (391, 5, N'ՕՐԳՈՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (392, 5, N'ԼԵՌՆԱՐՈՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (393, 5, N'ՕԹԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (394, 5, N'ԴԻԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (395, 5, N'ԿԱՔԱՎԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (396, 5, N'Վ.ԲԱԶՄԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (397, 5, N'ԿԱԹՆԱՂԲՅՈՒՐ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (398, 5, N'ԴԱՎԹԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (399, 5, N'Վ.ՍԱՍՆԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (400, 5, N'ԴԱՇՏԱԴԵՄ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (402, 5, N'ԴԴՄԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (404, 5, N'ԱՐԵՎՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (405, 5, N'ՀԱԿՈ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (406, 5, N'ԳԵՏԱՓ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (407, 5, N'ԹԼԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (408, 5, N'ԱՇՆԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (409, 5, N'Ն.ԲԱԶՄԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (410, 5, N'ԱԳԱՐԱԿԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (411, 5, N'ԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (412, 5, N'ԲՅՈՒՐԱԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (413, 5, N'ԱՂՁՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (414, 5, N'ՓԱՐՊԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (415, 5, N'ԿԱՐԲԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (416, 9, N'ԵՂՎԱՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (417, 9, N'ՆՈՐ ԳԵՂԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (418, 9, N'ԲՅՈՒՐԵՂԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (419, 9, N'ԿԱՊՈՒՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (420, 9, N'ՀԱՏԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (421, 9, N'ԶՈՎԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (422, 7, N'ԳԱՆՁԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (423, 7, N'ԿԱՐՄԻՐԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (424, 7, N'ԱՐԵԳՈՒՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (425, 7, N'ԳԵՂԱՄԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (426, 7, N'ԿՈՒՏԱԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (427, 7, N'ԿԱԽԱԿՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (428, 7, N'ԱՐՓՈՒՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (429, 7, N'ՍԱՐՈՒԽԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (430, 7, N'ԼԱՆՋԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (431, 9, N'ԱԿՈՒՆՔ/Կոտայք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (432, 9, N'ԱԲՈՎՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (433, 9, N'ԱՐԶՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (434, 9, N'ՆՈՐ ՀԱՃՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (435, 9, N'ԳԵՏԱՄԵՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (436, 9, N'ՄՐԳԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (437, 5, N'ԱՇՏԱՐԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (438, 5, N'ՈՍԿԵՎԱԶ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (439, 5, N'ՈՒՋԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (440, 5, N'ԱԳԱՐԱԿ (ԱՇՏԱՐԱԿԻ Տ/Շ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (441, 5, N'ԱՐԱԳԱԾՈՏՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (442, 5, N'ԿՈՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (443, 2, N'ՄՈՒՑՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (444, 5, N'ՇԱՄԻՐԱՄ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (445, 5, N'ԱՐՈՒՃ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (446, 5, N'ԱՐՏԵՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (447, 5, N'ՈՍԿԵՀԱՏ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (448, 5, N'ՕՇԱԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (450, 5, N'ՍԱՍՈՒՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (451, 3, N'ԼԵՌՆԱՄԵՐՁ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (452, 3, N'ԱՄԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (453, 3, N'ԱՅԳԵՇԱՏ (ԷՋՄԻԱԾՆԻ Տ/Շ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (454, 3, N'ԱՂԱՎՆԱՏՈՒՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (455, 3, N'ԴԱՇՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (456, 3, N'ԴՈՂՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (457, 3, N'ՇԱՀՈՒՄՅԱՆ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (458, 9, N'ՊՌՈՇՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (459, 9, N'ՔԱՆԱՔԵՌԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (460, 9, N'ԶՈՎՈՒՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (461, 9, N'ՊՏՂՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (462, 9, N'ԲԱԼԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (464, 9, N'ՄԱՅԱԿՈՎՍԿԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (465, 9, N'ԿՈՏԱՅՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (466, 9, N'ՆՈՐ ԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (467, 9, N'ԱՐԱՄՈՒՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (468, 9, N'ԿԱՄԱՐԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (469, 9, N'ԿԱԹՆԱՂԲՅՈՒՐ/Կոտայք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (470, 9, N'ԶԱՌ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (471, 9, N'ՍԵՎԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (472, 7, N'ԳԵՂԱՐՔՈՒՆԻՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (473, 7, N'ՆՈՐԱԿԵՐՏ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (474, 7, N'ՓՈՔՐ ՄԱՍՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (475, 7, N'ՍՈԹՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (476, 7, N'ԿՈՒԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (477, 7, N'ԱԶԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (478, 4, N'ՈՍՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (479, 7, N'ՇԱՏՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (480, 7, N'ՄԵԾ ՄԱՍՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (481, 7, N'ՎԱՐԴԵՆԻՍ ք.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (482, 7, N'ԳԵՂԱՄԱԲԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (483, 7, N'ՇԱՏՋՐԵՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (484, 7, N'ԽԱՉԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (485, 7, N'ՎԱՆԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (486, 7, N'ԼՈՒՍԱԿՈՒՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (487, 7, N'ԾՈՎԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (488, 7, N'ԵՐԱՆՈՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (489, 7, N'ՎԱՐԴԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (490, 7, N'ՁՈՐԱԳՅՈՒՂ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (491, 7, N'ԾԱԿՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (492, 9, N'ԳԵՂԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (493, 9, N'ԶՈՎՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (494, 9, N'ՁՈՐԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (497, 3, N'ԲԱՂՐԱՄՅԱՆ (ԷՋՄԻԱԾՆԻ ՇՐՋ.)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (498, 3, N'ՄԵՐՁԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (499, 3, N'ԱՅԳԵԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (500, 3, N'ՆՈՐԱԿԵՐՏ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (501, 3, N'ՄՐԳԱՍՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (502, 3, N'ԾԱՂԿՈՒՆՔ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (503, 3, N'ԾԻԱԾԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (504, 3, N'ԾԱՂԿԱԼԱՆՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (505, 3, N'ԱՐՇԱԼՈՒՅՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (506, 3, N'ՀԱՅԹԱՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (507, 3, N'ԼՈՒԿԱՇԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (508, 3, N'ՄՅԱՍՆԻԿՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (509, 3, N'ՆՈՐ ԱՐՏԱԳԵՐՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (510, 3, N'ՏԱՆՁՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (511, 3, N'ԱՐԳԱՎԱՆԴ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (512, 3, N'ԳԵՏԱՇԵՆ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (513, 3, N'ՋԱՆՖԻԴԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (514, 3, N'ՓՇԱՏԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (515, 3, N'ՎԱՐԴԱՆԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (516, 3, N'ԱՐԱԶԱՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (517, 3, N'ՄԱՐԳԱՐԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (518, 3, N'ԵՐԱՍԽԱՀՈՒՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (519, 3, N'ՋՐԱՌԱՏ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (520, 9, N'ՋՐԱՌԱՏ/Կոտայք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (521, 3, N'ՄԵԾԱՄՈՐ ք.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (522, 3, N'ԼՈՒՍԱԳՅՈՒՂ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (523, 3, N'ԳԱՅ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (524, 3, N'ԱՐԱՔՍ (ԷՋՄԻԱԾՆԻ ՇՐՋ.)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (525, 3, N'ՀԱՅԿԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (526, 4, N'ՍԱՅԱԹ-ՆՈՎԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (527, 4, N'ՄԱՐՄԱՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (528, 4, N'ՌԱՆՉՊԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (529, 4, N'ՆՈՐԱՄԱՐԳ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (530, 4, N'ՋՐԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (531, 4, N'ՋՐԱՇԵՆ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (532, 4, N'ԱՐԵՎԱԲՈՒՅՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (533, 4, N'ՀՈՎՏԱՇԵՆ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (534, 4, N'ՄՐԳԱՎԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (535, 4, N'ՆՇԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (536, 4, N'ԱՐԵՎՇԱՏ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (537, 4, N'ԳԵՏԱԶԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (538, 4, N'ՄՐԳԱՆՈՒՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (539, 4, N'ԼԱՆՋԱԶԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (541, 4, N'ԱԲՈՎՅԱՆ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (543, 4, N'ՎԵՐԻՆ ԴՎԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (544, 7, N'ՄԱԴԻՆԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (545, 7, N'Վ.ՇՈՐԺԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (546, 4, N'ՆՈՐԱՇԵՆ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (547, 4, N'ԴՎԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (548, 4, N'ԱՅԳԵՍՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (549, 4, N'ԴԵՂՁՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (551, 4, N'ԲՅՈՒՐԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (552, 4, N'ՄԽՉՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (553, 4, N'ԴԻՄԻՏՐՈՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (554, 4, N'ԿԱՆԱՉՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (555, 4, N'ԲՈՒՐԱՍՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (556, 4, N'ԲԱՂՐԱՄՅԱՆ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (557, 4, N'ԲԵՐՔԱՆՈՒՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (558, 4, N'ՄՐԳԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (559, 4, N'ԱՐՏԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (560, 4, N'ԱՅԳԵՊԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (561, 4, N'ԱՅԳԵԶԱՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (562, 4, N'ՔԱՂՑՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (563, 4, N'ՇԱՀՈՒՄՅԱՆ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (565, 4, N'ՆՈՐ ՈՒՂԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (566, 4, N'ԱՐԱԼԵԶ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (567, 4, N'ՍԻՍԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (568, 4, N'ՎԵԴԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (569, 4, N'ԳՈՌԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (570, 4, N'ԴԱՇՏԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (571, 4, N'ՈՒՐՑԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (572, 3, N'ՆՈՐԱՎԱՆ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (573, 1, N'ՎԱՐԴԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (574, 1, N'ՋԵՐՄՈՒԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (575, 1, N'ԳՈՂԹԱՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (576, 1, N'ՀԵՐՄՈՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (577, 1, N'ԵՂԵԳԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (578, 1, N'ՀՈՐԲԱՏԵՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (579, 1, N'ԱՐՏԱԲՈՒՅՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (580, 1, N'ՔԱՐԱԳԼՈՒԽ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (581, 1, N'ԹԱՌԱԹՈՒՄԲ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (582, 1, N'ՀՈՐՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (583, 1, N'ՍԱԼԼԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (584, 4, N'ԼԱՆՋԱՆԻՍՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (585, 4, N'ՇԱՂԱՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (586, 4, N'ՎԱՆԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (587, 4, N'ՈՍԿԵՏԱՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (588, 4, N'ԱՅԳԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (589, 4, N'ԱՎՇԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (590, 7, N'ԲԵՐԴԿՈՒՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (591, 4, N'ՆՈՐ ԿՅԱՆՔ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (592, 4, N'ԳԻՆԵՎԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (593, 4, N'ԼՈՒՍԱՌԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (594, 4, N'ԱՐԱՐԱՏ ք.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (596, 4, N'ԵՂԵԳՆԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (597, 4, N'ՆՈՅԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (598, 4, N'ԼԱՆՋԱՌ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (599, 4, N'ՈՒՐՑԱԼԱՆՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (600, 4, N'ԼՈՒՍԱՇՈՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (601, 4, N'ՎԱՐԴԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (602, 4, N'ԶԱՆԳԱԿԱՏՈՒՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (603, 1, N'ԵԼՓԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (604, 1, N'ՇԱՏԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (605, 1, N'ԿԱՐՄՐԱՇԵՆ/Վայոց Ձոր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (607, 1, N'ՀԵՐՀԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (608, 1, N'ՎԵՐՆԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (609, 1, N'ԳԼԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (610, 1, N'ԱՂԱՎՆԱՁՈՐ/Վայոց Ձոր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (611, 4, N'ՊԱՐՈՒՅՐ ՍԵՎԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (612, 4, N'ՍՈՒՐԵՆԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (613, 4, N'ԱՐՄԱՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (614, 1, N'ՉԻՎԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (615, 1, N'ՌԻՆԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (616, 1, N'ԱՐԵՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (617, 1, N'ԱՐՓԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (618, 1, N'ԳԵՏԱՓ/Վայոց Ձոր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (619, 1, N'ԵՂԵԳՆԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (620, 1, N'ԱԳԱՐԱԿԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (621, 1, N'ԳՆԴԵՎԱԶ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (622, 1, N'ՍԱՐԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (623, 1, N'ԱՐԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (624, 1, N'ՎԱՅՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (625, 1, N'ԱԶԱՏԵԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (626, 1, N'ՓՈՌ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (627, 1, N'ԶԱՌԻԹԱՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (628, 1, N'ԳՈՄՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (629, 1, N'ԱՐՏԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (630, 2, N'ԳՈՐԱՅՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (631, 2, N'ԾՂՈՒԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (632, 2, N'ՍԱՌՆԱԿՈՒՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (633, 1, N'ԳՆԻՇԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (634, 1, N'ԽԱՉԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (635, 1, N'ՄԱՐՏԻՐՈՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (636, 2, N'ՍՊԱՆԴԱՐՅԱՆ/Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (637, 2, N'ԽՈԶՆԱՎԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (638, 2, N'ՎԱՂԱՏՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (639, 2, N'ԽՆԱԾԱԽ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (640, 1, N'ԽՆՁՈՐՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (641, 1, N'ՆՈՐ ԱԶՆԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (642, 1, N'ՍԵՐՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (644, 2, N'ԱՆԳԵՂԱԿՈԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (645, 2, N'ՇԱՂԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (646, 2, N'ԲԱԼԱՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (647, 2, N'ԲԱՐՁՐԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (648, 2, N'ՍԻՍԻԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (649, 2, N'ՆՈՐԱՎԱՆ/Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (650, 2, N'ՔԱՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (651, 2, N'ՏԵՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (652, 2, N'ԿՈՌՆԻՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (653, 2, N'ԱՐԱՎՈՒՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (654, 2, N'ԽՆՁՈՐԵՍԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (655, 2, N'ԳՈՐԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (656, 2, N'ՎԵՐԻՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (657, 2, N'ՎԱՂԱՏԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (658, 2, N'ՈՒՅԾ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (659, 2, N'ԲՌՆԱԿՈԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (660, 2, N'ԱՇՈՏԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (661, 2, N'ՏՈԼՈՐՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (662, 2, N'ՈՐՈՏԱՆ (ՍԻՍԻԱՆԻ Տ/Շ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (663, 2, N'ՔԱՐԱՀՈՒՆՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (664, 2, N'ՀԱՐԹԱՇԵՆ/Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (665, 2, N'ԽՈՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (666, 2, N'ՇԻՆՈՒՀԱՅՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (667, 2, N'ՀԱՐԺԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (668, 2, N'ԴԱՐԲԱՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (669, 2, N'ԼԾԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (670, 2, N'ԳԵՏԱԹԱՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (671, 2, N'ԱԽԼԱԹՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (672, 2, N'ԲՆՈՒՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (673, 2, N'ԹԱՍԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (674, 2, N'ՍԱԼՎԱՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (675, 2, N'ՀԱՑԱՎԱՆ/Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (676, 2, N'ԹԱՆԱՀԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (677, 2, N'ՏՈՐՈՒՆԻՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (678, 2, N'ԼՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (679, 2, N'ԻՇԽԱՆԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (680, 2, N'ԴԱՍՏԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (682, 2, N'ՀԱԼԻՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (683, 2, N'ՏԱԹԵՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (684, 2, N'ՏԱՆՁԱՏԱՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (685, 2, N'ՍՎԱՐԱՆՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (686, 2, N'ՔԱՇՈՒՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (687, 2, N'ԱՂՎԱՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (688, 2, N'ՏԱՆՁԱՎԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (689, 2, N'ՇՈՒՌՆՈՒԽ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (690, 2, N'ԱՆՏԱՌԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (691, 2, N'ԵՂԵԳ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (692, 2, N'ԴԱՎԻԹ ԲԵԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (693, 2, N'ԿԱՂՆՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (695, 2, N'ՆՈՐ ԱՍՏՂԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (696, 2, N'ԳԵՂԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (697, 2, N'ՎԱՆԵՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (698, 2, N'ՍԵՎԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (699, 2, N'ՉԱՓՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (700, 2, N'ԱՐԾՎԱՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (701, 2, N'ԱՃԱՆԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (702, 2, N'ՎԱՐԴԱՎԱՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (703, 2, N'ՈՒԺԱՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (704, 2, N'ԽԴՐԱՆՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (705, 2, N'ԵՂՎԱՐԴ/Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (706, 2, N'ԱԳԱՐԱԿ ք./Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (707, 2, N'ՍՅՈՒՆԻՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (708, 2, N'ԳԵՂԱՆՈՒՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (709, 2, N'ՔԱՋԱՐԱՆ գ.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (710, 2, N'ՔԱՋԱՐԱՆ ք.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (711, 2, N'ՃԱԿԱՏԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (712, 2, N'ՇԻԿԱՀՈՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (713, 2, N'ԼԵՌՆԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (714, 2, N'ՏԱՇՏՈՒՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (715, 2, N'ԼԻՃՔ/Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (716, 2, N'ԾԱՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (717, 2, N'ՍՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (718, 2, N'Ն.ՀԱՆԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (719, 2, N'ՎԱՀՐԱՎԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (721, 2, N'ՎԱՐԴԱՆԻՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (722, 2, N'ԳՈՒԴԵՄՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (723, 2, N'ԼԵՀՎԱԶ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (725, 2, N'ՄԵՂՐԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (726, 2, N'ԿՈՒՐԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (727, 2, N'ԿԱՐՃԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (728, 2, N'ԱԳԱՐԱԿ գ./Սյունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (729, 2, N'ԿԱՊԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (730, 6, N'ԱՉԱՋՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (731, 6, N'ՎԱՐԱԳԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (732, 6, N'ԴԻՏԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (734, 6, N'ԽԱՇԹԱՌԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (735, 6, N'ԼՈՒՍԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (736, 6, N'ԱԿՆԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (737, 6, N'Ն.ԿԱՐՄԻՐ ԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (738, 6, N'ԵՆՈՔԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (739, 6, N'ԳԵՏԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (740, 6, N'ԼՈՒՍԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (741, 6, N'ՉԻՆՉԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (743, 6, N'ԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (744, 6, N'ՄՈՍԵՍԳԵՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (746, 6, N'Վ.ԿԱՐՄԻՐ ԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (747, 6, N'ՉՈՐԱԹԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (748, 6, N'ԱՐԾՎԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (749, 6, N'ԻԾԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (750, 6, N'ՆԱՎՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (751, 6, N'ԻՋԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (752, 6, N'ԳԱՆՁԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (753, 6, N'ՀՈՎՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (754, 6, N'ՉԻՆԱՐԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (755, 11, N'ԽՆԿՈՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (757, 8, N'ԿԱՄՈ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (758, 8, N'ԿԱՐՄՐԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (759, 8, N'ՇԻՐԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (760, 8, N'ԿՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (761, 8, N'ՀՈՎՈՒՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (762, 8, N'ՎԱՀՐԱՄԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (763, 8, N'ՄԱՐՄԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (764, 8, N'ԿԱՊՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (765, 8, N'ԲՅՈՒՐԱԿՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (766, 6, N'ԱՅԳԵՁՈՐ ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (768, 6, N'ՀԱՂԱՐԾԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (769, 6, N'ԴԻԼԻՋԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (770, 5, N'ԾԻԼՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (771, 5, N'ԳԵՂԱՐՈՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (772, 6, N'ԽԱՉԱՐՁԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (773, 7, N'ԱՆՏԱՌԱՄԵՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (775, 6, N'ԱՂԱՎՆԱՎԱՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (776, 7, N'ԱՅԳՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (777, 7, N'ԴՊՐԱԲԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (778, 7, N'ՁՈՐԱՎԱՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (779, 8, N'ԳԵՂԱՆԻՍՏ/ՇԻՐԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (780, 5, N'ԱՐԱՅԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (781, 8, N'ԱՆՈՒՇԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (782, 5, N'ՍԱԴՈՒՆՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (783, 7, N'ՍԵՄՅՈՆՈՎԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (784, 8, N'ՀԱՅԿԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (785, 8, N'ՏՈՒՖԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (786, 8, N'ՍԱՐԱԿԱՊ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (787, 8, N'ՔԱՐԱԲԵՐԴ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (789, 9, N'ՍՈԼԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (790, 3, N'ՇԵՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (791, 3, N'ԴԱԼԱՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (792, 3, N'ԲԱՂՐԱՄՅԱՆ (ԲԱՂՐԱՄՅԱՆԻ ՇՐՋ.)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (793, 9, N'ՔԱՍԱԽ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (794, 9, N'ԱՌԻՆՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (795, 11, N'ՄԵՂՎԱՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (796, 11, N'ԲԼԱԳՈԴԱՐՆՈՅԵ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (797, 11, N'ՍԱՐԱՏՈՎԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (798, 11, N'ՆՈՎՈՍԵԼՑՈՎՈ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (799, 6, N'ԶՈՐԱԿԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (800, 6, N'ԲԵՐԴԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (801, 11, N'ԿԱՃԱՃԿՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (802, 11, N'ՆԵՂՈՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (803, 11, N'ԱԽԹԱԼԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (804, 11, N'ՊԵՏՐՈՎԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (805, 6, N'ՆՈՅԵՄԲԵՐՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (806, 11, N'ՀՈՎՆԱՆԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (807, 11, N'ՅԱՂԴԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (808, 11, N'ԱԳԱՐԱԿ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (809, 11, N'ԼԵՋԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (810, 11, N'ԿՈՂԵՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (811, 11, N'ԱՄՐԱԿԻՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (812, 11, N'ԼՈՌԻ ԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (813, 11, N'ԿԱԹՆԱՌԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (814, 11, N'ԿԱԹՆԱՂԲՅՈՒՐ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (815, 8, N'ՎԱՐԴԱՂԲՅՈՒՐ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (817, 8, N'ԲԱՇԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (818, 8, N'ՍԱԼՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (819, 8, N'ՍԱՐԱՊԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (820, 8, N'ՁՈՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (821, 8, N'ԿԱՔԱՎԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (822, 6, N'ԳՈՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (823, 5, N'ՋԱՄՇԼՈՒ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (824, 8, N'ՀՈՌՈՄ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (825, 5, N'ԳԵՂԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (826, 5, N'Ն.ՍԱՍՆԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (827, 7, N'ԾԱՂԿԱՇԵՆ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (828, 9, N'ՆՈՐ ԵՐԶՆԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (829, 3, N'ԼԵՌՆԱԳՈԳ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (830, 7, N'ՏՐԵՏՈՒՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (831, 5, N'ՆՈՐ ԵԴԵՍԻԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (832, 5, N'ՆՈՐ ԱՄԱՆՈՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (834, 3, N'ԽԱՆՋՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (835, 8, N'ՋԱՋՈՒՌԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (836, 7, N'ԱԿՈՒՆՔ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (837, 7, N'ՆՈՐԱԲԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (838, 7, N'ՋԱՂԱՑԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (839, 1, N'ԶԵԴԵԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (840, 1, N'ԲԱՐՁՐՈՒՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (841, 2, N'ՇԱՔԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (843, 2, N'Վ. ԽՈՏԱՆԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (844, 8, N'ԱՅԳԱԲԱՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (845, 8, N'ԵՐԱԶԳԱՎՈՐՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (846, 8, N'ԲԱՅԱՆԴՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (847, 8, N'ԲԵՆԻԱՄԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (848, 8, N'ԼՈՒՍԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (849, 8, N'ՍԱՐԱՏԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (850, 8, N'ՀՈՎՏԱՇԵՆ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (851, 8, N'ՎԱՐԴԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (852, 8, N'ՄԵՂՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (853, 8, N'ՓԱՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (854, 8, N'ՍՊԱՆԴԱՐՅԱՆ/Շիրակ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (855, 5, N'ՆՈՐԱՇԵՆ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (856, 2, N'ՏԱՎՐՈՒՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (857, 2, N'Ն.ԽՈՏԱՆԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (858, 2, N'ՇՐՎԵՆԱՆՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (859, 2, N'ՁՈՐԱՍՏԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (860, 2, N'ՆՈՐԱՇԵՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (861, 2, N'ԱՌԱՋԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (862, 6, N'ԲԱՐԵԿԱՄԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (863, 6, N'ԲԱՂԱՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (864, 6, N'ՈՍԿԵՊԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (865, 5, N'ՏԵՂԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (867, 5, N'ԲԱԶՄԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (868, 5, N'ԴՊՐԵՎԱՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (869, 5, N'ԼՈՒՍԱԿՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (870, 5, N'ՄԵԼԻՔԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (871, 5, N'ՊԱՐՏԻԶԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (872, 5, N'ՋՐԱՄԲԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (873, 5, N'ՌՅԱ ԹԱԶԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (874, 5, N'ՍԱՐԱԼԱՆՋ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (875, 5, N'Վ.ՍԱՍՈՒՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (877, 4, N'ԱԶԱՏԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (878, 4, N'ԱԶԱՏԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (880, 4, N'ԱՐԱՔՍԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (881, 4, N'ԲԵՐԴԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (882, 4, N'ԳԵՏԱՓՆՅԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (883, 4, N'ԴԱԼԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (884, 4, N'ԴԱՐԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (885, 4, N'ԴԻՏԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (886, 4, N'ՀՆԱԲԵՐԴ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (887, 4, N'ՄԱՍԻՍ գ.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (888, 4, N'ՆԱՐԵԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (889, 4, N'ՆՈՐ ԿՅՈՒՐԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (890, 4, N'ՍԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (891, 4, N'ՍԻՓԱՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (892, 4, N'ՎԵՐԻՆ ԱՐՏԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (893, 3, N'ԱՅԳԵՇԱՏ (ԱՐՄԱՎԻՐԻ ՇՐՋ.)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (894, 3, N'ԱՌԱՏԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (895, 3, N'ԱՐԱԳԱԾ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (897, 3, N'ԱՐԳԻՆԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (898, 3, N'ԲԵՐՔԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (899, 3, N'ՀՈՎՏԱՄԵՋ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (900, 3, N'ՇԱՀՈՒՄՅԱՆԻ ԹՌՉՆԱՖԱԲՐԻԿԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (901, 3, N'ՋՐԱՇԵՆ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (902, 3, N'ԿՈՂԲԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (903, 3, N'ՎԱՆԱՆԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (904, 3, N'ՏԱԼՎՈՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (905, 3, N'ԱՐՏԱՄԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (906, 3, N'ԱՐԵՎԱԴԱՇՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (907, 2, N'Ն. ԽՆՁՈՐԵՍԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (908, 2, N'ՇՎԱՆԻՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (909, 2, N'ՈՐՈՏԱՆ (ԳՈՐԻՍԻ Տ/Շ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (910, 6, N'ԱԶԱՏԱՄՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (911, 6, N'ԱՃԱՐԿՈՒՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (912, 6, N'ԱՅԳԵՊԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (913, 6, N'ԲԵՐՔԱԲԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (914, 6, N'ՍԱՐԻԳՅՈՒՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (916, 6, N'ԴԵՂՁԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (917, 6, N'ԴՈՎԵՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (918, 6, N'ԿԻՐԱՆՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (919, 6, N'ԿՈԹԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (920, 6, N'ՈՍԿԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (921, 6, N'ՋՈՒՋԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (922, 9, N'ԶՈՐԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (923, 9, N'ԹԵՂԵՆԻՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (924, 9, N'ԿԱՐԵՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (925, 9, N'ՆՈՐ ԱՐՏԱՄԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (926, 9, N'ՈՂՋԱԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (927, 9, N'ՋՐՎԵԺ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (928, 9, N'Վ.ՊՏՂՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (929, 8, N'ԱՆԻԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (930, 8, N'ՀՈՎԻՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (931, 8, N'ՄԵՂՐԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (932, 8, N'ՇԻՐԱԿԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (933, 11, N'ԱՊԱՎԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (934, 11, N'ԱՆՏԱՌԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (936, 6, N'ԹԵՂՈՒՏ/Տավուշ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (937, 11, N'ԹԵՂՈՒՏ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (938, 11, N'ԼՈՒՍԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (939, 11, N'ԾԱՂԿԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (940, 11, N'ՋԻԼԻԶԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (941, 11, N'ՔԱՐԿՈՓ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (942, 8, N'ԱՂԻՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (943, 7, N'ՏՈՐՖԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (944, 7, N'ԳԵՏԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (945, 3, N'ՖԵՐԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (946, 4, N'ՎԱՐԴԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (947, 4, N'ՓՈՔՐ ՎԵԴԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (948, 6, N'ԴԵԲԵԴԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (949, 3, N'ՆՈՐԱՊԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (951, 3, N'ԱՐՄԱՎԻՐ գ.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (952, 3, N'ԲԱԳԱՐԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (953, 3, N'ԵՐՎԱՆԴԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (954, 3, N'ԽՈՐՈՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (955, 3, N'ՄՐԳԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (956, 3, N'ԲԱՄԲԱԿԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (957, 3, N'ՄԵԾԱՄՈՐ գ.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (958, 3, N'ԱԿՆԱԼԻՃ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (959, 3, N'ՏԱՐՈՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (960, 3, N'ԱՐՏԻՄԵՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (961, 3, N'ԼԵՆՈՒՂԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (962, 3, N'ՓԱՐԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (963, 3, N'ՊՏՂՈՒՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (964, 3, N'ՄՈՒՍԱԼԵՌ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (965, 3, N'ՈՍԿԵՀԱՏ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (966, 3, N'ԱՐԵՎԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (967, 4, N'ԱՐԲԱԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (968, 4, N'ՀԱՅԱՆԻՍՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (969, 4, N'ԴԱՐԲՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (970, 4, N'ԳԵՂԱՆԻՍՏ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (971, 4, N'ԱՐԳԱՎԱՆԴ/Արարատ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (972, 4, N'ՂՈՒԿԱՍԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (973, 4, N'ԽԱՉՓԱՌ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (974, 9, N'ԳԵՂԱԴԻՐ/Կոտայք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (975, 5, N'ԳԵՂԱԴԻՐ/Արագածոտն')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (976, 9, N'ԳԵՂԱՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (977, 7, N'ԼԻՃՔ/Գեղարքունիք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (978, 7, N'ԾՈՎԱՍԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (979, 7, N'Ն.ԳԵՏԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (980, 7, N'Վ.ԳԵՏԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (981, 7, N'ՄԱՐՏՈՒՆԻ ք.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (982, 3, N'ՆՈՐ ԱՐՄԱՎԻՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (983, 3, N'ՀՈՒՇԱԿԵՐՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (984, 3, N'ԱՄԱՍԻԱ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (985, 3, N'ԱՐԱՔՍ (ԱՐՄԱՎԻՐԻ ՇՐՋ.)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (986, 3, N'ԱՐՄԱՎԻՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (987, 3, N'ՀԱՅԿԱՎԱՆ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (988, 3, N'ԶԱՐԹՈՆՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (989, 3, N'ԱՐՏԱՇԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (990, 3, N'ԳՐԻԲՈՅԵԴՈՎ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (991, 3, N'ԱՊԱԳԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (992, 3, N'ԱԿՆԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (993, 4, N'ՀՈՎՏԱՇԱՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (994, 4, N'ԴԱՇՏԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (995, 4, N'ՆԻԶԱՄԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (996, 4, N'ՆՈՐԱԲԱՑ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (997, 4, N'ԱՅՆԹԱՊ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (998, 4, N'ՆՈՐ ԽԱՐԲԵՐԴ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (999, 4, N'ԲԱՐՁՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1000, 9, N'ՀԱՑԱՎԱՆ/Կոտայք')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1001, 9, N'ԳԱՌՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1002, 9, N'ԳՈՂԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1003, 7, N'ՎԱՂԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1004, 7, N'ԱՍՏՂԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1005, 7, N'ԶՈԼԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1006, 7, N'ՎԱՐԴԵՆԻԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1007, 7, N'ԾՈՎԻՆԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1008, 7, N'ԱՐԾՎԱՆԻՍՏ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1009, 7, N'ԿԱՐՃԱՂԲՅՈՒՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1010, 7, N'Ն.ՇՈՐԺԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1011, 7, N'ԱՅՐՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1012, 7, N'ԳԵՂԱՔԱՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1013, 7, N'ԼՃԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1014, 7, N'ՄԱՔԵՆԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1015, 7, N'ԱԽՊՐԱՁՈՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1016, 3, N'ՆՈՐ ԿԵՍԱՐԻԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1017, 3, N'ՇԵՆԱՎԱՆ/Արմավիր')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1018, 3, N'ՆԱԼԲԱՆԴՅԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1020, 8, N'ՑՈՂԱՄԱՐԳ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1023, 11, N'ԴԱՇՏԱԴԵՄ/Լոռի')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1027, 5, N'ԱՐԱԳԱԾ (ԱՊԱՐԱՆԻ Տ/Շ)')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1029, 5, N'ԱՐԱԳԱԾԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1034, 2, N'ԱԿՆԵՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1035, 2, N'ԱՐԵՎԻՍ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1044, 7, N'ՄԱՐՏՈՒՆԻ գ.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1065, 10, N'Ք. ԵՐԵՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1066, 2, N'ՇԵՆԱԹԱՂ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1068, 7, N'ԱՐԾՎԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1069, 2, N'ՆԺԴԵՀ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1075, 4, N'ԱՐԱՐԱՏ գ.')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1076, 6, N'ՆՈՐԱՇԵՆ/ՏԱՎՈՒՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1077, 6, N'ՏԱՎՈՒՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1078, 10, N'հ.ԱՎԱՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1079, 10, N'հ.ԱՋԱՓՆՅԱԿ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1080, 10, N'հ.ԷՐԵԲՈՒՆԻ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1081, 10, N'հ.ՆՈՐՔ-ՄԱՐԱՇ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1082, 10, N'հ.ՇԵՆԳԱՎԻԹ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1083, 10, N'հ.ԿԵՆՏՐՈՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1085, 10, N'հ.ԱՐԱԲԿԻՐ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1086, 10, N'հ.ԴԱՎԹԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1087, 10, N'հ.ՄԱԼԱԹԻԱ-ՍԵԲԱՍՏԻԱ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1088, 10, N'հ.ՆՈՐ ՆՈՐՔ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1089, 10, N'հ.ՆՈՒԲԱՐԱՇԵՆ')
INSERT [dbo].[Community] ([CommunityID], [RegionID], [CommunityName]) VALUES (1090, 10, N'հ.ՔԱՆԱՔԵՌ-ԶԵՅԹՈՒՆ')
SET IDENTITY_INSERT [dbo].[Community] OFF
GO

--1.0.0.1
UPDATE dbo.Setting SET SettingValue = '1.0.0.1' WHERE SettingItem = 'version' 
GO

--1.0.0.2
UPDATE dbo.Setting SET SettingValue = '1.0.0.2' WHERE SettingItem = 'version' 
GO

--1.0.0.3
UPDATE dbo.Setting SET SettingValue = '1.0.0.3' WHERE SettingItem = 'version' 
GO

--1.0.1.0
if EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_TypeConsultationDeclarationType_ResponseContent')
	ALTER TABLE [dbo].[TypeConsultationDeclarationType] DROP CONSTRAINT [FK_TypeConsultationDeclarationType_ResponseContent]

IF EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ResponseContentID' AND Object_ID = Object_ID(N'dbo.TypeConsultationDeclarationType'))
	ALTER TABLE [dbo].[TypeConsultationDeclarationType] DROP COLUMN [ResponseContentID]

IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ResponseContent' AND Object_ID = Object_ID(N'dbo.TypeConsultationDeclarationType'))
	ALTER TABLE [dbo].[TypeConsultationDeclarationType] ADD [ResponseContent] NVARCHAR(100)

if EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_TmpTypeConsultationDeclarationType_ResponseContent')
	ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] DROP CONSTRAINT [FK_TmpTypeConsultationDeclarationType_ResponseContent]

IF EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ResponseContentID' AND Object_ID = Object_ID(N'dbo.TmpTypeConsultationDeclarationType'))
ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] DROP COLUMN [ResponseContentID]

IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ResponseContent' AND Object_ID = Object_ID(N'dbo.TmpTypeConsultationDeclarationType'))
ALTER TABLE [dbo].[TmpTypeConsultationDeclarationType] ADD [ResponseContent] NVARCHAR(100)

UPDATE dbo.Setting SET SettingValue = '1.0.1.0' WHERE SettingItem = 'version' 
GO
--1.0.1.0

--1.0.2.0
IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'BirthYear' AND Object_ID = Object_ID(N'dbo.Resident'))
	ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD BirthYear SMALLINT

IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'Phone' AND Object_ID = Object_ID(N'dbo.Resident'))
	ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD Phone nvarchar(20)

IF NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'Email' AND Object_ID = Object_ID(N'dbo.Resident'))
	ALTER TABLE [eConsultationDB].[dbo].[Resident] ADD Email nvarchar(50)

IF EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'ResidentID' AND Object_ID = Object_ID(N'dbo.TypeConsultation'))
	BEGIN
	ALTER TABLE [eConsultationDB].[dbo].[TypeConsultation] DROP CONSTRAINT [FK_TypeConsultation_Resident]
	ALTER TABLE [eConsultationDB].[dbo].[TypeConsultation] DROP COLUMN [ResidentID]
	END
--1.0.2.0