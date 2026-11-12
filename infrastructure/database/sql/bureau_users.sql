-- Generated from EF Core models. Run infrastructure/database/Generate-Schema.ps1 to refresh.
CREATE TABLE [td_certificates] (
    [KeyId] bigint NOT NULL IDENTITY,
    [RequestId] bigint NULL,
    [LegalPersonId] bigint NULL,
    [NaturalPersonId] bigint NULL,
    [SerialNumber] nvarchar(max) NOT NULL,
    [DateFrom] datetime2 NOT NULL,
    [DateTo] datetime2 NOT NULL,
    [Data] nvarchar(max) NULL,
    [IpMasks] nvarchar(max) NULL,
    [Active] bit NOT NULL,
    [TestOnly] bit NULL,
    CONSTRAINT [PK_td_certificates] PRIMARY KEY ([KeyId])
);

CREATE TABLE [td_legalPersons] (
    [KeyId] bigint NOT NULL IDENTITY,
    [Created] datetime2 NULL,
    [ITN] nvarchar(max) NULL,
    [Caption] nvarchar(max) NULL,
    [TaxServiceData] nvarchar(max) NULL,
    [Settings] nvarchar(max) NULL,
    [Active] bit NOT NULL,
    CONSTRAINT [PK_td_legalPersons] PRIMARY KEY ([KeyId])
);

CREATE TABLE [td_naturalPersons] (
    [KeyId] bigint NOT NULL IDENTITY,
    [Created] datetime2 NULL,
    [Login] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [LegalPersonId] bigint NULL,
    [Surname] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Patronymic] nvarchar(max) NULL,
    [Caption] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    [MobilePhoneNumber] nvarchar(max) NULL,
    [Settings] nvarchar(max) NULL,
    [IpMasks] nvarchar(max) NULL,
    [AccessLevel] int NOT NULL,
    CONSTRAINT [PK_td_naturalPersons] PRIMARY KEY ([KeyId])
);
