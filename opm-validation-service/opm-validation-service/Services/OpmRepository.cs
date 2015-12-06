using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using opm_validation_service.Models;

namespace opm_validation_service.Services {
    public class OpmRepository : IOpmRepository {
        public Opm GetOpm(EanEicCode code)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateOpm(Opm opm)
        {
            throw new NotImplementedException();
        }

        public void DeleteOpm(EanEicCode code)
        {
            throw new NotImplementedException();
        }
    }
}