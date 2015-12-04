namespace opm_validation_service.Models
{
    public class OpmVerificationResult
    {
        public bool Result { get; private set; }
        public OpmVerificationResult(bool result)
        {
            Result = result;
        }
    }
}