namespace opm_validation_service.Services
{
    public interface IIdentityManagement {
        bool ValidateUser(string user);
        IUser GetUserInfo(string token);
    }
}