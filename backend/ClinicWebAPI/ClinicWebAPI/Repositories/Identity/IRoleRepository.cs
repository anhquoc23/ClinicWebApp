﻿using ClinicWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ClinicWebAPI.Repositories.Identity
{
    public interface IRoleRepository
    {
        Task<bool> AddRole(string roleName);
        Task<List<string>> FindByUser(User user);
        Task<bool> IsInRole(User user, string role);
    }
}
