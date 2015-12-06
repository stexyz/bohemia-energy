using opm_validation_service.Models;

namespace opm_validation_service.Services {
    public interface IEanEicCheckerHttpClient
    {
        CheckResult Post(EanEicCode code);
    }
}
