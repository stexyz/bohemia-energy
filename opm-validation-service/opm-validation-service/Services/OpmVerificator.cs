using opm_validation_service.Models;

namespace opm_validation_service.Services {
    public class OpmVerificator {
        /// <summary>
        /// TODO SP: 
        /// 1) this call needs to be parameterized with some token or user identification to limit # of cals per user 
        /// 2) create service that will keep track of # calls to the API for a particular user
        /// </summary>
        /// <param name="codeString"></param>
        /// <returns></returns>
        public OpmVerificationResult VerifyOpm(string codeString)
        {
            EanEicCode code = new EanEicCode(codeString);
            //TODO SP: implement service
            //1. check validity (use the checker service)
            //2. verify against our DB
            return new OpmVerificationResult(true);
        }
    }
}