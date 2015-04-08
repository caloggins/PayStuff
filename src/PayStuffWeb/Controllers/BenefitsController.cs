namespace PayStuffWeb.Controllers
{
    using System.Web.Http;
    using PayStuffLib.Benefits;

    [RoutePrefix("benefits")]
    public class BenefitsController : ApiController
    {
        private readonly GetAllBenefits getAllBenefits;

        public BenefitsController(GetAllBenefits getAllBenefits)
        {
            this.getAllBenefits = getAllBenefits;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(getAllBenefits.Get());
        }
    }
}