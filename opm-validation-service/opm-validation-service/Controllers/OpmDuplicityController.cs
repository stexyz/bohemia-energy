using System;
using System.Web.Http;
using opm_validation_service.Models;
using opm_validation_service.Services;

namespace opm_validation_service.Controllers
{
    public class OpmDuplicityController : ApiController
    {
        /// <summary>
        /// TODO SP: 
        /// 1) expose https endpoint
        /// 2) make this a bean
        /// </summary>
        private readonly OpmVerificator _opmVerificator;

        public OpmDuplicityController(OpmVerificator opmVerificator)
        {
            _opmVerificator = opmVerificator;
        }

        public OpmVerificationResult Get(String id)
        {
            return _opmVerificator.VerifyOpm(id);
        }

        public OpmVerificationResult Get(String id, String token) {
            return _opmVerificator.VerifyOpm(id, token);
        }
    }
}
