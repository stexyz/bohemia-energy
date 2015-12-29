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
        /// 1) expose https endpoint (configurable in Web.config)
        /// 2) make this a bean
        /// 3) decide what to do if number of allowed requests is over limit (http 4xx result vs. code in OpmVerificationResult) 
        /// </summary>
        private readonly IOpmVerificator _opmVerificator;

        public OpmDuplicityController(IOpmVerificator opmVerificator)
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
