using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Models.User
{
    public class UserViewModel : IMapFrom<Data.Entities.User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }
    }
}
