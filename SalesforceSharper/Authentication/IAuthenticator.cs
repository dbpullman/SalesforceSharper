using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesforceSharper.Authentication
{
    public interface IAuthenticator
    {
        Task<AuthenticationInfo> Authenticate();
    }
}
