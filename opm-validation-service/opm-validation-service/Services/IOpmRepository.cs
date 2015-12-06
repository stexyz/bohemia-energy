using opm_validation_service.Models;

namespace opm_validation_service.Services {
    public interface IOpmRepository {
        bool TryGetOpm(EanEicCode code, out Opm opmForCode);
        void AddOrUpdateOpm(Opm opm);
        void DeleteOpm(EanEicCode code);
    }
}
