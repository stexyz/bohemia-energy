using opm_validation_service.Models;

namespace opm_validation_service.Services {
    public interface IOpmRepository {
        Opm GetOpm(EanEicCode code);
        void AddOrUpdateOpm(Opm opm);
        void DeleteOpm(EanEicCode code);
    }
}
