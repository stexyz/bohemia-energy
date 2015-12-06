namespace opm_validation_service.Services
{
    public interface IIdentityManagement {
        bool ValidateUser(IUser user);
    }
}