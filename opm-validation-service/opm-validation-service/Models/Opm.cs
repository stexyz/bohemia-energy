using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace opm_validation_service.Models {
    public class Opm {
        public EanEicCode Code { get; private set; }
        public Opm(EanEicCode code)
        {
            Code = code;
        }
    }
}