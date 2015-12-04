using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using opm_validation_service.Models;

namespace opm_validation_service.Services {
    public class OpmRepository {
        public bool FindOpm(EanEicCode code)
        {
            return code.Code == "859182400204379570";
        }
    }
}