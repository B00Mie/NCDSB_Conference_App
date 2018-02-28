using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NCDSB_Conference_App
{
    internal class Security
    {
        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            throw new NotImplementedException();
        }
    }
}