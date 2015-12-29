using opm_validation_service.Models;

namespace opm_validation_service.Persistence {
    //TODO SP: thread-safe!!!
    public interface IOpmRepository {
        bool TryGetOpm(EanEicCode code, out Opm opmForCode);
        bool TryAdd(Opm opm);
        bool TryRemoveOpm(EanEicCode code);
    }
}
