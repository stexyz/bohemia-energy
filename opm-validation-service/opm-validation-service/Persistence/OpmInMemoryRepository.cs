using System.Collections.Concurrent;
using opm_validation_service.Models;

namespace opm_validation_service.Persistence {
    public class OpmInMemoryRepository : IOpmRepository
    {
        private readonly ConcurrentDictionary<EanEicCode, Opm> _repository = new ConcurrentDictionary<EanEicCode, Opm>();

        public bool TryGetOpm(EanEicCode code, out Opm opmForCode)
        {
            return _repository.TryGetValue(code, out opmForCode);
        }

        public bool TryAdd(Opm opm)
        {
            return _repository.TryAdd(opm.Code, opm);
        }

        public bool TryRemoveOpm(EanEicCode code)
        {
            Opm opm;
            return _repository.TryRemove(code, out opm);
        }
    }
}