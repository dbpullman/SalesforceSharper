using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharp.Authentication
{
    public interface IAuthenticator
    {
        Task<AuthenticationInfo> Authenticate();
    }
}
