namespace opm_validation_service.Services
{
    public class UserLimitRepository: IUserLimitRepository{
        public bool TryAdd(IUser user, int count, out int currentLimit, out int currentBalance)
        {
            throw new System.NotImplementedException();
        }
    }
}