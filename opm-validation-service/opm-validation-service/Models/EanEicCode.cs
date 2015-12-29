using System;

namespace opm_validation_service.Models {
    public class EanEicCode {
        protected bool Equals(EanEicCode other)
        {
            return string.Equals(Code, other.Code);
        }

        public override int GetHashCode()
        {
            return (Code != null ? Code.GetHashCode() : 0);
        }

        public override bool Equals(object obj)
        {
            EanEicCode other = (EanEicCode)obj; 
            if (obj == null || other == null)
            {
                return false;
            }
            return Equals(other);
        }

        public EanEicCode(string code)
        {
            Code = code;
        }

        public String Code { get; private set; }
    }
}