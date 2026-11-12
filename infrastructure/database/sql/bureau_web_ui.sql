-- Generated from EF Core models. Run infrastructure/database/Generate-Schema.ps1 to refresh.
CREATE TABLE [te_requestsOfUploadPostgresNew] (
    [keyId] bigint NOT NULL IDENTITY,
    [id] nvarchar(max) NOT NULL,
    [created] datetime2 NOT NULL,
    [naturalPersonId] bigint NULL,
    [legalPersonId] bigint NULL,
    [uploadingXML] nvarchar(max) NOT NULL,
    [lastUpdated] datetime2 NULL,
    [statusId] int NULL,
    [inProcess] bit NULL,
    [regResultXML] nvarchar(max) NULL,
    [uploadResultXML] nvarchar(max) NULL,
    [priorityLoad] smallint NULL,
    CONSTRAINT [PK_te_requestsOfUploadPostgresNew] PRIMARY KEY ([keyId])
);

CREATE TABLE [te_requestsOfCertificates] (
    [KeyId] bigint NOT NULL IDENTITY,
    [Inserted] datetime2 NULL,
    [NaturalPersonId] bigint NOT NULL,
    [Data] nvarchar(max) NOT NULL,
    [Status] int NULL,
    [Certificate] nvarchar(max) NULL,
    [Issued] datetime2 NULL,
    [Expire] datetime2 NULL,
    CONSTRAINT [PK_te_requestsOfCertificates] PRIMARY KEY ([KeyId])
);
