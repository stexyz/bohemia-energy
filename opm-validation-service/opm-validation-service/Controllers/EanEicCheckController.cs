using System;
using System.Web.Http;
using opm_validation_service.Models;
using opm_validation_service.Services;

namespace opm_validation_service.Controllers
{
    public class EanEicCheckController : ApiController
    {
        /// <summary>
        /// TODO SP: expose https endpoint
        /// </summary>
        private readonly OpmVerificator _opmVerificator;

        public EanEicCheckController()
        {
            _opmVerificator = new OpmVerificator();
        }

        public OpmVerificationResult Get(String code)
        {
            return _opmVerificator.VerifyOpm(code);
        }
    }
}
