using opm_validation_service.Models;

namespace opm_validation_service.Services {
    interface IEanEicCheckerHttpClient
    {
        CheckResult Post(EanEicCode code);
    }
}
