using CleanShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanShop.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}