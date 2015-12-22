using System;
using opm_validation_service.Models;

namespace opm_validation_service.Services {

    public class OpmVerificator : IOpmVerificator
    {
        public OpmVerificator(IIdentityManagement identityManagement, IEanEicCheckerHttpClient eanEicCheckerHttpClient, IOpmRepository opmRepository)
        {
            IdentityManagement = identityManagement;
            EanEicCheckerHttpClient = eanEicCheckerHttpClient;
            OpmRepository = opmRepository;
        }

        //BEANS:
        public IIdentityManagement IdentityManagement { private get; set; }
        public IEanEicCheckerHttpClient EanEicCheckerHttpClient { private get; set; }
        public IOpmRepository OpmRepository { private get; set; }

        /// <summary>
        /// TODO SP: 
        /// 1) this call needs to be parameterized with some token or user identification to limit # of cals per user 
        ///   a. what to do if the EAN/EIC is invalid 
        ///   b. what to do if the user has already queried system too many times
        /// 2) create service that will keep track of # calls to the API for a particular user
        /// </summary>
        /// <param name="codeString"></param>
        /// <returns></returns>
        public OpmVerificationResult VerifyOpm(string codeString) {
            EanEicCode code = new EanEicCode(codeString);
            return Verify(code);
        }

        public OpmVerificationResult VerifyOpm(string codeString, string token) {
            throw new System.NotImplementedException();
        }

        private OpmVerificationResult Verify(EanEicCode code) {
            CheckResult codeValid = EanEicCheckerHttpClient.Post(code);
            if (codeValid.ResultCode != CheckResultCode.EanOk && codeValid.ResultCode != CheckResultCode.EicOk) {
                //TODO what to do now - maybe better to just return 'false'
                throw new ArgumentException("The supplied code is not valid." + "\n" + codeValid.Description);
            }

            //OK, code is valid, try to find it in the OpmRepository
            Opm opmForCode;
            if (OpmRepository.TryGetOpm(code, out opmForCode)) {
                return new OpmVerificationResult(true);
            }
            return new OpmVerificationResult(false);
        }
    }
}