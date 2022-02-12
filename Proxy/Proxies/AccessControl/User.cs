using System.Collections.Generic;

namespace Proxy.Proxies.AccessControl
{
    class User
    {
        public User(string name, IEnumerable<AccessRights> accessRights)
        {
            Name = name;
            AccessRights = accessRights;
        }

        public string Name { get; init; }
        public IEnumerable<AccessRights> AccessRights { get; init; }
    }
}
