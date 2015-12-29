namespace opm_validation_service.Services
{
    public interface IUserLimitRepository {
        bool TryAdd(IUser user, int count, out int currentLimit, out int currentBalance);
    }
}