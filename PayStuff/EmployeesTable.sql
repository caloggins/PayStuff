CREATE TABLE [dbo].[Employees]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [EmployeeName] VARCHAR(MAX) NOT NULL, 
    [NumberOfDependents] INT NOT NULL, 
    [Version] ROWVERSION NOT NULL
)
