namespace opm_validation_service.Services
{
    public class User : IUser{
        public User(string id)
        {
            Id = id;
        }
        public string Id { get; private set; }
    }
}