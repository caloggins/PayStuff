delete from dbo.BenefitsCosts
delete from dbo.Employees

insert into dbo.BenefitsCosts (Id, EmployeeId, EmployeeName, NumberOfDependents, Cost)
    values(NEWID(), '724775ba-e208-4fd5-85d9-81c09cc4690b', 'John', 0, 1000)
insert into dbo.BenefitsCosts (Id, EmployeeId, EmployeeName, NumberOfDependents, Cost)
    values(NEWID(), 'b5bb41eb-478a-400c-afdb-373304c35ba6', 'Alice', 0, 900)
insert into dbo.BenefitsCosts (Id, EmployeeId, EmployeeName, NumberOfDependents, Cost)
    values(NEWID(), '8bcc587e-0794-4454-953d-ae88869f0957', 'Mark', 1, 1500)

insert into dbo.Employees (Id, EmployeeName, NumberOfDependents)
    select EmployeeId, EmployeeName, NumberOfDependents from dbo.BenefitsCosts

select * from dbo.BenefitsCosts
select * from dbo.Employees
