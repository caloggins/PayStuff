create table [dbo].[People]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [ParentId] uniqueidentifier not null,
    [Name] VARCHAR(MAX) NOT NULL, 
    [Version] ROWVERSION NOT NULL
)