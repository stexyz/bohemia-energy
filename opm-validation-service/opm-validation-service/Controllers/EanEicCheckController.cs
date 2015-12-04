using System.Web.Http;
using opm_validation_service.Models;
using opm_validation_service.Services;

namespace opm_validation_service.Controllers
{
    public class EanEicCheckController : ApiController
    {
        private readonly OpmVerificator _opmVerificator;

        public EanEicCheckController()
        {
            _opmVerificator = new OpmVerificator();
        }

        public OpmVerificationResult Get(EanEicCode code)
        {
            return _opmVerificator.VerifyOpm(code);
        }
    }
}
