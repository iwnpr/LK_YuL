-- Local development fixture only. Run against bureau_users after bootstrap.
SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF OBJECT_ID(N'dbo.__local_bootstrap', N'U') IS NULL
    THROW 51000, 'Seed requires a database created by the local bootstrap', 1;
-- Reserved negative keys do not consume normal positive identity values.
IF EXISTS (SELECT 1 FROM dbo.td_legalPersons WHERE KeyId = -900001 AND ISNULL(ITN, '') <> '0000000000')
    THROW 51000, 'Local seed organization key is occupied', 1;
IF EXISTS (SELECT 1 FROM dbo.td_naturalPersons WHERE (KeyId = -900001 AND Login <> 'localadmin') OR (LOWER(Login) = 'localadmin' AND KeyId <> -900001))
    THROW 51000, 'Local seed user key or login is occupied', 1;

IF NOT EXISTS (SELECT 1 FROM dbo.td_legalPersons WHERE KeyId = -900001)
BEGIN
    SET IDENTITY_INSERT dbo.td_legalPersons ON;
    INSERT INTO dbo.td_legalPersons (KeyId, Created, ITN, Caption, Settings, Active)
    VALUES (-900001, SYSDATETIME(), '0000000000', N'Локальная тестовая организация',
        N'<settings><service-access><service name="organizations" access-type="execute"/><service name="users" access-type="execute"/><service name="certificates" access-type="execute"/><service name="abonents" access-type="execute"/><service name="documentation" access-type="execute"/></service-access></settings>', 1);
    SET IDENTITY_INSERT dbo.td_legalPersons OFF;
END;
IF NOT EXISTS (SELECT 1 FROM dbo.td_naturalPersons WHERE KeyId = -900001)
BEGIN
    SET IDENTITY_INSERT dbo.td_naturalPersons ON;
    INSERT INTO dbo.td_naturalPersons
        (KeyId, Created, Login, Password, LegalPersonId, Surname, Name, Caption, EmailAddress, Settings, AccessLevel)
    VALUES (-900001, SYSDATETIME(), 'localadmin', 'LocalAdmin_2026!', -900001,
        N'Тестовый', N'Администратор', N'Тестовый Администратор', 'localadmin@example.invalid',
        N'<settings><service-access><service name="organizations" access-type="execute"/><service name="users" access-type="execute"/><service name="certificates" access-type="execute"/><service name="abonents" access-type="execute"/><service name="documentation" access-type="execute"/></service-access></settings>', 1);
    SET IDENTITY_INSERT dbo.td_naturalPersons OFF;
END;
IF (SELECT COUNT(*) FROM dbo.td_naturalPersons WHERE LOWER(Login) = 'localadmin') <> 1
    THROW 51000, 'Seed verification failed: duplicate login', 1;
IF NOT EXISTS (SELECT 1 FROM dbo.td_naturalPersons WHERE KeyId = -900001 AND LegalPersonId = -900001)
    THROW 51000, 'Seed verification failed: organization link', 1;
COMMIT TRANSACTION;
