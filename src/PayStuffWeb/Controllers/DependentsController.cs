namespace PayStuffWeb.Controllers
{
    using System;
    using System.Web.Http;
    using PayStuffLib.Dependents;
    using PayStuffLib.Employees;

    public class DependentsController : ApiController
    {
        private readonly CreateDependent createDependent;

        public DependentsController(CreateDependent createDependent)
        {
            this.createDependent = createDependent;
        }

        [Route("dependents/{id:guid}", Name = "Dependents")]
        public IHttpActionResult Get(Guid id)
        {
            return BadRequest();
        }

        [Route("employees/{id:guid}/dependents")]
        public IHttpActionResult Post(Guid id, Dependent dependent)
        {
            createDependent.Run(id, dependent);

            return CreatedAtRoute("Dependents", new { controller = "dependents", id = dependent.Id }, dependent);
        }
    }
}