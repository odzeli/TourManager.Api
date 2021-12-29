using System;
using System.Collections.Generic;
using TourManager.Auth.API.Models;

namespace TourManager.Auth.API.Storage
{
    public class Accounts
    {
        public List<Account> Users => new List<Account>
        {
            new Account() {
                Id = Guid.Parse("564ebebd-45fa-4d2a-8e0f-6b6637025bf8"),
                Email = "user@email.com",
                Password = "user",
                Roles = new Role[] {Role.User}
            },
            new Account() {
                Id = Guid.Parse("3ca57e15-73c1-47ce-bdcc-651819620f25"),
                Email = "admin@email.com",
                Password = "admin",
                Roles = new Role[] {Role.Admin, Role.User}
            }
        };
    }
}
