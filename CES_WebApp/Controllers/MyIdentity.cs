using System.Security.Principal;

namespace CES_WebApp.Controllers
{
    class MyIdentity : IIdentity
    {
        public MyIdentity(string authenticationType, bool isAuthenticated, string name)
        {
            AuthenticationType = authenticationType;
            IsAuthenticated = isAuthenticated;
            Name = name;
        }
        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string Name { get; }
    }
}