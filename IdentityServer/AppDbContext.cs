using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer;
/// <summary>
/// Author : zahid.cakici@gmail.com
/// Date : 17.07.2022
/// Version : 1.0.0
/// </summary>
public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
}