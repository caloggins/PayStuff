CREATE TABLE [dbo].[BenefitsCosts]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL, 
    [EmployeeName] VARCHAR(MAX) NOT NULL, 
    [NumberOfDependents] INT NOT NULL, 
    [Cost] MONEY NOT NULL, 
    [Version] ROWVERSION NOT NULL
)