using System;
using System.Web.Http;
using opm_validation_service.Models;
using opm_validation_service.Services;

namespace opm_validation_service.Controllers
{
    public class OpmDuplicityController : ApiController
    {
        /// <summary>
        /// TODO SP: expose https endpoint
        /// </summary>
        private readonly OpmVerificator _opmVerificator;

        public OpmDuplicityController()
        {
            _opmVerificator = new OpmVerificator();
        }

        public OpmVerificationResult Get(String id)
        {
            return _opmVerificator.VerifyOpm(id);
        }
    }
}
