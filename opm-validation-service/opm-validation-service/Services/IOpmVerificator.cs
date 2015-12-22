using opm_validation_service.Models;

namespace opm_validation_service.Services
{
    public interface IOpmVerificator
    {
        /// <summary>
        /// TODO SP: 
        /// 1) this call needs to be parameterized with some token or user identification to limit # of cals per user 
        ///   a. what to do if the EAN/EIC is invalid 
        ///   b. what to do if the user has already queried system too many times
        /// 2) create service that will keep track of # calls to the API for a particular user
        /// </summary>
        /// <param name="codeString"></param>
        /// <returns></returns>
        OpmVerificationResult VerifyOpm(string codeString);

        OpmVerificationResult VerifyOpm(string codeString, string token);
    }
}