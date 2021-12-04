using Observer.Interfaces;
using System;

namespace Observer.Models
{
    public class User : IIdentifiable
    {
        public User(Guid id, string name, string email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public bool IsLoggedIn { get; set; }

        public override string ToString() => $"{nameof(Id)}: {Id}; {nameof(Name)}: {Name}; " +
            $"{nameof(Email)}: {Email}; {nameof(PhoneNumber)}: {PhoneNumber}; ";
    }
}
