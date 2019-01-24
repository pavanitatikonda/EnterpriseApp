using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp.Interface
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> RegsiterWithEmailPassword(string email, string password);
    }
}
