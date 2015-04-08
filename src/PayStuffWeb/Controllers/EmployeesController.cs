namespace PayStuffWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using PayStuffLib.Benefits;
    using PayStuffLib.Core;
    using PayStuffLib.Employees;

    [RoutePrefix("employees")]
    public class EmployeesController : ApiController
    {
        private readonly IQueryFactory queryFactory;
        private readonly CreateEmployee createEmployee;
        private readonly DeleteEmployee deleteEmployee;


        public EmployeesController(IQueryFactory queryFactory, CreateEmployee createEmployee, DeleteEmployee deleteEmployee)
        {
            this.queryFactory = queryFactory;
            this.createEmployee = createEmployee;
            this.deleteEmployee = deleteEmployee;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var employees = queryFactory.Create<GetAllEmployees>()
                .Get();

            return Ok(employees);
        }

        [Route("{id:guid}")]
        public IHttpActionResult Get(Guid id)
        {
            var employee = queryFactory.Create<GetEmployeeById>()
                .Get(id);

            return Ok(employee);
        }

        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            deleteEmployee.Run(id);
            
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Post(Employee employee)
        {
            createEmployee.Run(employee);

            return CreatedAtRoute("DefaultApi", new { controller = "employees", id = employee.Id }, employee);
        }

        [Route("{id:guid}/benefits")]
        public IHttpActionResult GetBenefits(Guid id)
        {
            var cost = queryFactory.Create<GetBenefitsByEmployee>()
                .Get(id);

            return Ok(cost);
        }
    }
}