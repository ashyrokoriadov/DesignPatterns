namespace Proxy.Proxies.AccessControl
{
    class UserContext : IUserContext
    {
        private User _currentUser;

        public void Set(User user) => _currentUser = user;

        public User Get() => _currentUser;
    }
}
