namespace opm_validation_service.Services
{
    public interface IIdentityManagement {
        bool ValidateUser(string token);
        IUser GetUserInfo(string token);
        string Login(string userName, string password);
    }
}