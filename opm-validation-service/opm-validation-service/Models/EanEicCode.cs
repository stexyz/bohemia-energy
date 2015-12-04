using System;

namespace opm_validation_service.Models {
    public class EanEicCode {
        public EanEicCode(string code)
        {
            Code = code;
        }

        public String Code { get; private set; }
    }
}