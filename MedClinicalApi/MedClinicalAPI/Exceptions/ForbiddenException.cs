using System.Net;

namespace MedClinicalAPI.Exceptions
{
    public class ForbiddenException : BaseCustomException
    {
        public ForbiddenException() : base(HttpStatusCode.Forbidden, "You don't have access to the requested resource")
        {
        }

        public ForbiddenException(string msg) : base(HttpStatusCode.Forbidden, msg)
        {
        }
    }
}