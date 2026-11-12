USE bureau_users;
IF (SELECT COUNT(*) FROM sys.tables WHERE name <> '__local_bootstrap') <> 3
    THROW 51000, 'Expected 3 BureauUsers tables', 1;
SET XACT_ABORT ON;
BEGIN TRANSACTION;
INSERT INTO dbo.td_legalPersons (ITN, Caption, Active) VALUES (N'test', N'test', 1);
IF SCOPE_IDENTITY() IS NULL THROW 51000, 'Identity generation failed', 1;
ROLLBACK TRANSACTION;
GO
USE bureau_web_ui;
IF (SELECT COUNT(*) FROM sys.tables WHERE name <> '__local_bootstrap') <> 2
    THROW 51000, 'Expected 2 BureauWebUI tables', 1;
IF OBJECT_ID(N'dbo.UploadResults', N'U') IS NOT NULL
    THROW 51000, 'Function result projection must not be a table', 1;
SET XACT_ABORT ON;
BEGIN TRANSACTION;
INSERT INTO dbo.te_requestsOfCertificates (NaturalPersonId, Data) VALUES (1, N'<request/>');
INSERT INTO dbo.te_requestsOfUploadPostgresNew (id, created, uploadingXML) VALUES (N'test', SYSDATETIME(), N'<upload/>');
ROLLBACK TRANSACTION;
GO
