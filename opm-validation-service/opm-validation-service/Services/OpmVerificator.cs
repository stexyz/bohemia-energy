using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using opm_validation_service.Controllers;
using opm_validation_service.Models;

namespace opm_validation_service.Services {
    public class OpmVerificator {
        public OpmVerificationResult VerifyOpm(EanEicCode code)
        {
            //TODO SP: implement service
            //1. check validity (use the checker service)
            //2. verify against our DB
            return new OpmVerificationResult(true);
        }
    }
}