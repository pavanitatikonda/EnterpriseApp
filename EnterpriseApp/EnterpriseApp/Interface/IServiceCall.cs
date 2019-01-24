using Xamarin.Auth;

namespace EnterpriseApp.Interface
{
    public interface IServiceCall
    {
        void LoginAuthenticate(OAuth2Authenticator authenticator);
    }
}
