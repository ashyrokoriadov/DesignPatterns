namespace Proxy.Proxies.AccessControl
{
    interface IUserContext
    {
        void Set(User user);

        User Get();
    }
}
